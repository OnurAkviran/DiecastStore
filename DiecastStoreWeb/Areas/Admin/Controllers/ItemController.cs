using DiecastStore.DataAccess.Repository.IRepository;
using DiecastStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiecastStoreWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Item> itemList = _unitOfWork.Item.GetAll().ToList();
            return View(itemList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            if (int.TryParse(item.Name, out _))
            {
                ModelState.AddModelError("Name", "The item name can't contain only numbers.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Item.Add(item);
                _unitOfWork.Save();
                TempData["success"] = "Item created succesfully.";
                return RedirectToAction("Index");
            }
            return View(item);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Item? item = _unitOfWork.Item.GetFirstOrDefault(u => u.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Item.Update(item);
                _unitOfWork.Save();
                TempData["success"] = "Item updated succesfully.";
                return RedirectToAction("Index");
            }
            return View(item);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Item?  item = _unitOfWork.Item.GetFirstOrDefault(u => u.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Item? item = _unitOfWork.Item.GetFirstOrDefault(u => u.Id == id);

            if (item == null)
            {
                return NotFound();
            }
            _unitOfWork.Item.Remove(item);
            _unitOfWork.Save();
            TempData["success"] = "Item deleted succesfully.";
            return RedirectToAction("Index");
        }
    }
}
