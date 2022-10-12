﻿using ASPNET3.Herramientas;
using ASPNET3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNET3.Controllers
{
    public class CarritoController : Controller
    {
        public IActionResult Index() //Estado del carrito & botón compra
        {
            List<Item> carrito = Conversor.RecuperarObjeto<List<Item>>(HttpContext.Session, "carrito");
            ViewBag.carr = carrito;
            ViewBag.total = carrito.Sum(it => it.producto.precio  * it.cantidad);
            return View();
        }
        [Route("Comprar/{idprod}")]
        public IActionResult Comprar(int idprod)
        {
            ProductosModel prodAuxiliar = new ProductosModel();
            //TODO agregar producto al carrito:
            //Caso 1: Es el primer producto en el carrito (no existe carrito en la sesión)
            if (Conversor.RecuperarObjeto<List<Item>>(HttpContext.Session, "carrito") == null)
            {
                //Es el primer producto que ingresa al carrito
                List<Item> carrito = new List<Item>();
                carrito.Add(
                    new Item
                    {
                        producto = prodAuxiliar.getProducto(idprod),
                        cantidad = 1
                    }
                );
                Conversor.GuardarObjeto(HttpContext.Session, "carrito", carrito);
            }
            else {
                //Caso 2: el producto no existe. Hay que crear su item (sí existe el carrito)
                List<Item> carrito = Conversor.RecuperarObjeto<List<Item>>(HttpContext.Session, "carrito");
                //Verificando si no existe
                int indice = existe(idprod);
                if ( indice == -1)//No existe
                {
                    carrito.Add(
                        new Item
                        {
                            producto = prodAuxiliar.getProducto(idprod),
                            cantidad = 1
                        }
                    );
                }
                else
                {//Caso 3: el producto existe, hay que incrementar la cantidad de su item
                    carrito[indice].cantidad++;
                }
                //Actualizamnos el atributo "carrito" en la sesión
                Conversor.GuardarObjeto(HttpContext.Session, "carrito", carrito);
            }
            

            return RedirectToAction("Index");
        }

        private int existe(int idprod)
        {
            List<Item> carrito = Conversor.RecuperarObjeto<List<Item>>(HttpContext.Session, "carrito");
            for (int i = 0; i < carrito.Count; i++)
                if (carrito[i].producto.id == idprod)
                    return i;//Sí lo encontró, retornamos su posición
            return -1;//No lo encontró, retornamos -1
        }

        [Route("Eliminar/{idprod}")]
        public IActionResult Eliminar(int idprod)
        {
            List<Item> carrito = Conversor.RecuperarObjeto<List<Item>>(HttpContext.Session, "carrito");
            int indice = existe(idprod);
            carrito.RemoveAt(indice);
            Conversor.GuardarObjeto(HttpContext.Session, "carrito", carrito);
            return RedirectToAction("Index");
        }
    }
}
