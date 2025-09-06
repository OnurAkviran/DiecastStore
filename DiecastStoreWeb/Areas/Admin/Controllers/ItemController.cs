using DiecastStore.DataAccess.Repository.IRepository;
using DiecastStore.Models;
using DiecastStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

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
            ItemViewModel itemViewModel = new()
            {
                CarBrandList = _unitOfWork.CarBrand
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.CarBrandName,
                    Value = u.Id.ToString()
                }),
                Item = new Item()
            };

            return View(itemViewModel);
        }
        [HttpPost]
        public IActionResult Create(ItemViewModel itemViewModel)
        {
            if (int.TryParse(itemViewModel.Item.Name, out _))
            {
                ModelState.AddModelError("Name", "The item name can't contain only numbers.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Item.Add(itemViewModel.Item);
                _unitOfWork.Save();
                TempData["success"] = "Item created succesfully.";
                return RedirectToAction("Index");
            } else
            {
                itemViewModel.CarBrandList = _unitOfWork.CarBrand
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.CarBrandName,
                    Value = u.Id.ToString()
                });
                return View(itemViewModel);
            }
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
