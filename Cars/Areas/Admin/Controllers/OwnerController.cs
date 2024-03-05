using Cars.DataAccess.Repostry.IRepostry;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.AspNetCore.Authorization;
using Utalties;

namespace Cars.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class OwnerController : Controller
    {
      
            private readonly IUnitOfWork _unitOfWork;
            private readonly IWebHostEnvironment _webHostEnvironment;

            public OwnerController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
            {
                _unitOfWork = unitOfWork;
                _webHostEnvironment = webHostEnvironment;
            }

            public IActionResult Index()
            {
            IEnumerable<Owner> owners = _unitOfWork.owner.GetAll();
            return View(owners);
            }

            [HttpGet]
            public IActionResult UpSert(int? id)
            {
                    
                if (id == 0 || id == null)
                {

                    return View(new Models.Owner());
                }
                else
                {
                    var Owner = _unitOfWork.owner.Get(u => u.Id == id);
                if (Owner == null)
                {
                    return NotFound("بس يا حبيبي");
                }
                    return View(Owner);
                }
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(Owner obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string WwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string ProductPath = Path.Combine(WwwRootPath, @"Imagess\Owner");

                    if (!string.IsNullOrEmpty(obj.Image))
                    {
                        //delete old image 
                        var OldImagePath = Path.Combine(WwwRootPath, obj.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(OldImagePath))
                        {
                            System.IO.File.Delete(OldImagePath);


                        }
                    }
                    using (var FileStream = new FileStream(Path.Combine(ProductPath, FileName), FileMode.Create))
                    {
                        file.CopyTo(FileStream);
                    }
                    obj.Image = @"\Imagess\Owner\" + FileName;
                }

                if (obj.Id == 0)
                {

                    _unitOfWork.owner.Add(obj);
                    _unitOfWork.Save();
                    TempData["Success"] = "Category is Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    _unitOfWork.owner.Update(obj);
                    _unitOfWork.Save();
                    TempData["Success"] = "Category is Updated Successfully";
                    return RedirectToAction("Index");
                }
            }
            else
            {
              
                return View(obj);
            }
        }

        
        public IActionResult Delete(int id)
        {
            var ProductToBeDeleted = _unitOfWork.owner.Get(u => u.Id == id);
            if (ProductToBeDeleted == null)
            {
                return NotFound();

            }
            var OldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, ProductToBeDeleted.Image.TrimStart('\\'));
            if (System.IO.File.Exists(OldImagePath))
            {
                System.IO.File.Delete(OldImagePath);

            }
            _unitOfWork.owner.Remove(ProductToBeDeleted);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));

        }

    }
}