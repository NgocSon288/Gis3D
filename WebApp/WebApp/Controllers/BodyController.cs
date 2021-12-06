using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Services;
using WebApp.ViewModels.Bodies;

namespace WebApp.Controllers
{
    public class BodyController : Controller
    {
        private readonly IBodyService _bodyService;

        public BodyController(IBodyService bodyService)
        {
            _bodyService = bodyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _bodyService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.isShow = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BodyCreateRequest model)
        {
            var res = await _bodyService.Create(model);
            ViewBag.isShow = true;
            ViewBag.isSuccess = res;

            if (res)
            {
                ViewBag.message = "Tạo body thành công";
                ModelState.Clear();

                return View();
            }
            else
            {
                ViewBag.message = "Tạo body không thành công";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.isShow = false;
            return View(await _bodyService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BodyUpdateRequest model)
        {
            var res = await _bodyService.Update(id, model);
            ViewBag.isShow = true;
            ViewBag.isSuccess = res;

            if (res)
            {
                ViewBag.message = "Cập nhật body thành công";
            }
            else
            {
                ViewBag.message = "Cập nhật body không thành công";
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _bodyService.Delete(id);
             
            return Json(new
            {
                isSuccess = res
            });
        } 
    }
}
