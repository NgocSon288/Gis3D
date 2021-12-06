using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;
using WebApp.Services;
using WebApp.ViewModels.Bodies;
using WebApp.ViewModels.Lines;
using WebApp.ViewModels.LineTypes;

namespace WebApp.Controllers
{
    public class LineController : Controller
    {
        private readonly ILineTypeService _lineTypeService;
        private readonly ILineService _lineService;
        private readonly IBodyService _bodyService;

        public LineController(ILineTypeService lineTypeService,
            ILineService lineService,
            IBodyService bodyService)
        {
            _lineTypeService = lineTypeService;
            _lineService = lineService;
            _bodyService = bodyService;
        }

        public async Task<IActionResult> Index(LineSearchForm search)
        {
            var lines = await _lineService.GetAll();

            if (search.LineTypeId != null && search.LineTypeId > 0)
            {
                lines = lines.Where(x => x.LineTypeId == search.LineTypeId).ToList();
            }
            if (search.BodyId != null && search.BodyId > -1)
            {
                lines = lines.Where(x => x.Body != null && x.Body.Id == search.BodyId).ToList();
            }
            if (search.Lod != null && search.Lod > 0)
            {
                lines = lines.Where(x => x.Lod == search.Lod).ToList();
            }

            await SetUp(search);

            return View(lines);
        }

        [HttpGet]
        public async Task<IActionResult> Create([FromQuery] int lineTypeSelected = 1)
        {
            ViewBag.isShow = false;

            await SetUp(lineTypeSelected);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetListOptionByLineTypeId()
        {
            var lineTypes = await _lineTypeService.GetAll();

            ViewBag.lineTypes = lineTypes.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LineCreateRequest model, [FromQuery] int lineTypeSelected = 1)
        {
            var res = await _lineService.Create(model);

            await SetUp(lineTypeSelected);

            if (!res)
            {

                ViewBag.isShow = true;
                ViewBag.isSuccess = false;
                ViewBag.message = "Tạo không thành công";

                return View(model);
            }

            model = new LineCreateRequest();
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

            var line = await _lineService.GetById(id);

            if (line == null)
            {
                return RedirectToAction("Index", "Line");
            }

            await SetUp(line.LineTypeId, line.BodyId, (int)line.Lod);

            return View(line);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LineUpdateRequest model, int id)
        {
            var res = await _lineService.Update(id, model);

            await SetUp(model.LineTypeId);

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
            var res = await _lineService.Delete(id);

            return Json(new
            {
                isSuccess = res
            });
        }

        #region Methods

        private async Task SetUp(int lineTypeSelected = 1, int? bodySelected = 0, int lodSelected = 1)
        {
            if (lineTypeSelected == 1)
            {
                // Set lại lineTypeSelected là đầu tiên
                var lineTypeFrist = await _lineTypeService.GetFirstLineType();

                lineTypeSelected = lineTypeFrist.Id;
            }

            var lineTypes = await _lineTypeService.GetAll();
            var lineTypeOptions = await _lineTypeService.GetLineTypeOptionByLineTypeId(lineTypeSelected);
            var bodies = await _bodyService.GetAll();

            // Select các LineType
            int i = 1;
            ViewBag.lineTypes = lineTypes.Select(x => new SelectListItem()
            {
                Selected = lineTypeSelected == x.Id,
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

            // Danh sách các LineTypeOption dựa theo LineType được chọn
            ViewBag.lineTypeOptions = lineTypeOptions;
        }

        private async Task SetUp(LineSearchForm search)
        {
            // Setup lineType
            var lineTypes = await _lineTypeService.GetAll();
            lineTypes.Insert(0, new LineTypeViewModel()
            {
                Id = 0,
                Name = "Tất cả"
            });

            // Select các LineType
            int i = 1;
            ViewBag.lineTypes = lineTypes.Select(x => new SelectListItem()
            {
                Selected = (search.LineTypeId.HasValue ? search.LineTypeId.Value : 0) == x.Id,
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
            var res = await _lineService.GetAll();

            return Ok(res);
        }

        #endregion
    }
}
