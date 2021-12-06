using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Services;
using WebApp.ViewModels.LineTypes;

namespace WebApp.Controllers
{
    public class LineTypeController : Controller
    {
        private readonly ILineTypeService _lineTypeService;
        private readonly IOptionService _optionService;

        public LineTypeController(ILineTypeService lineTypeService,
            IOptionService optionService)
        {
            _lineTypeService = lineTypeService;
            _optionService = optionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _lineTypeService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.isShow = false;
            ViewBag.options = await _optionService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LineTypeCreateRequest model)
        {
            var res = await _lineTypeService.Create(model);
            ViewBag.isShow = true;
            ViewBag.isSuccess = res;
            ViewBag.options = await _optionService.GetAll();

            if (res)
            {
                ViewBag.message = "Tạo LineType thành công";
                ModelState.Clear();

                return View();
            }
            else
            {
                ViewBag.message = "Tạo LineType không thành công";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.isShow = false;
            ViewBag.options = await _optionService.GetAll();
            return View(await _lineTypeService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, LineTypeCreateRequest model)
        {
            var res = await _lineTypeService.Update(id, model);
            ViewBag.isShow = true;
            ViewBag.isSuccess = res;
            ViewBag.options = await _optionService.GetAll();

            if (res)
            {
                ViewBag.message = "Cập nhật LineType thành công";

                model = await _lineTypeService.GetById(id);
            }
            else
            {
                ViewBag.message = "Cập nhật LineType không thành công";
            }
             

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _lineTypeService.Delete(id);

            return Json(new
            {
                isSuccess = res
            });
        }
    }
}
