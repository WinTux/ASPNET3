using ASPNET3.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET3.Controllers
{
    public class SupermercadoController : Controller
    {
        public IActionResult Index()
        {
            //instancia de un objeto ProductosModel
            ProductosModel productoModel = new ProductosModel();
            ViewBag.prods = productoModel.getTodo();
            return View();
        }
    }
}
