using ASPNET3.Conexion;
using ASPNET3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ASPNET3.Controllers
{
    public class BaseDeDatosController : Controller
    {
        private EmpresaxDbContext contexto;
        public BaseDeDatosController(EmpresaxDbContext contexto) {
            this.contexto = contexto;
        }
        public IActionResult Index()
        {
            var empleados = contexto.Empleados.ToList();
            ViewBag.empleados = empleados;

            //var productos = contexto.Productos.ToList();
            //ViewBag.productos = productos;

            return View();
        }
        //Crear nuevo registro
        [HttpGet]
        public IActionResult Crear() {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Empleado empleado)
        {
            contexto.Add(empleado);
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }

        //Modificar registro
        [HttpGet]
        public IActionResult Modificar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Modificar(Empleado empleado)
        {
            contexto.Entry(empleado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }

        //Eliminar registro
        [HttpGet]
        public IActionResult Eliminar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(int ci)
        {
            contexto.Empleados.Remove(contexto.Empleados.Find(ci));
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
