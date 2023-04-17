using Microsoft.AspNetCore.Mvc;
using PageApplication.Models;

namespace PageApplication.Controllers
{
    public class RandomObjectsController : Controller
    {
        public ActionResult Index()
        {
            List<RandomObject> randomObjects = new List<RandomObject>
            {
                new RandomObject { Id = 1, Name = "Dog", Type = "Animal" },
                new RandomObject { Id = 2, Name = "Laptop", Type = "Product" },
                new RandomObject { Id = 3, Name = "Alice", Type = "Person" },
            };

            return View(randomObjects);
        }
    }
}

