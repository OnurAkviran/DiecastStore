using DiecastStore.DataAccess.Data;
using DiecastStore.DataAccess.Repository.IRepository;
using DiecastStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiecastStoreWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarBrandController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarBrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<CarBrand> carBrandList = _unitOfWork.CarBrand.GetAll().ToList(); 
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
                _unitOfWork.CarBrand.Add(brand);
                _unitOfWork.Save();
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

            CarBrand? carBrand = _unitOfWork.CarBrand.GetFirstOrDefault(u => u.Id == id);
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
                _unitOfWork.CarBrand.Update(brand);
                _unitOfWork.Save();
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

            CarBrand? carBrand = _unitOfWork.CarBrand.GetFirstOrDefault(u => u.Id == id);
            if (carBrand == null)
            {
                return NotFound();
            }
            return View(carBrand);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            CarBrand? carBrand = _unitOfWork.CarBrand.GetFirstOrDefault(u => u.Id == id);

            if (carBrand == null)
            {
                return NotFound();
            }
            _unitOfWork.CarBrand.Remove(carBrand);
            _unitOfWork.Save();
            TempData["success"] = "Brand deleted succesfully.";
            return RedirectToAction("Index");
        }
    }
}
