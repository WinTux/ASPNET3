using ASPNET3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET3.Controllers
{
    public class EjemploAjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ContentResult Ejemplo1()
        {
            return Content("Mensaje que viene desde el servidor", "text/plain");
        }

        [Route("ejemplo2/{nom}")]
        public ContentResult Ejemplo2(string nom)
        {
            Console.WriteLine("Lllega a Ejemplo2 en controlador");
            return Content("Hola " + nom + " ¿cómo estás?", "text/plain");
        }
        public IActionResult Ejemplo3()
        {
            Producto producto = new Producto() { 
                id= 123,
                Nombre = "Atún",
                precio = 12.3
            };
            Console.WriteLine("Lllega a Ejemplo3 en controlador");
            return new JsonResult(producto);
        }

        public IActionResult Ejemplo4()
        {
            List<Producto> productos = new List<Producto>()
            {
                new Producto(){
                    id = 123,
                    Nombre = "Atún",
                    precio = 12.3
                },
                new Producto(){
                    id = 124,
                    Nombre = "Queso",
                    precio = 10
                },
                new Producto(){
                    id = 125,
                    Nombre = "Mantequilla",
                    precio = 7.5
                }
            };
            Console.WriteLine("Lllega a Ejemplo4 en controlador");
            return new JsonResult(productos);
        }
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> Buscar() {
            //Rescatamos el elemento desde la petición (query)
            string subcadena = HttpContext.Request.Query["subcadena"].ToString();

            List<Producto> productos = new List<Producto>()
            {
                new Producto(){
                    id = 123,
                    Nombre = "Atún Lidita",
                    precio = 12.3
                },
                new Producto(){
                    id = 124,
                    Nombre = "Queso Chedar",
                    precio = 10
                },
                new Producto(){
                    id = 125,
                    Nombre = "Mantequilla",
                    precio = 7.2
                },
                new Producto(){
                    id = 123,
                    Nombre = "Atún Vancamps",
                    precio = 14.3
                },
                new Producto(){
                    id = 124,
                    Nombre = "Queso de latita",
                    precio = 10
                },
                new Producto(){
                    id = 125,
                    Nombre = "Mantea",
                    precio = 17.5
                }
            };

            List<string> resultados = productos.Where(p => p.Nombre.Contains(subcadena)).Select(p => p.Nombre).ToList();
            return Ok(resultados);
        }

        [NonAction]
        public int Sumar(int a, int b) {// EjemploAjax/Sumar
            return a + b;
        }
    }
}
