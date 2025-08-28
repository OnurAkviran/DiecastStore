using DiecastStoreWeb.Data;
using DiecastStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiecastStoreWeb.Controllers
{
    public class CarBrandController : Controller
    {
        private readonly DiecastStoreDbContext _dbContext;
        public CarBrandController(DiecastStoreDbContext db)
        {
            _dbContext = db;
        }
        public IActionResult Index()
        {
            List<CarBrand> carBrandList = _dbContext.CarBrands.ToList(); 
            return View(carBrandList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CarBrand brand)
        {
            if (int.TryParse(brand.CarBrandName, out _))
            {
                ModelState.AddModelError("CarBrandName","The brand name can't contain only numbers.");
            }
            if (ModelState.IsValid)
            {
                _dbContext.CarBrands.Add(brand);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);
        }
    }
}
