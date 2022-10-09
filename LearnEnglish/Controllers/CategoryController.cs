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
        public IActionResult Details(string id)
        {
            var ajaxResponse = new AjaxResponse();
            Category category = _db.Categories.Where(s => s.CategoryId == (int.Parse(id))).SingleOrDefault();
            CategoryViewModel categoryViewModel = new CategoryViewModel { CategoryId = category.CategoryId, Name = category.Name, SectionId = category.SectionId };

            ViewBag.Sections = new SelectList(_db.Sections, "SectionId", "Title");
            return View("Edit", categoryViewModel);           
        }
        [HttpPost]
        public IActionResult Edit(CategoryViewModel Model)
        {
            var ajaxResponse = new AjaxResponse();

            var category = _db.Categories.Where(s => s.CategoryId == Model.CategoryId).SingleOrDefault();
            category.Name = Model.Name;
            category.CategoryId = Model.CategoryId;
            category.SectionId = Model.SectionId;
            category.CategoryType = Model.CategoryType;

            try
            {
                _db.SaveChanges();
                ajaxResponse.Result = true;
                ajaxResponse.Message = "Update successful ! ";

            }
            catch (Exception ex)
            {
                ajaxResponse.Message = "Something went wrong, Update failed ! ";
                ajaxResponse.Result = false;
                ajaxResponse.DetailMessage = ex.InnerException.Message;
            }

            return Json(ajaxResponse);
        }
        public IActionResult GetCategory()
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
        public IActionResult Delete(int CategoryId)
        {
            var response = new AjaxResponse();
            var category = _db.Categories.Where(s => s.CategoryId == CategoryId).SingleOrDefault();
            _db.Categories.Remove(category);
            try
            {
                _db.SaveChanges();
                response.Result = true;
                response.Message = "Category has been deleted.";
            }
            catch (Exception e)
            {
                response.Result = false;
                response.Message = "Something went wrong !";
                response.DetailMessage = e.InnerException.Message;
            }
            return Json(response);
        }
        public IActionResult Search(string searchString)
        {
            var ajaxResponse = new AjaxResponse();
            try
            {
                var categories = from c in _db.Categories
                               join s in _db.Sections
                                   on c.SectionId equals s.SectionId
                               select new
                               {
                                   ThemeTitle = s.Title,
                                   CategoryId = c.CategoryId,
                                   Name = c.Name,
                                   Rank = c.Rank,
                                   CreatedDate = c.CreatedDate
                               };
                ajaxResponse.Data = categories.Where(c => c.Name.Contains(searchString)).ToList();
                //  ajaxResponse.Data = _db.Sections.Include("Theme").Where(s => s.Title.Contains(searchString)).ToList();
                ajaxResponse.Result = true;
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
