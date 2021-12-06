using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;
using WebApp.Services;
using WebApp.ViewModels.Bodies;
using WebApp.ViewModels.Points;
using WebApp.ViewModels.PointTypes;

namespace WebApp.Controllers
{
    public class PointController : Controller
    {
        private readonly IPointTypeService _pointTypeService;
        private readonly IPointService _pointService;
        private readonly IBodyService _bodyService;

        public PointController(IPointTypeService pointTypeService,
            IPointService pointService,
            IBodyService bodyService)
        {
            _pointTypeService = pointTypeService;
            _pointService = pointService;
            _bodyService = bodyService;
        }

        public async Task<IActionResult> Index(PointSearchForm search)
        {
            var points = await _pointService.GetAll();

            if (search.PointTypeId != null && search.PointTypeId > 0)
            {
                points = points.Where(x => x.PointTypeId == search.PointTypeId).ToList();
            }
            if (search.BodyId != null && search.BodyId > -1)
            {
                points = points.Where(x => x.Body != null && x.Body.Id == search.BodyId).ToList();
            }
            if (search.Lod != null && search.Lod > 0)
            {
                points = points.Where(x => x.Lod == search.Lod).ToList();
            }

            await SetUp(search);

            return View(points);
        }

        [HttpGet]
        public async Task<IActionResult> Create([FromQuery] int pointTypeSelected = 1)
        {
            ViewBag.isShow = false;

            await SetUp(pointTypeSelected);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetListOptionByPointTypeId()
        {
            var pointTypes = await _pointTypeService.GetAll();

            ViewBag.pointTypes = pointTypes.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PointCreateRequest model, [FromQuery] int pointTypeSelected = 1)
        {
            var res = await _pointService.Create(model);

            await SetUp(pointTypeSelected);

            if (!res)
            {

                ViewBag.isShow = true;
                ViewBag.isSuccess = false;
                ViewBag.message = "Tạo không thành công";

                return View(model);
            }

            model = new PointCreateRequest();
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

            var point = await _pointService.GetById(id);

            if (point == null)
            {
                return RedirectToAction("Index", "Point");
            }

            await SetUp(point.PointTypeId, point.BodyId, (int)point.Lod);

            return View(point);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PointUpdateRequest model, int id)
        {
            var res = await _pointService.Update(id, model);

            await SetUp(model.PointTypeId);

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
            var res = await _pointService.Delete(id);

            return Json(new
            {
                isSuccess = res
            });
        }

        #region Methods

        private async Task SetUp(int pointTypeSelected = 1, int? bodySelected = 0, int lodSelected = 1)
        {
            if (pointTypeSelected == 1)
            {
                // Set lại pointTypeSelected là đầu tiên
                var pointTypeFrist = await _pointTypeService.GetFirstPointType();

                pointTypeSelected = pointTypeFrist.Id;
            }

            var pointTypes = await _pointTypeService.GetAll();
            var pointTypeOptions = await _pointTypeService.GetPointTypeOptionByPointTypeId(pointTypeSelected);
            var bodies = await _bodyService.GetAll();

            // Select các PointType
            int i = 1;
            ViewBag.pointTypes = pointTypes.Select(x => new SelectListItem()
            {
                Selected = pointTypeSelected == x.Id,
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

            // Danh sách các PointTypeOption dựa theo PointType được chọn
            ViewBag.pointTypeOptions = pointTypeOptions;
        }

        private async Task SetUp(PointSearchForm search)
        {
            // Setup pointType
            var pointTypes = await _pointTypeService.GetAll();
            pointTypes.Insert(0, new PointTypeViewModel()
            {
                Id = 0,
                Name = "Tất cả"
            });

            // Select các PointType
            int i = 1;
            ViewBag.pointTypes = pointTypes.Select(x => new SelectListItem()
            {
                Selected = (search.PointTypeId.HasValue ? search.PointTypeId.Value : 0) == x.Id,
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
            var res = await _pointService.GetAll();

            return Ok(res);
        }

        #endregion
    }
}
