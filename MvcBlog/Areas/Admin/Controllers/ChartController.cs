using Microsoft.AspNetCore.Mvc;
using MvcCategories.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCategories.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        
        //kategorilerin grafik üzerind listeleneceği action
        public IActionResult Index()
        {
            return View();
        }
        //verilerime statik olarak değer atayabileceğim action
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryName="Tech",
                categoryCount=10
            });
            list.Add(new CategoryClass
            {
                categoryName = "SW",
                categoryCount = 14
            });
            list.Add(new CategoryClass
            {
                categoryName = "Sport",
                categoryCount = 5
            });
            //chartları json formatında bi script ile çağırcam
            return Json(new { jsonlist = list});
        }
    }
}
