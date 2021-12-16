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

// Vẽ n điểm trên từ 2 điểm

const pointsToMultipPointsInLine = (ptA, ptB, n) => {

   var result = []
   
   let prePt = [ptA[0], ptA[1]]
   
   console.log(prePt);
   
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
   
   
   
   console.log(result);
   
   return result;
   
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