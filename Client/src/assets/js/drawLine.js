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