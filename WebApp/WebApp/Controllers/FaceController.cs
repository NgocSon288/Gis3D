using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;
using WebApp.Services;
using WebApp.ViewModels.Bodies;
using WebApp.ViewModels.Faces;
using WebApp.ViewModels.FaceTypes;

namespace WebApp.Controllers
{
    public class FaceController : Controller
    {
        private readonly IFaceTypeService _faceTypeService;
        private readonly IFaceService _faceService;
        private readonly IBodyService _bodyService;

        public FaceController(IFaceTypeService faceTypeService,
            IFaceService faceService,
            IBodyService bodyService)
        {
            _faceTypeService = faceTypeService;
            _faceService = faceService;
            _bodyService = bodyService;
        }

        public async Task<IActionResult> Index(FaceSearchForm search)
        {
            var faces = await _faceService.GetAll();

            if (search.FaceTypeId != null && search.FaceTypeId > 0)
            {
                faces = faces.Where(x => x.FaceTypeId == search.FaceTypeId).ToList();
            }
            if (search.BodyId != null && search.BodyId > -1)
            {
                faces = faces.Where(x => x.Body != null && x.Body.Id == search.BodyId).ToList();
            }
            if (search.Lod != null && search.Lod > 0)
            {
                faces = faces.Where(x => x.Lod == search.Lod).ToList();
            }

            await SetUp(search);

            return View(faces);
        }

        [HttpGet]
        public async Task<IActionResult> Create([FromQuery] int faceTypeSelected = 1)
        {
            ViewBag.isShow = false;

            await SetUp(faceTypeSelected);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetListOptionByFaceTypeId()
        {
            var faceTypes = await _faceTypeService.GetAll();

            ViewBag.faceTypes = faceTypes.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FaceCreateRequest model, [FromQuery] int faceTypeSelected = 1)
        {
            var res = await _faceService.Create(model);

            await SetUp(faceTypeSelected);

            if (!res)
            {

                ViewBag.isShow = true;
                ViewBag.isSuccess = false;
                ViewBag.message = "Tạo không thành công";

                return View(model);
            }

            model = new FaceCreateRequest();
            ModelState.Clear();

            ViewBag.isShow = true;
            ViewBag.isSuccess = true;
            ViewBag.message = "Tạo thành công";

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.isShow = false;

            var face = await _faceService.GetById(id);

            if (face == null)
            {
                return RedirectToAction("Index", "Face");
            }

            await SetUp(face.FaceTypeId, face.BodyId, (int)face.Lod);

            return View(face);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FaceUpdateRequest model, int id)
        {
            var res = await _faceService.Update(id, model);

            await SetUp(model.FaceTypeId);

            ViewBag.isShow = true;
            if (!res)
            {
                ViewBag.isSuccess = false;
                ViewBag.message = "Cập nhật không thành công";
            }
            else
            {
                ViewBag.isSuccess = true;
                ViewBag.message = "Cập nhật thành công";
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _faceService.Delete(id);

            return Json(new
            {
                isSuccess = res
            });
        }

        #region Methods

        private async Task SetUp(int faceTypeSelected = 1, int? bodySelected = 0, int lodSelected = 1)
        {
            if (faceTypeSelected == 1)
            {
                // Set lại faceTypeSelected là đầu tiên
                var faceTypeFrist = await _faceTypeService.GetFirstFaceType();

                faceTypeSelected = faceTypeFrist.Id;
            }

            var faceTypes = await _faceTypeService.GetAll();
            var faceTypeOptions = await _faceTypeService.GetFaceTypeOptionByFaceTypeId(faceTypeSelected);
            var bodies = await _bodyService.GetAll();

            // Select các FaceType
            int i = 1;
            ViewBag.faceTypes = faceTypes.Select(x => new SelectListItem()
            {
                Selected = faceTypeSelected == x.Id,
                Text = $"Type {i++}: {x.Name}",
                Value = x.Id.ToString()
            });


            // Select các body
            bodies.Insert(0, new BodyViewModel()
            {
                Id = 0,
                Name = "Không xác định"
            });

            var selectListItems = bodies.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.bodies = bodies.Select(x => new SelectListItem()
            {
                Selected = (bodySelected.HasValue ? bodySelected.Value : 0) == x.Id,
                Text = x.Name,
                Value = x.Id.ToString()
            });

            // Lod
            ViewBag.lods = Enum.GetValues(typeof(LOD)).Cast<LOD>().Select(v => new SelectListItem
            {
                Selected = (int)v == lodSelected,
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

            // Danh sách các FaceTypeOption dựa theo FaceType được chọn
            ViewBag.faceTypeOptions = faceTypeOptions;
        }

        private async Task SetUp(FaceSearchForm search)
        {
            // Setup faceType
            var faceTypes = await _faceTypeService.GetAll();
            faceTypes.Insert(0, new FaceTypeViewModel()
            {
                Id = 0,
                Name = "Tất cả"
            });

            // Select các FaceType
            int i = 1;
            ViewBag.faceTypes = faceTypes.Select(x => new SelectListItem()
            {
                Selected = (search.FaceTypeId.HasValue ? search.FaceTypeId.Value : 0) == x.Id,
                Text = x.Id != 0 ? $"Type {i++}: {x.Name}" : x.Name,
                Value = x.Id.ToString()
            });


            // Setup body
            var bodies = await _bodyService.GetAll();

            // Select các body
            bodies.Insert(0, new BodyViewModel()
            {
                Id = 0,
                Name = "Không xác định"
            });

            bodies.Insert(0, new BodyViewModel()
            {
                Id = -1,
                Name = "Tất cả"
            });

            var selectListItems = bodies.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.bodies = bodies.Select(x => new SelectListItem()
            {
                Selected = (search.BodyId.HasValue ? search.BodyId.Value : -1) == x.Id,
                Text = x.Name,
                Value = x.Id.ToString()
            });

            // Setup lod
            var lods = Enum.GetValues(typeof(LOD)).Cast<LOD>().ToList();

            lods.Insert(0, (LOD)(0));

            ViewBag.lods = lods.Select(v => new SelectListItem
            {
                Selected = (int)v == (search.Lod.HasValue ? (int)search.Lod.Value : 0),
                Text = (int)v > 0 ? v.ToString() : "Tất cả",
                Value = ((int)v).ToString()
            }).ToList();
        }

        #endregion

        #region Api

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _faceService.GetAll();

            return Ok(res);
        }

        #endregion
    }
}
