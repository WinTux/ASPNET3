using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET3.Controllers
{
    public class CuentaController : Controller
    {
        public IActionResult Index()
        {
            return View();//Crear vista... formulario de login
        }

        [HttpPost]
        public IActionResult login(string usuario, string password) {
            if (usuario != null && password != null && usuario.Equals("admin")
                && password.Equals("admin"))
            {
                HttpContext.Session.SetString("usuario", usuario);
                return View("Exito");
            }
            else {
                ViewBag.mensaje = "No existe la cuenta o el password fue mal escrito";
                return View("Index");
            }
        }

        //Método para logout
        [HttpGet]
        public IActionResult logout() {
            HttpContext.Session.Remove("usuario");
            return RedirectToAction("Index");//Le avisa al cliente
        }
    }
}
