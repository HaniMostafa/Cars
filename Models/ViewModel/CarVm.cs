
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models.ViewModel
{
    public class CarVm
    {
        public Car car { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LstKindCar { get; set; }
        [ValidateNever]

        public IEnumerable<SelectListItem> LstOwner { get; set; }
    }
}
