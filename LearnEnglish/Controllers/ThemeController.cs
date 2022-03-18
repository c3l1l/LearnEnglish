using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnEnglish.Base;
using LearnEnglish.Models;
using LearnEnglish.ViewModels;


namespace LearnEnglish.Controllers
{
    public class ThemeController : Controller
    {
        private readonly LearnEnglishContext _db;

        public ThemeController(LearnEnglishContext db)
        {
            _db = db;
        }
        // GET: ThemeController
        public IActionResult Index()
        {
            var test = _db.Themes.ToList();
            return View(test);
        }

        // GET: ThemeController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }
        
        public IActionResult Add()
        {
            ViewBag.ThemeSaveResult = null;
            return View();
        }
        [HttpPost]
        public IActionResult Add(ThemeViewModel theme)
        {
            if (ModelState.IsValid)
            {
                //Theme thm = new Theme();
                //thm.Title = theme.Title;
                ////thm.IsActive = theme.IsActive;
                //thm.IsActive = (sbyte)((theme.IsActive==true)?1:0);
                //thm.Level = theme.Level;
                //thm.CreatedDate = DateTime.Now;
                //ViewData["levelbilgi"] = thm.Level + "---" + thm.Title+"---"+thm.IsActive;
                var newTheme = new Theme();
                newTheme.Title = theme.Title;
                newTheme.Level = theme.Level;
                newTheme.IsActive= (sbyte)((theme.IsActive == true) ? 1 : 0);
                newTheme.CreatedDate=DateTime.Now;
                newTheme.Rank = byte.MinValue;
                _db.Themes.Add(newTheme);
                try
                {
                    _db.SaveChanges();
                    ViewBag.ThemeSaveResult = true;
                }
                catch (Exception e)
                {
                    ViewBag.ThemeSaveResult = false;
                }

                return View();
            }
            else
            {
                ModelState.AddModelError("test","Please fill all area.");
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int themeId)
        {
            var response = new AjaxResponse();
            var theme = _db.Themes.Where(t => t.ThemeId == themeId).SingleOrDefault();
            _db.Themes.Remove(theme);
            try
            {
                _db.SaveChanges();
                response.Result = true;
            }
            catch (Exception e)
            {
                response.Result = false;
                response.Message = "Something went wrong !";
                response.DetailMessage = e.InnerException.Message;
            }
            return Json(response);
        }

      
      

      
    }
}
