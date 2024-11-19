using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORT_PNT1_Proyecto_2022_2C_I_Foro.Data;

namespace ORT_PNT1_Proyecto_2022_2C_I_Foro.Controllers
{
    public class LoginController : Controller
    {
        private readonly ForoContext _context;

        public LoginController(ForoContext context)
        {
            _context = context;
        }

        public IActionResult Index(bool error = false)
        {
            ViewData["Error"] = error;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Preguntas");
        }

        
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var miembro = await _context.Miembros
                .FirstOrDefaultAsync(m => m.Email == email && m.Password == password);

            if (miembro == null)
            {
                return Redirect("/Login/Index?error=true");
            }

            HttpContext.Session.SetString("_Usuario", miembro.NombreCompleto);
            HttpContext.Session.SetString("_Rol", miembro.Rol);
            HttpContext.Session.SetInt32("_MiembroId", miembro.MiembroId);

            /*
            var nombreCompleto = HttpContext.Session.GetString("_Usuario");
            var rol = HttpContext.Session.GetString("_Rol");
            var miembroId = HttpContext.Session.GetInt32("_MiembroId").ToString();
            */

            return RedirectToAction("Index","Preguntas");
        }
        
    }
}

