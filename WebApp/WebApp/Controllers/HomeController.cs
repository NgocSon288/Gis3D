using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Commons;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFaceService _faceService;
        private readonly IConfiguration _configuration;

        public HomeController(IFaceService faceService, 
            IConfiguration configuration)
        {
            _faceService = faceService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        } 

        [HttpGet]
        public string GetName()
        {
            return _configuration.GetValue<string>(SystemConstants.Owner);
        }
    }
}
