using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCategories.ViewComponents.Writer
{
    
    public class WriterAboutonDashboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());

        public IViewComponentResult Invoke(int id)
        {
            var values = wm.GetWriterById(1);
            return View(values);
        }
    }
}
