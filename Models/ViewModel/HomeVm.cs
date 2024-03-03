using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class HomeVm
    {
        [ValidateNever]
   public IEnumerable<Car> ? Carss { get; set; }
   public Car ? Car { get; set; }
    public  List<Owner> ? Owners { get; set; }
     public   Owner ? Owner { get; set; }
    }
}
