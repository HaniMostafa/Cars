using Cars.DataAccess.Repostry.IRepostry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.ViewModel;
using Utalties;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Cars.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public CarController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Car> Cars = _unitOfWork.car.GetAll(InCludeProprty: "KindOfCar-Owner");

            return View(Cars);
        }
        [HttpGet]
        public IActionResult UpSert(int? id)
        {
            CarVm vm = new()
            {
                LstKindCar = _unitOfWork.KindCar.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                LstOwner = _unitOfWork.owner.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                car = new Models.Car()

            };
            if (id == 0 || id == null)
            {

                return View(vm);
            }
            else
            {
                vm.car = _unitOfWork.car.Get(u => u.Id == id,InCludeProprty: "CarImages");
                return View(vm);

            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(CarVm obj, List<IFormFile>? files)
        {

            if (ModelState.IsValid)
            {

                if (obj.car.Id == 0)
                {

                    _unitOfWork.car.Add(obj.car);
                }
                else
                {
                    _unitOfWork.car.Update(obj.car);
                }
                _unitOfWork.Save();

                string WwwRootPath = _webHostEnvironment.WebRootPath;
                if (files != null)

                {
                    foreach (IFormFile file in files)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productPath = @"Imagess\Cars\Car-" + obj.car.Id;
                        string finalPath = Path.Combine(WwwRootPath, productPath);

                        if (!Directory.Exists(finalPath))
                            Directory.CreateDirectory(finalPath);

                        using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        CarImg productImage = new()
                        {
                            ImgUrl = @"\" + productPath + @"\" + fileName,
                            CarId = obj.car.Id,
                        };

                        if (obj.car.CarImages == null)
                            obj.car.CarImages = new List<CarImg>();

                        obj.car.CarImages.Add(productImage);

                    }

                    _unitOfWork.car.Update(obj.car);
                    _unitOfWork.Save();

              


            }
                TempData["Success"] =" Product created / updated successfully";

                return RedirectToAction("Index");


            }
            else
            {
                obj.LstKindCar = _unitOfWork.KindCar.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                obj.LstOwner = _unitOfWork.owner.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(obj);
            }
        }

        public IActionResult Delete(int id)
        {
            var ProductToBeDeleted = _unitOfWork.car.Get(u => u.Id == id);
            if (ProductToBeDeleted == null)
            {
                return NotFound();

            }
            //var OldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, ProductToBeDeleted.ImgUrl.TrimStart('\\'));
            //if (System.IO.File.Exists(OldImagePath))
            //{
            //    System.IO.File.Delete(OldImagePath);


            //}
            string productPath = @"Imagess\Cars\Car-" + id;
            string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, productPath);
            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }

                Directory.Delete(finalPath);
            }
            _unitOfWork.car.Remove(ProductToBeDeleted);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult DeleteImage(int imageId)
        {
            var imageToBeDeleted = _unitOfWork.ImageCar.Get(u => u.Id == imageId);
            int productId = imageToBeDeleted.CarId;
            if (imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImgUrl))
                {
                    var oldImagePath =
                                   Path.Combine(_webHostEnvironment.WebRootPath,
                                   imageToBeDeleted.ImgUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                _unitOfWork.ImageCar.Remove(imageToBeDeleted);
                _unitOfWork.Save();

                TempData["success"] = "Deleted successfully";
            }

            return RedirectToAction(nameof(UpSert), new { id = productId });
        }


    }
}

