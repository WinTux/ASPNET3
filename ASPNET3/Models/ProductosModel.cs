using System.Collections.Generic;
using System.Linq;

namespace ASPNET3.Models
{
    public class ProductosModel
    {
        private List<Producto> productos;
        public ProductosModel() {
            productos = new List<Producto> { 
                new Producto{ 
                    id = 4,
                    Nombre = "Queso",
                    precio = 12,
                    imagen = "queso.jpg"
                },
                new Producto{
                    id = 5,
                    Nombre = "Atún",
                    precio = 10.5,
                    imagen = "atun.jpg"
                },
                new Producto{
                    id = 6,
                    Nombre = "Laptop AF",
                    precio = 12000,
                    imagen = "comp01.jpg"
                }
            };
        }

        public List<Producto> getTodo() {
            return productos;
        }
        public Producto getProducto(int id) {
            return productos.Single(p => p.id == id);
        }
    }
}
