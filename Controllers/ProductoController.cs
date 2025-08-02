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
    }
}
