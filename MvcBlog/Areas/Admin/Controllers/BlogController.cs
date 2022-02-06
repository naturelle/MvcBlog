using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcCategories.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCategories.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        //static excel
        public IActionResult ExportStaticExcelBlogList()
        {
            using(var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Lİst");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Naem";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using(var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
            return View();
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{ID=1,BlogName="dscdsf"},
                new BlogModel{ID=2,BlogName="dscdsf"},
                new BlogModel{ID=3,BlogName="dscdsf"},

            };
            return bm;
        }

        //dinamik
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Lİst");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Naem";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList2())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
            return View();
        }

        public List<BlogModel> GetBlogList2()
        {
            List<BlogModel> bm = new List<BlogModel>();
            using (var c = new Context()) 
            {
                bm = c.Blogs.Select(x => new BlogModel
                {
                    ID = x.BlogID,
                    BlogName = x.BlogTitle
                }).ToList();

            };
            return bm;
        }
    }

}
