$(document).ready(() => {
   const bodiesEle = document.getElementById('list-body')
   const lodEle = document.getElementById('list-lod')
   const formEle = document.getElementById('filter-gis')


   formEle.addEventListener('submit', function (e) {
      e.preventDefault()
      const bodies = [] // danh sách các body được chọn
      let lod = 0;

      const checkWrapBodyEles = bodiesEle.querySelectorAll('.form-check')
      const checkWrapLodEles = lodEle.querySelectorAll('.form-check')


      checkWrapBodyEles.forEach(item => {
         const checkEle = item.querySelector('input')

         if (checkEle.checked) {
            bodies.push(Number(checkEle.value))
         }
      })

      checkWrapLodEles.forEach(item => {
         const checkEle = item.querySelector('input')
         if (checkEle.checked) {
            lod = checkEle.value
         }
      })

      const data = {
         lod,
         bodyId: [...bodies]
      }

      // fetch(`${baseUrl}/face/getall`)
      //    .then(response => response.json())
      //    .then(data => {
      //       console.log(data);
      //       renderMap(data)
      //    });

      // return;

      // Gọi api và reload
      $.ajax({
         url: `${baseUrl}/datas/getBodiesGis2`,
         data: data,
         success: function (data) {
            console.log('res', data);
            const gisDataDynamic = []     // chứa danh sách tất cả các body, line, point
            if (data && data.result) {
               data.result.forEach(item => {
                  // Mỗi item là một body
                  // Tử item lấy ra danh sách các body, line, point để vẽ

                  if (item.faces)
                     gisDataDynamic.push(...item.faces)

                  if (item.lines)
                     gisDataDynamic.push(...item.lines)

                  if (item.points)
                     gisDataDynamic.push(...item.points)
               })
            }
            renderMap(gisDataDynamic)

         },
         type: 'POST',
      });

   })

   // Load select body
   $.ajax({
      url: `${baseUrl}/datas/getBodies`,
      success: (res) => {
         // Load select body

         res.forEach(item => {
            const { id, name } = item

            const optionEle = document.createElement('div')
            optionEle.classList.add('form-check')

            optionEle.innerHTML = `<input class="form-check-input" type="checkbox" checked value="${id}" id="bodyCheck${id}">
                   <label class="form-check-label" for="bodyCheck${id}">
                      ${name}
                   </label>
            `
            bodiesEle.appendChild(optionEle)

         })
      }
   });

   // Load select lod
   $.ajax({
      url: `${baseUrl}/datas/getLods`,
      success: (res) => {

         res.forEach((id, i) => {

            const optionEle = document.createElement('div')
            optionEle.classList.add('form-check')

            optionEle.innerHTML = `
                     <input class="form-check-input" type="radio" name="flexRadioDefault" ${i === 0 ? 'checked' : ''} value="${id}" id="lodCheck${id}">
                        <label class="form-check-label" for="lodCheck${id}">
                           LOD ${id}
                        </label>
               </>
            `

            lodEle.appendChild(optionEle)

         })
      }
   });

   // Khởi tạo gis
   const init = () => {
      data = {
         bodyId: [0, 1, 2, 3, 4, 5],
         lod: "3"
      }

      $.ajax({
         url: `${baseUrl}/datas/getBodiesGis2`,
         data: data,
         success: function (data) {
            const gisDataDynamic = []     // chứa danh sách tất cả các body, line, point

            data.result.forEach(item => {
               // Mỗi item là một body
               if (item.faces)
                  gisDataDynamic.push(...item.faces)

               if (item.lines)
                  gisDataDynamic.push(...item.lines)

               if (item.points)
                  gisDataDynamic.push(...item.points)
            })
            renderMap(gisDataDynamic)

         },
         type: 'POST',
      });
   }

   init()

})

