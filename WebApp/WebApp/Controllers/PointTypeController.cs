using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Services;
using WebApp.ViewModels.PointTypes;

namespace WebApp.Controllers
{
    public class PointTypeController : Controller
    {
        private readonly IPointTypeService _pointTypeService;
        private readonly IOptionService _optionService;

        public PointTypeController(IPointTypeService pointTypeService,
            IOptionService optionService)
        {
            _pointTypeService = pointTypeService;
            _optionService = optionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _pointTypeService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.isShow = false;
            ViewBag.options = await _optionService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PointTypeCreateRequest model)
        {
            var res = await _pointTypeService.Create(model);
            ViewBag.isShow = true;
            ViewBag.isSuccess = res;
            ViewBag.options = await _optionService.GetAll();

            if (res)
            {
                ViewBag.message = "Tạo PointType thành công";
                ModelState.Clear();

                return View();
            }
            else
            {
                ViewBag.message = "Tạo PointType không thành công";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.isShow = false;
            ViewBag.options = await _optionService.GetAll();
            return View(await _pointTypeService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PointTypeCreateRequest model)
        {
            var res = await _pointTypeService.Update(id, model);
            ViewBag.isShow = true;
            ViewBag.isSuccess = res;
            ViewBag.options = await _optionService.GetAll();

            if (res)
            {
                ViewBag.message = "Cập nhật PointType thành công";

                model = await _pointTypeService.GetById(id);
            }
            else
            {
                ViewBag.message = "Cập nhật PointType không thành công";
            }


            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _pointTypeService.Delete(id);

            return Json(new
            {
                isSuccess = res
            });
        }
    }
}
