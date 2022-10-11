using ASPNET3.Herramientas;
using ASPNET3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASPNET3.Controllers
{
    public class PruebaSesionController : Controller
    {
        public IActionResult Index()
        {
            //Guardando primitivas en la sesión
            HttpContext.Session.SetInt32("cantidad",12);
            HttpContext.Session.SetString("usuario","pepe123");

            //Guardando un objeto en la sesión
            Producto p = new Producto { 
                id = 1,
                Nombre = "Atún",
                precio = 10.5
            };
            Conversor.GuardarObjeto(HttpContext.Session, "prod", p);

            //Guardando una lista de objetos en la sesión
            List<Producto> productos = new List<Producto>() {
                new Producto {
                id = 11,
                Nombre = "Queso",
                precio = 30
                },
                new Producto {
                id = 12,
                Nombre = "Mantequilla",
                precio = 12
                },
                new Producto {
                id = 13,
                Nombre = "Gaseosa 3L",
                precio = 10.5
                }
            };
            Conversor.GuardarObjeto(HttpContext.Session, "productos", productos);

            return View("Index");
        }
    }
}
