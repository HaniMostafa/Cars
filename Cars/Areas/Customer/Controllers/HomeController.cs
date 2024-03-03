using Cars.DataAccess.Repostry.IRepostry;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModel;
using System.Diagnostics;

namespace Cars.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            HomeVm vm=new()
            {
                Owners=_unitOfWork.owner.GetAll().Take(1).ToList(),
                Carss=_unitOfWork.car.GetAll(InCludeProprty: "CarImages").ToList()
               
            };


            return View(vm);
        }
        [HttpGet]
        public IActionResult Details (int id)
        {

            var car = _unitOfWork.car.Get(a => a.Id == id,InCludeProprty: "KindOfCar-Owner-CarImages");
            if (car ==null)
            {
                return NotFound();
            }

            return View(car);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
