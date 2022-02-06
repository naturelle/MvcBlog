﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCategories.Controllers
{
  
    public class BlogController : Controller
    {
        //oluşturduğumuz cm nesnesi aracılığıyla bütün metotlara erişim sağla
        BlogManager bm = new BlogManager(new EFBlogRepository());
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        Context c = new Context();
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogDetails(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
          
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values =  bm.GetBlogListByWriter(writerID);

            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CatName,
                                                       Value = x.CatID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;

            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            BlogValidator bv = new BlogValidator();
                ValidationResult results = bv.Validate(p);
                if (results.IsValid)
                {
                    p.BlogStatus = true;
                    p.BlogDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    p.WriterID = writerID;
                    bm.TAdd(p);
                    return RedirectToAction("BlogListByWriter", "Blog");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
                return View();
            }

        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.GetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = bm.GetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CatName,
                                                       Value = x.CatID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = writerID;
            //p.BlogDate = ;
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }

    }
    }