using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Services;
using WebApp.ViewModels.FaceTypes;

namespace WebApp.Controllers
{
    public class FaceTypeController : Controller
    {
        private readonly IFaceTypeService _faceTypeService;
        private readonly IOptionService _optionService;

        public FaceTypeController(IFaceTypeService faceTypeService,
            IOptionService optionService)
        {
            _faceTypeService = faceTypeService;
            _optionService = optionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _faceTypeService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.isShow = false;
            ViewBag.options = await _optionService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FaceTypeCreateRequest model)
        {
            var res = await _faceTypeService.Create(model);
            ViewBag.isShow = true;
            ViewBag.isSuccess = res;
            ViewBag.options = await _optionService.GetAll();

            if (res)
            {
                ViewBag.message = "Tạo FaceType thành công";
                ModelState.Clear();

                return View();
            }
            else
            {
                ViewBag.message = "Tạo FaceType không thành công";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.isShow = false;
            ViewBag.options = await _optionService.GetAll();
            return View(await _faceTypeService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, FaceTypeCreateRequest model)
        {
            var res = await _faceTypeService.Update(id, model);
            ViewBag.isShow = true;
            ViewBag.isSuccess = res;
            ViewBag.options = await _optionService.GetAll();

            if (res)
            {
                ViewBag.message = "Cập nhật FaceType thành công";

                model = await _faceTypeService.GetById(id);
            }
            else
            {
                ViewBag.message = "Cập nhật FaceType không thành công";
            }


            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _faceTypeService.Delete(id);

            return Json(new
            {
                isSuccess = res
            });
        }
    }
}
