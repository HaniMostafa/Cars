using Cars.DataAccess.Repostry.IRepostry;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModel;
using Models;

namespace Cars.Areas.Admin.Controllers
{
    [Area("Admin")]

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

                return View();
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
                    return View(Owner);

                }


            }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult UpSert(CarVm obj, IFormFile? file)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        string WwwRootPath = _webHostEnvironment.WebRootPath;
        //        if (file != null)
        //        {
        //            string FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        //            string ProductPath = Path.Combine(WwwRootPath, @"Imagess\Cars");



        //            if (!string.IsNullOrEmpty(obj.car.ImgUrl))
        //            {
        //                //delete old image 
        //                var OldImagePath = Path.Combine(WwwRootPath, obj.car.ImgUrl.TrimStart('\\'));
        //                if (System.IO.File.Exists(OldImagePath))
        //                {
        //                    System.IO.File.Delete(OldImagePath);


        //                }

        //            }
        //            using (var FileStream = new FileStream(Path.Combine(ProductPath, FileName), FileMode.Create))
        //            {
        //                file.CopyTo(FileStream);
        //            }
        //            obj.car.ImgUrl = @"\Imagess\Cars\" + FileName;
        //        }

        //        if (obj.car.Id == 0)
        //        {

        //            _unitOfWork.car.Add(obj.car);
        //            _unitOfWork.Save();
        //            TempData["Success"] = "Category is Created Successfully";
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            _unitOfWork.car.Update(obj.car);
        //            _unitOfWork.Save();
        //            TempData["Success"] = "Category is Updated Successfully";
        //            return RedirectToAction("Index");
        //        }

        //    }
        //    else
        //    {
        //        obj.LstKindCar = _unitOfWork.KindCar.GetAll().Select(u => new SelectListItem
        //        {
        //            Text = u.Name,
        //            Value = u.Id.ToString()
        //        });
        //        return View(obj);
        //    }
        //}

        
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Owner> owners = _unitOfWork.owner.GetAll();
            return Json(new { data = owners });
        }
        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var ProductToBeDeleted = _unitOfWork.car.Get(u => u.Id == id);
        //    if (ProductToBeDeleted == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting" });

        //    }
        //    var OldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, ProductToBeDeleted.ImgUrl.TrimStart('\\'));
        //    if (System.IO.File.Exists(OldImagePath))
        //    {
        //        System.IO.File.Delete(OldImagePath);


        //    }
        //    _unitOfWork.car.Remove(ProductToBeDeleted);
        //    _unitOfWork.Save();
        //    return Json(new { success = true, message = "Deleted Successfully" });

        //}
        //#endregion

    }
}