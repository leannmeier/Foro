using Microsoft.AspNetCore.Mvc;
using ORT_PNT1_Proyecto_2022_2C_I_Foro.Models;
using System.Diagnostics;

namespace ORT_PNT1_Proyecto_2022_2C_I_Foro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Redirect("/Preguntas");
        }


        public IActionResult CustomError()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}