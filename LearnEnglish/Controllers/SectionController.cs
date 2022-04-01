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
using Microsoft.AspNetCore.Http;


namespace LearnEnglish.Controllers
{
    public class SectionController : Controller
    {
        private readonly LearnEnglishContext _db;
        public SectionController(LearnEnglishContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //var sections = _db.Sections.ToList();
            var sections = _db.Sections.Include("Theme").ToList();
            return View(sections);
        }

        public IActionResult Add()
        {
            // var themeList = _db.Themes.ToList();
            //ViewBag.themeList = themeList;
            ViewBag.Themes = new SelectList(_db.Themes, "ThemeId", "Title");
            return View();
        }
        [HttpPost]
        public IActionResult Add(SectionViewModel Section)
        {
            var ajaxResponse = new AjaxResponse();

            try
            {
                var section = new Section();
                section.Title = Section.Title;
                section.ThemeId = Section.ThemeId;
                section.CreatedDate = DateTime.Now;
                section.Rank = byte.MinValue;
                _db.Sections.Add(section);
                _db.SaveChanges();
                ajaxResponse.Result = true;

                ajaxResponse.Message = "Section added successfully";
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
            var sections = from s in _db.Sections
                           join t in _db.Themes 
                               on s.ThemeId equals t.ThemeId
                           select new
                           {   ThemeTitle=t.Title,
                               SectionId=s.SectionId,
                               Title = s.Title,
                               Rank=s.Rank,
                               CreatedDate = s.CreatedDate
                           };

            try
            {
                ajaxResponse.Data = sections;
                ajaxResponse.Result = true;
                ajaxResponse.Message = "Section added successfully !";

            }
            catch (Exception e)
            {
                ajaxResponse.Result = false;
                ajaxResponse.Message = "Something went wrong !!";
            }
            return Json(ajaxResponse);
        }

        [Route("Section/Details/{id}")]
        public IActionResult Details(string id)
        {
            var ajaxResponse = new AjaxResponse();
            Section section = _db.Sections.Where(s => s.SectionId == (int.Parse(id))).SingleOrDefault();
            SectionViewModel sectionViewModel = new SectionViewModel{ ThemeId = section.ThemeId, Title = section.Title, SectionId = section.SectionId};
           
            ViewBag.Themes = new SelectList(_db.Themes, "ThemeId", "Title");
            return View("Edit",sectionViewModel);
           // return Content($"id:{section.ThemeId} {section.Title} {section.SectionId}");
        }

        [HttpPost]
        public IActionResult Edit(SectionViewModel Model)
        {
            var ajaxResponse = new AjaxResponse();

            var section = _db.Sections.Where(s => s.SectionId == Model.SectionId).SingleOrDefault();
            section.Title = Model.Title;
            section.ThemeId = Model.ThemeId;

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
        [HttpPost]
        public IActionResult Delete(int SectionId)
        {
            var response = new AjaxResponse();
            var section = _db.Sections.Where(s => s.SectionId == SectionId).SingleOrDefault();
            _db.Sections.Remove(section);
            try
            {
                _db.SaveChanges();
                response.Result = true;
                response.Message = "Section has been deleted.";
            }
            catch (Exception e)
            {
                response.Result = false;
                response.Message = "Something went wrong !";
                response.DetailMessage = e.InnerException.Message;
            }
            return Json(response);
        }
        [HttpPost]
        public IActionResult Search(string searchString)
        {
            var ajaxResponse = new AjaxResponse();
            try
            {
                var sections = from s in _db.Sections
                    join t in _db.Themes
                        on s.ThemeId equals t.ThemeId
                    select new
                    {
                        ThemeTitle = t.Title,
                        SectionId = s.SectionId,
                        Title = s.Title,
                        Rank = s.Rank,
                        CreatedDate = s.CreatedDate
                    };
                ajaxResponse.Data = sections.Where(s=>s.Title.Contains(searchString)).ToList();
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
