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

// Vẽ lan can

const drawLine_3 = (item, render) => {
   console.log(item)
   // ptA, ptI, ptB, n, m, minHeight, maxHeight, color, width
   const nodes = convertToNodeArray(item.nodes);
   const { n, m, minHeight, maxHeight, color, width } = convertToOptios(item.lineTypeOptionValues);

   const ptA = [nodes[0][0], nodes[0][1], nodes[0][2]]
   const ptI = [nodes[1][0], nodes[1][1], nodes[1][2]]
   const ptB = [nodes[2][0], nodes[2][1], nodes[2][2]]

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

// Vẽ lan can thẳng
const drawLine_4 = (item, render) => {
   console.log(item)
   const nodes = convertToNodeArray(item.nodes);
   const { n, m, minHeight, maxHeight, color, width } = convertToOptios(item.lineTypeOptionValues);

   const ptA = [nodes[0][0], nodes[0][1], nodes[0][2]]
   const ptB = [nodes[1][0], nodes[1][1], nodes[1][2]] 


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