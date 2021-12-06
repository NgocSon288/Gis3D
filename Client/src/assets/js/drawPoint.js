// Vẽ 1 cửa sổ
const drawPoint_1 = (item, param) => {
   const { Point, view, Mesh, Graphic } = param
   const { node } = item
   const { color, sizeDepth, sizeHeight, sizeWidth, rotateX, rotateY, rotateZ } = convertToOptios(item.pointTypeOptionValues);
   const pt = new Point({
      ...node
   })
   const size = {
      width: sizeWidth,
      height: sizeHeight,
      depth: sizeDepth
   }
   const rotate = [rotateX, rotateY, rotateZ]

   let mesh = Mesh.createBox(pt, {
      size,
      material: {
         color
      }
   });

   mesh
      .rotate(...rotate)

   let graphic = new Graphic({
      geometry: mesh,
      symbol: {
         type: "mesh-3d",
         symbolLayers: [{ type: "fill" }]
      }
   });

   view.graphics.add(graphic);
}

// Vẽ n cửa sổ
const drawPoint_2 = (item, param) => {
   const { Point, view, Mesh, Graphic } = param
   const { node } = item
   const { color, sizeDepth, sizeHeight, sizeWidth, rotateX, rotateY, rotateZ, n, minHeight, maxHeight } = convertToOptios(item.pointTypeOptionValues);
   const size = {
      width: sizeWidth,
      height: sizeHeight,
      depth: sizeDepth
   }
   const rotate = [rotateX, rotateY, rotateZ]

   const step = (maxHeight - minHeight) / (n + 1)
   const { x, y, z } = node

   for (let i = 0; i <= n; i++) {
      let mesh = Mesh.createBox(new Point({
         x, y, z: minHeight + step * i
      }), {
         size,
         material: {
            color
         }
      });
      mesh
         .rotate(...rotate)
      let graphic = new Graphic({
         geometry: mesh,
         symbol: {
            type: "mesh-3d",
            symbolLayers: [{ type: "fill" }]
         }
      });

      view.graphics.add(graphic);
   }
}

// Vẽ 1 hình nón
const drawPoint_3 = (item, param) => {
   const { Point, view, Mesh, Graphic } = param

   const { node } = item
   const { color, sizeDepth, sizeHeight, sizeWidth } = convertToOptios(item.pointTypeOptionValues);
   const pt = new Point({
      ...node
   })
   const size = {
      width: sizeWidth,
      height: sizeHeight,
      depth: sizeDepth
   }

   const nose = Mesh.createCylinder(pt, {
      size,
      material: { color }
   });

   const nosePosition = nose.vertexAttributes.position;

   for (let i = 0; i < nosePosition.length / 2; i += 3) {
      nosePosition[i + 0] = pt.x;
      nosePosition[i + 1] = pt.y;
   }
   nose.vertexAttributes.normal = null;
   nose.vertexAttributesChanged();

   view.graphics.add(new Graphic(nose, {
      type: "mesh-3d",
      symbolLayers: [{ type: "fill" }]
   }));

}

