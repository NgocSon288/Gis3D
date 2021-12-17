// Vẽ dương thẳng từ n điểm
const drawLine_1 = (item, render) => {
   const nodes = convertToNodeArray(item.nodes);
   const { color, width } = convertToOptios(item.lineTypeOptionValues);

   render(nodes, color, width)
}

// Vẽ dương cong từ 2 điểm đầu cuối và 1 điểm làm tâm dường tròn
const drawLine_2 = (item, render) => {
   const nodes = convertToNodeArray(item.nodes);
   const { n, color, width } = convertToOptios(item.lineTypeOptionValues);


   const ptA = [nodes[0][0], nodes[0][1], nodes[0][2]]
   const ptI = [nodes[1][0], nodes[1][1], nodes[1][2]]
   const ptB = [nodes[2][0], nodes[2][1], nodes[2][2]]

   const points = pointsToMultipPoints(ptA, ptI, ptB, n)
   let startHeight = ptA[2]
   let endHeight = ptB[2]
   const stepHeight = (endHeight - startHeight) / n;

   points.forEach((item, i) => {
      item[2] = startHeight + stepHeight * i
   })

   render(points, color, width)
}

// Vẽ lan can cong

const drawLine_3_render = (nodes, options, render) => {
   const ptA = [nodes[0][0], nodes[0][1], nodes[0][2]]
   const ptI = [nodes[1][0], nodes[1][1], nodes[1][2]]
   const ptB = [nodes[2][0], nodes[2][1], nodes[2][2]]

   const { n, m, minHeight, maxHeight, color, width } = options

   var points = pointsToMultipPoints(ptA, ptI, ptB, n)

   const stepHeight = (maxHeight - minHeight) / m;

   points.forEach((item, i) => {
      var line = []
      line.push([item[0], item[1], maxHeight])
      line.push([item[0], item[1], minHeight])
      render(line, color, width)
   })

   points = pointsToMultipPoints(ptA, ptI, ptB, 5)

   for (let j = 0; j < m; j++) {
      points.forEach((item, i) => {
         item[2] = minHeight + (stepHeight * (j + 1));
      })
      render(points, color, width)
   }
}

const drawLine_3 = (item, render) => {
   const nodes = convertToNodeArray(item.nodes);
   const options = convertToOptios(item.lineTypeOptionValues);

   drawLine_3_render(nodes, options, render)
}

// Vẽ lan can thẳng
const drawLine_4_render = (nodes, options, render) => {
   const ptA = [nodes[0][0], nodes[0][1], nodes[0][2]]
   const ptB = [nodes[1][0], nodes[1][1], nodes[1][2]]

   const { n, m, minHeight, maxHeight, color, width } = options

   var points = pointsToMultipPointsInLine(ptA, ptB, n)

   const stepHeight = (maxHeight - minHeight) / m;

   points.forEach((item, i) => {
      var line = []
      line.push([item[0], item[1], maxHeight])
      line.push([item[0], item[1], minHeight])
      render(line, color, width)
   })



   points = [ptA, ptB];
   for (let j = 0; j < m; j++) {
      points.forEach((item, i) => {
         item[2] = minHeight + (stepHeight * (j + 1));
      })
      render(points, color, width)
   }
}

const drawLine_4 = (item, render) => {
   const nodes = convertToNodeArray(item.nodes);
   const options = convertToOptios(item.lineTypeOptionValues);

   drawLine_4_render(nodes, options, render)

}

// Vẽ n lan can cong
const drawLine_5 = (item, render) => {
   const nodes = convertToNodeArray(item.nodes);
   const options = convertToOptios(item.lineTypeOptionValues);
   const { minHeight, maxHeight, count, start, end } = options

   const l = (maxHeight - minHeight) / 2;  // độ dài lệch
   const step = (end - start) / (count - 1)

   for (let i = 0; i < count; i++) {
      drawLine_3_render(nodes, {
         ...options,
         minHeight: start + step * i - l,
         maxHeight: start + step * i + l
      },
         render)
   }
}


// Vẽ n lan can cong

const drawLine_6 = (item, render) => {
   const nodes = convertToNodeArray(item.nodes);
   const options = convertToOptios(item.lineTypeOptionValues);
   const { minHeight, maxHeight, count, start, end } = options

   const l = (maxHeight - minHeight) / 2;  // độ dài lệch
   const step = (end - start) / (count - 1)

   for (let i = 0; i < count; i++) {
      drawLine_4_render(nodes, {
         ...options,
         minHeight: start + step * i - l,
         maxHeight: start + step * i + l
      },
         render)
   }
}
// Vẽ khung
// const drawLine = (paths, color, width)
const drawLine_7 = (item, render) => {
   const nodes = convertToNodeArray(item.nodes);
   const { color, anotherColor, width, n, minHeight, maxHeight, offset } = convertToOptios(item.lineTypeOptionValues);

   const ptA = [nodes[0][0], nodes[0][1], nodes[0][2]]
   const ptI = [nodes[1][0], nodes[1][1], nodes[1][2]]
   const ptB = [nodes[2][0], nodes[2][1], nodes[2][2]]

   // List chứa 9 điểm đáy
   const pointList = []

   // Tìm points1, points2, points3 chứa 9 điểm dưới đáy của khung, theo thứ tự,
   const points1 = pointsToMultipPoints(ptA, ptI, ptB, 2)
   const points2 = pointsToMultipPoints_WithOffset(ptA, ptI, ptB, offset, 1)
   const points3 = pointsToMultipPoints_WithOffset(ptA, ptI, ptB, offset, 2)

   // Cập nhật minHeight
   points1.forEach(item => item[2] = minHeight)
   points2.forEach(item => item[2] = minHeight)
   points3.forEach(item => item[2] = minHeight)

   pointList.push(...points1, ...points2, ...points3)


   // Vẽ 9 cột thẳng dứng từ 9 điểm
   pointList.forEach(item => {
      const x = item[0]
      const y = item[1]
      render([
         [x, y, minHeight],
         [x, y, maxHeight]
      ], color, width)

   })

   // Vẽ 3 thanh ngang, có z
   const drawLine_Horizontal = (_ptA, _ptI, _ptB) => {
      const pointsHori = pointsToMultipPoints_2(_ptA, _ptI, _ptB, n, 1)

      pointsHori.forEach(item => {
         item[2] = maxHeight
      })

      render(pointsHori, anotherColor, width)
   }

   drawLine_Horizontal(points1[0], ptI, points1[2])
   drawLine_Horizontal(points2[0], ptI, points2[2])
   drawLine_Horizontal(points3[0], ptI, points3[2])

   // Vẽ 9 thanh dọc lớn
   const verLength = 9;
   const pointsVerti1 = pointsToMultipPoints(points1[0], ptI, points1[2], verLength - 1)
   const pointsVerti2 = pointsToMultipPoints(points3[0], ptI, points3[2], verLength - 1)

   for (let i = 0; i < verLength; i++) {
      const pt1 = pointsVerti1[i]
      const pt2 = pointsVerti2[i]

      const offset1 = 0.0000204552555745656;    // 3 cây dài
      const offset2 = 0.0000134552555745656;    // 6 cây ngắng

      // Từ 2 điểm trả về 4 điểm
      const l = getHeightBy2Node(pt1, pt2) // độ dài từ pt1 đến pt2

      const ln = (l + ((i == 0 || i == 4 || i == 8) ? offset1 : offset2)) / l;   // Tỉ lệ (pto1 + pt2)/l

      const pto1 = [pt2[0] + (pt1[0] - pt2[0]) * ln, pt2[1] + (pt1[1] - pt2[1]) * ln]
      const pto2 = [pt1[0] + (pt2[0] - pt1[0]) * ln, pt1[1] + (pt2[1] - pt1[1]) * ln]


      render([
         [pto1[0], pto1[1], maxHeight],
         [pt1[0], pt1[1], maxHeight],
         [pt2[0], pt2[1], maxHeight],
         [pto2[0], pto2[1], maxHeight]],
         anotherColor,
         width)
   }

   // Vẽ 6 bồn hoa
   render([points1[0], points2[0]], color, width)
   render([points2[0], points3[0]], color, width)
   render([points1[1], points2[1]], color, width)
   render([points2[1], points3[1]], color, width)
   render([points1[2], points2[2]], color, width)
   render([points2[2], points3[2]], color, width)
}