const bonus = 0.000000001;

// Tìm góc
const findAlpha = ([xa, ya], [xi, yi], [xb, yb]) => {
   const IA = [xa - xi, ya - yi]
   const IB = [xb - xi, yb - yi]

   const cosAlpha = (IA[0] * IB[0] + IA[1] * IB[1])
      / (Math.sqrt(IA[0] * IA[0] + IA[1] * IA[1]) * Math.sqrt(IB[0] * IB[0] + IB[1] * IB[1]))


   return Math.acos(cosAlpha)
}

// Sửa lỗi không tô được màu
const fixedRings = (rings) => {
   const minVal = Math.min(...rings.map(x => x[2]))// độ cao nhỏ nhật
   rings.map((item, i) => {
      if (item[2] === minVal) {
         item[1] += bonus
      }
   })
}

// 3 điểm và 1 số cần chia ra n điểm
const pointsToMultipPoints = (ptA, ptI, ptB, n) => {
   const result = []    // Danh sách các tọa đổ điểm
   let prePt = [ptA[0], ptA[1]]
   let alpha = -findAlpha(ptA, ptI, ptB) / n; // Tính ra góc alpha khi có 3 điểm A,B,I => Sau đó chia n
   let a = ptI[0]
   let b = ptI[1]
   // Add điểm đầu tiên
   result.push([...ptA])

   for (let i = 0; i < n - 1; i++) {
      let x = prePt[0]     // Lấy tọa độ điểm B(trước)
      let y = prePt[1]

      let xRes = 0;
      let yRes = 0;

      xRes = (x - a) * Math.cos(alpha) - (y - b) * Math.sin(alpha) + a
      yRes = (x - a) * Math.sin(alpha) + (y - b) * Math.cos(alpha) + b

      prePt[0] = xRes
      prePt[1] = yRes

      result.push([xRes, yRes])
   }

   // Add điểm cuối cùng
   result.push([...ptB])

   return result;
}

// 3 điểm và 1 số cần chia ra n điểm, có dư 2 đầu
const pointsToMultipPoints_2 = (ptA, ptI, ptB, n, k) => {
   const result = []    // Danh sách các tọa đổ điểm
   let prePt = [ptA[0], ptA[1]]
   let alpha = -findAlpha(ptA, ptI, ptB) / n; // Tính ra góc alpha khi có 3 điểm A,B,I => Sau đó chia n
   let a = ptI[0]
   let b = ptI[1]

   // add thêm 1 vài điểm dư đầu, k số
   const startBonus = () => {
      for (let i = 0; i < k; i++) {
         let x = prePt[0]     // Lấy tọa độ điểm B(trước)
         let y = prePt[1]

         let xRes = 0;
         let yRes = 0;

         xRes = (x - a) * Math.cos(-alpha) - (y - b) * Math.sin(-alpha) + a
         yRes = (x - a) * Math.sin(-alpha) + (y - b) * Math.cos(-alpha) + b

         prePt[0] = xRes
         prePt[1] = yRes

         result.push([xRes, yRes])
      }

      // Trả lại trạng thái
      prePt = [ptA[0], ptA[1]]

      result.reverse()
   }

   startBonus()


   // Add điểm đầu tiên
   result.push([...ptA])

   for (let i = 0; i < n - 1; i++) {
      let x = prePt[0]     // Lấy tọa độ điểm B(trước)
      let y = prePt[1]

      let xRes = 0;
      let yRes = 0;

      xRes = (x - a) * Math.cos(alpha) - (y - b) * Math.sin(alpha) + a
      yRes = (x - a) * Math.sin(alpha) + (y - b) * Math.cos(alpha) + b

      prePt[0] = xRes
      prePt[1] = yRes

      result.push([xRes, yRes])
   }


   // Add điểm cuối cùng
   result.push([...ptB])

   // Trả lại trạng thái
   prePt = [ptB[0], ptB[1]]

   // Thêm 1 vài điểm dư cuối, k số
   const endBonus = () => {
      for (let i = 0; i < k; i++) {
         let x = prePt[0]
         let y = prePt[1]

         let xRes = 0;
         let yRes = 0;

         xRes = (x - a) * Math.cos(alpha) - (y - b) * Math.sin(alpha) + a
         yRes = (x - a) * Math.sin(alpha) + (y - b) * Math.cos(alpha) + b

         prePt[0] = xRes
         prePt[1] = yRes

         result.push([xRes, yRes])
      }

      // Trả lại trạng thái
      prePt = [ptA[0], ptA[1]]
   }

   endBonus()

   return result;
}

// Vẽ n điểm trên từ 2 điểm
const pointsToMultipPointsInLine = (ptA, ptB, n) => {

   var result = []

   let prePt = [ptA[0], ptA[1]]

   result.push([...ptA])

   var a = (ptA[0] - ptB[0]) / n;

   var b = (ptA[1] - ptB[1]) / n;



   for (let i = 0; i < n; i++) {

      var xRes = prePt[0] - a;

      var yRes = prePt[1] - b;

      prePt[0] = xRes;

      prePt[1] = yRes;

      result.push([xRes, yRes, ptA[2]])

   }

   result.push([...ptB])

   return result;

}

// Tìm độ dài 2 điểm
const getHeightBy2Node = (n1, n2) => {
   const x1 = n1[0]
   const y1 = n1[1]
   const x2 = n2[0]
   const y2 = n2[1]

   return Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2));
}

// Tìm tọa độ từ offset để vẽ khung tòa trên sân thượng B
const pointsToMultipPoints_WithOffset = (ptA, ptI, ptB, offset, k) => {

   const la = getHeightBy2Node(ptA, ptI) // độ dài từ I đến A
   const lb = getHeightBy2Node(ptB, ptI) // độ dài từ I đến B

   const lan = (la + offset * k) / la;   // Tỉ lệ IA2/IA
   const lbn = (lb + offset * k) / lb;   // Tỉ lệ IB2/IB

   const ptA2 = [ptI[0] + (ptA[0] - ptI[0]) * lan, ptI[1] + (ptA[1] - ptI[1]) * lan]
   const ptB2 = [ptI[0] + (ptB[0] - ptI[0]) * lbn, ptI[1] + (ptB[1] - ptI[1]) * lbn]

   // 2 vì chỉ có chia làm 3
   return pointsToMultipPoints(ptA2, ptI, ptB2, 2)
}

// -------------- Api Reference
// Chuyển các kiểu dữ liệu qua hệ lấy từ api, vì sql server có quan hệ
const convertToOptios = (faceTypeOptioValues) => {
   const obj = {}

   faceTypeOptioValues.forEach(item => {
      obj[item.name] = item.value
   })

   return obj
}

const convertToNodeArray = (nodes) => {
   return nodes.map(({ x, y, z }) => [x, y, z])
}