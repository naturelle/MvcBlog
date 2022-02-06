using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
        Context c = new Context();
        public IViewComponentResult Invoke(int id)
        {
            var usermail = User.Identity.Name;
           
            var writerID= c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
           
            var values = wm.GetWriterById(writerID);
            return View(values);
        }
    }
}
