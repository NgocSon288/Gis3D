// Vẽ mặt phẳng gồm n điểm
const drawPolygon_1 = (item, render) => {
   const nodes = convertToNodeArray(item.nodes);
   const { n, color, minHeight, maxHeight, outlineColor, outlineWidth } = convertToOptios(item.faceTypeOptionValues);

   outline = {
      color: outlineColor,
      width: outlineWidth
   }
   render(nodes, color, outline)

}

// Vẽ mặt cong, có minHeight, maxHeight
const drawPolygon_2_render = (nodes, options, render) => {
   const ptA = [nodes[0][0], nodes[0][1], nodes[0][2]]
   const ptI = [nodes[1][0], nodes[1][1], nodes[1][2]]
   const ptB = [nodes[2][0], nodes[2][1], nodes[2][2]]

   const { n, color, minHeight, maxHeight, outlineColor, outlineWidth } = options

   const outline = {
      color: outlineColor,
      width: outlineWidth
   }

   const points = pointsToMultipPoints(ptA, ptI, ptB, n)

   for (let i = 0; i < n; i++) {
      const point1 = points[i];
      const point2 = points[i + 1];

      const x1 = point1[0]
      const y1 = point1[1]
      const x2 = point2[0]
      const y2 = point2[1]

      const rings = [
         [x1, y1 + bonus, minHeight],
         [x1, y1, maxHeight],
         [x2, y2, maxHeight],
         [x2, y2 + bonus, minHeight],
      ]
      render(rings, color, outline)
   }

}

const drawPolygon_2 = (item, render) => {
   const nodes = convertToNodeArray(item.nodes);
   const options = convertToOptios(item.faceTypeOptionValues);

   drawPolygon_2_render(nodes, options, render)

}

// Vẽ bánh hoàn hảo
const drawPolygon_3_render = (nodes, options, render) => {
   const [ptA1, ptA2, ptO, ptB1, ptB2] = nodes
   const { color, minHeight: height, n, outlineColor, outlineWidth } = options

   const outline = {
      color: outlineColor,
      width: outlineWidth
   }

   const points1 = pointsToMultipPoints(ptA1, ptO, ptB1, n).reverse()    // Cung lớn
   const points2 = pointsToMultipPoints(ptA2, ptO, ptB2, n)    // Cung nhỏ

   points1.forEach((item, i) => {
      points1[i][2] = height
      points2[i][2] = height
   })

   const rings = [
      [ptA1[0], ptA1[1], height],
      [ptA2[0], ptA2[1], height],
      ...[...points2].slice(1, n - 2),
      [ptB2[0], ptB2[1], height],
      [ptB1[0], ptB1[1], height],
      ...[...points1].slice(1, n - 2)
   ]

   render(rings, color, outline)
}

const drawPolygon_3 = (item, render) => {
   const nodes = convertToNodeArray(item.nodes);
   const options = convertToOptios(item.faceTypeOptionValues);

   drawPolygon_3_render(nodes, options, render)

}

// Vẽ n-1 mặt phẳng thẳng đứng, từ n điểm
const drawPolygon_4 = (item, render) => {

   const nodes = convertToNodeArray(item.nodes);
   const { color, minHeight, maxHeight, outlineColor, outlineWidth } = convertToOptios(item.faceTypeOptionValues);
   const outline = {
      color: outlineColor,
      width: outlineWidth
   }

   // Tạo n-1 multip rings từ n rings
   const multipRings = []
   for (let i = 0; i < nodes.length - 1; i++) {
      const [x1, y1] = nodes[i]
      const [x2, y2] = nodes[i + 1]

      multipRings.push([
         [x1, y1, minHeight],
         [x1, y1, maxHeight],
         [x2, y2, maxHeight],
         [x2, y2, minHeight]
      ])
   }

   multipRings.forEach(rings => {
      render(rings, color, outline)
   })
}

// Vẽ cầu thang gồm m bậc
const drawPolygon_5 = (item, render) => {
   const nodes = convertToNodeArray(item.nodes);
   const { minHeight, maxHeight, n, m, color, outlineColor, outlineWidth } = convertToOptios(item.faceTypeOptionValues);

   const [ptA1, ptA2, ptO, ptB1, ptB2] = nodes;

   const offsetXA = (ptA1[0] - ptA2[0]) / m     // Mội bậc sẽ cách nhau
   const offsetYA = (ptA1[1] - ptA2[1]) / m
   const offsetXB = (ptB1[0] - ptB2[0]) / m
   const offsetYB = (ptB1[1] - ptB2[1]) / m
   const offsetHeight = (maxHeight - minHeight) / m

   // Tìm ra các tọa độ của các hình
   const pointList = []

   for (let i = 0; i <= m; i++) {
      pointList.push(
         [
            [ptA2[0] + offsetXA * i,
            ptA2[1] + offsetYA * i],
            [ptB2[0] + offsetXB * i,
            ptB2[1] + offsetYB * i]
         ]
      )
   }

   // 3 điểm đầu chia thành 3 mặt phẳng cong - type 1
   const ringsType1 = []
   for (let i = 0; i < m; i++) {
      const item = pointList[i]
      const xa = item[0][0]
      const ya = item[0][1]
      const xb = item[1][0]
      const yb = item[1][1]
      const miH = minHeight + offsetHeight * i
      const maH = minHeight + offsetHeight * (i + 1)

      ringsType1.push({
         ptA: [xa, ya],
         ptB: [xb, yb],
         minHeight: miH,
         maxHeight: maH,
      }
      )
   }

   ringsType1.forEach(item => {
      drawPolygon_2_render(
         [item.ptA, ptO, item.ptB,],
         { n, minHeight: item.minHeight, maxHeight: item.maxHeight, color, outlineColor, outlineWidth },
         render)
   })

   // 1-2, 2-3, 3-4 vẽ các bánh - type 6
   const ringsType2 = []
   for (let i = 0; i < m - 1; i++) {
      const item1 = pointList[i + 1]     // Để giống với thứ tự của bánh, A1, A2, B1, B2
      const item2 = pointList[i]

      const xa1 = item1[0][0]
      const ya1 = item1[0][1]

      const xa2 = item2[0][0]
      const ya2 = item2[0][1]

      const xb1 = item1[1][0]
      const yb1 = item1[1][1]

      const xb2 = item2[1][0]
      const yb2 = item2[1][1]

      ringsType2.push({
         ptA1: [xa1, ya1],
         ptA2: [xa2, ya2],
         ptB1: [xb1, yb1],
         ptB2: [xb2, yb2],
         height: (i + 1) * offsetHeight + minHeight
      })


   }

   ringsType2.forEach(item => {
      drawPolygon_3_render(
         [item.ptA1, item.ptA2, ptO, item.ptB1, item.ptB2],
         { minHeight: item.height, n, color, outlineColor, outlineWidth }, render)
   })
   // Vẽ n bánh hoàn hảo
 
}
const drawPolygon_6 = (item, render) => {
   console.log(item)

   const nodes = convertToNodeArray(item.nodes);
   
   const options = convertToOptios(item.faceTypeOptionValues);
   
   const { start, end, count } = options
   const step = (end - start) / (count - 1)
   for (let i = 0; i < count; i++) {
   console.log( start + step * i, i, count)
   drawPolygon_3_render(nodes, {
   
   ...options,
   
   minHeight: start + step * i
   },
   
   render)
   
   }
   
   }