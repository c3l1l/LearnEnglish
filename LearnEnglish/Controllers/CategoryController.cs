using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnEnglish.Base;
using LearnEnglish.Models;
using LearnEnglish.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LearnEnglish.Controllers
{
    public class CategoryController : Controller
    {
        private readonly LearnEnglishContext _db;
        public CategoryController(LearnEnglishContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           var categories= _db.Categories.Include("Section").ToList();
            return View(categories);
        }

        public IActionResult Add()
        {
            ViewBag.Sections = new SelectList(_db.Sections, "SectionId", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryViewModel Model)
        {
            var ajaxResponse = new AjaxResponse();
            try
            {
                var category = new Category();
                category.Name = Model.Name;
                category.CategoryId = Model.CategoryId;
                category.CategoryType = Model.CategoryType;
                category.CreatedDate = DateTime.Now;
                category.SectionId = Model.SectionId;
                category.Rank = byte.MinValue;
                _db.Categories.Add(category);
                _db.SaveChanges();
                ajaxResponse.Result = true;
                ajaxResponse.Message = "Category added successfully";
            }
            catch (Exception e)
            {
                ajaxResponse.Result = false;
                ajaxResponse.Message = "something went wrong !";
                ajaxResponse.DetailMessage = e.InnerException.Message;
            }
            return Json(ajaxResponse);
        }
        public IActionResult GetSection()
        {
            var ajaxResponse = new AjaxResponse();
            var categories = from c in _db.Categories
                join s in _db.Sections
                    on c.SectionId equals s.SectionId
                select new
                {
                    SectionTitle = s.Title,
                    CategoryId = c.CategoryId,
                    CategoryName = c.Name,
                    CategoryType = c.CategoryType,
                    Rank = c.Rank,
                    CreatedDate = c.CreatedDate
                };

            try
            {
                ajaxResponse.Data = categories;
                ajaxResponse.Result = true;
                ajaxResponse.Message = "Categories added successfully !";

            }
            catch (Exception e)
            {
                ajaxResponse.Result = false;
                ajaxResponse.Message = "Something went wrong !!";
            }
            return Json(ajaxResponse);
        }
    }
}
