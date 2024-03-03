using Cars.DataAccess.Repostry.IRepostry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Models;
using Utalties;

namespace Cars.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class KindOfCarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public KindOfCarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<KindOfCar> LstCars = _unitOfWork.KindCar.GetAll().ToList();
            return View(LstCars);
        }
        public IActionResult Upsert(int id)
        {
            if (id == 0)
            {
                return View(new KindOfCar());
            }
            else
            {
                var kindCar = _unitOfWork.KindCar.Get(a => a.Id == id);
                return View(kindCar);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(KindOfCar model)
        {
            if (ModelState.IsValid)
            {


                if (model.Id == 0)
                {
                    _unitOfWork.KindCar.Add(model);
                    _unitOfWork.Save();
                    TempData["Success"] = "تم اضافه نوع سياره جديد بنجاح";
                }
                else
                {
                    _unitOfWork.KindCar.Update(model);
                    _unitOfWork.Save();
                    TempData["Success"] = "تم تعديل نوع السياره  بنجاح";
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult Delete(int id)
        {
            var ProductToBeDeleted = _unitOfWork.KindCar.Get(u => u.Id == id);
            if (ProductToBeDeleted == null)
            {
                return NotFound();

            }
            _unitOfWork.KindCar.Remove(ProductToBeDeleted);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));

        }

    }

}


