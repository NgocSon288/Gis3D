
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Services;
using WebApp.ViewModels.Bodies;namespace WebApp.Controllers
{
    public class DatasController : Controller
    {
        private readonly IFaceService _faceService;
        private readonly IApiService _apiService; public DatasController(IFaceService faceService,
        IApiService apiService)
        {
            _faceService = faceService;
            _apiService = apiService;
        }
        #region Views [HttpGet]
        public async Task<IActionResult> GetBodies()
        {
            var res = await _apiService.ApiGetBodies(); return Ok(res);
        }
        [HttpPost]
        public IActionResult GetBodiesGis([FromForm] BodyRequest request)
        {
            var res = _apiService.ApiGetBodiesGis(request);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult GetBodiesGis2([FromForm] BodyRequest request)
        {
            var res = _apiService.ApiGetBodiesGis2(request);


            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetLods()
        {
            var res = _apiService.ApiGetLods(); 
            return Ok(res);
        }
        #endregion [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _faceService.GetAll(); return Ok(res);
        }
    }
}


