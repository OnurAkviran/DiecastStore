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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ItemController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Item> itemList = _unitOfWork.Item.GetAll(i => i.CarBrand).ToList();
            return View(itemList);
        }
        public IActionResult InsertUpdate(int? id)
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
            if (!(id == null || id == 0))
            {
                itemViewModel.Item = _unitOfWork.Item.GetFirstOrDefault(u => u.Id == id);//6.47
            }
            return View(itemViewModel);
        }
        [HttpPost]
        public IActionResult InsertUpdate(ItemViewModel itemViewModel, IFormFile? file)
        {
            if (int.TryParse(itemViewModel.Item.Name, out _))
            {
                ModelState.AddModelError("Name", "The item name can't contain only numbers.");
            }
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string itemPath = Path.Combine(wwwRootPath, @"images\media");

                    if(!string.IsNullOrEmpty(itemViewModel.Item.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, itemViewModel.Item.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(itemPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    itemViewModel.Item.ImageUrl = @"\images\media\" + fileName;
                }

                if(itemViewModel.Item.Id !=0)
                {
                    _unitOfWork.Item.Update(itemViewModel.Item);
                }
                else
                {
                    _unitOfWork.Item.Add(itemViewModel.Item);
                }

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

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Item> itemList = _unitOfWork.Item.GetAll(i => i.CarBrand).ToList();
            return Json(new { data = itemList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            Item? item = _unitOfWork.Item.GetFirstOrDefault(u => u.Id == id);
            if (item == null)
            {
                return Json(new { success = false, message = "Unable to delete item." });
            }

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, item.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Item.Remove(item);
            _unitOfWork.Save();
            List<Item> itemList = _unitOfWork.Item.GetAll(i => i.CarBrand).ToList();
            return Json(new { success = true, message = "Item deleted successfully." });
        }
    }
}
