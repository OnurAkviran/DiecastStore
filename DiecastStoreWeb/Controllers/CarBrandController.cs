using DiecastStore.DataAccess.Data;
using DiecastStore.Models;
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
                TempData["success"] = "Brand created succesfully.";
                return RedirectToAction("Index");
            }
            return View(brand);
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            CarBrand? carBrand = _dbContext.CarBrands.Find(id);
            if (carBrand == null)
            {
                return NotFound();
            }
            return View(carBrand);
        }
        [HttpPost]
        public IActionResult Edit(CarBrand brand)
        {
            if (ModelState.IsValid)
            {
                _dbContext.CarBrands.Update(brand);
                _dbContext.SaveChanges();
                TempData["success"] = "Brand updated succesfully.";
                return RedirectToAction("Index");
            }
            return View(brand);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            CarBrand? carBrand = _dbContext.CarBrands.Find(id);
            if (carBrand == null)
            {
                return NotFound();
            }
            return View(carBrand);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            CarBrand? carBrand = _dbContext.CarBrands.Find(id);

            if (carBrand == null)
            {
                return NotFound();
            }
            _dbContext.Remove(carBrand);
            _dbContext.SaveChanges();
            TempData["success"] = "Brand deleted succesfully.";
            return RedirectToAction("Index");
        }
    }
}
