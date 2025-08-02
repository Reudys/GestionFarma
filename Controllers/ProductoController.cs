using GestionFarma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GestionFarma.Controllers
{
    public class ProductoController : Controller
    {
        private static List<Producto> productos = new List<Producto>();
        private int nextId = 1;

        public ProductoController() 
        {
            if (productos.Count < 3)
            {
                productos.Add(new Producto
                {
                    Id = 1,
                    Name = "Paracetamol",
                    Description = "Analgésico y antipirético para el alivio de fiebre y dolor leve.",
                    Price = 2.50m,
                    ExpirationDate = new DateTime(2026, 1, 15)
                });
                productos.Add(new Producto
                {
                    Id = 2,
                    Name = "Ibuprofeno",
                    Description = "Medicamento antiinflamatorio no esteroideo para dolor e inflamación.",
                    Price = 3.20m,
                    ExpirationDate = new DateTime(2025, 12, 10)
                });
                productos.Add(new Producto
                {
                    Id = 3,
                    Name = "Loratadina",
                    Description = "Antihistamínico utilizado para tratar alergias estacionales.",
                    Price = 4.00m,
                    ExpirationDate = new DateTime(2026, 3, 5)
                });
            }
        }

        public IActionResult Index()
        {
            return View(productos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (!ModelState.IsValid) return View(producto);
            producto.Id = nextId++;
            productos.Add(producto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Producto producto)
        {
            if (!ModelState.IsValid) return View(producto);
            var existingProducto = productos.FirstOrDefault(p => p.Id == producto.Id);
            if (existingProducto == null) return NotFound();
            existingProducto.Name = producto.Name;
            existingProducto.Description = producto.Description;
            existingProducto.Price = producto.Price;
            existingProducto.ExpirationDate = producto.ExpirationDate;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();
            productos.Remove(producto);
            return RedirectToAction("Index");
        }
    }
}
