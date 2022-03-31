using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //_db.Database.EnsureDeleted(); 
            //_db.Database.EnsureCreated();
        }
        // GET: ThemeController
        public IActionResult Index()
        {
            var themes = _db.Themes.ToList();
            return View(themes);
        }

        public IActionResult Add()
        {
            ViewBag.ThemeSaveResult = null;
            return View();
        }
        

        #region AddMetodYedek

        //public IActionResult Add(ThemeViewModel theme)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Theme thm = new Theme();
        //        thm.Title = theme.Title;
        //        thm.IsActive = theme.IsActive;
        //        thm.IsActive = (sbyte)((theme.IsActive == true) ? 1 : 0);
        //        thm.Level = theme.Level;
        //        thm.CreatedDate = DateTime.Now;
        //        ViewData["levelbilgi"] = thm.Level + "---" + thm.Title + "---" + thm.IsActive;
        //        ------------
        //            var newTheme = new Theme();
        //        newTheme.Title = theme.Title;
        //        newTheme.Level = theme.Level;
        //        newTheme.IsActive = (sbyte)((theme.IsActive == true) ? 1 : 0);
        //        newTheme.CreatedDate = DateTime.Now;
        //        newTheme.Rank = byte.MinValue;
        //        _db.Themes.Add(newTheme);
        //        try
        //        {
        //            _db.SaveChanges();
        //            ViewBag.ThemeSaveResult = true;
        //        }
        //        catch (Exception e)
        //        {
        //            ViewBag.ThemeSaveResult = false;
        //        }
        //        return View();
        //    }

        //    else
        //    {
        //        ModelState.AddModelError("test", "Please fill all area and select a level !");
        //        return View();
        //    }

        //}

        #endregion

        [HttpPost]
        public IActionResult Add(IFormCollection form)
        {
            var ajaxResponse = new AjaxResponse();
           
            try
            {
                var theme = new Theme();
                theme.Title = form["theme_title"];
                theme.IsActive = (sbyte) ((form["theme_active_passive"]== "on") ? 1 : 0);
                theme.Level = Enum.Parse<Levels>(form["Level"]);
                theme.CreatedDate = DateTime.Now;
                theme.Rank = byte.MinValue;
                _db.Themes.Add(theme);
                _db.SaveChanges();
                ajaxResponse.Result = true;

                ajaxResponse.Message = "Theme added successfully";
           }
            catch (Exception e)
            {
                ajaxResponse.Result = false;
                ajaxResponse.Message = "something went wrong !";
                ajaxResponse.DetailMessage = e.InnerException.Message;
            }

            return Json(ajaxResponse);
        }

        [Route("Theme/Details/{id}")]
        public IActionResult Details(string id)
        {
            var ajaxResponse = new AjaxResponse();
            var theme = _db.Themes.Where(t => t.ThemeId == (int.Parse(id))).SingleOrDefault();
             

              return View("Edit",theme);
        }
        [HttpPost]
        public IActionResult Edit(ThemeViewModel model)
        {
            var ajaxResponse = new AjaxResponse();
            
            var theme = _db.Themes.Where(t => t.ThemeId == model.ThemeId).SingleOrDefault();
            theme.Title = model.Title;
            theme.Level = Enum.Parse<Levels>(model.Level);
            theme.IsActive = (sbyte)(model.IsActive);
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
        public IActionResult Delete(int themeId)
        {
            var response = new AjaxResponse();
            var theme = _db.Themes.Where(t => t.ThemeId == themeId).SingleOrDefault();
            _db.Themes.Remove(theme);
            try
            {  
                _db.SaveChanges();
                response.Result = true;
                response.Message = "Theme has been deleted.";
            }
            catch (Exception e)
            {
                response.Result = false;
                response.Message = "Something went wrong !";
                response.DetailMessage = e.InnerException.Message;
            }
            return Json(response);
        }

        public IActionResult GetTheme()
        {
            var ajaxResponse = new AjaxResponse();
            //ajaxResponse.Data = _db.Themes.ToList();
            try
            {
                ajaxResponse.Data = _db.Themes.ToList();
                ajaxResponse.Result = true;
                ajaxResponse.LevelStringList= GetLevelString();
            }
            catch (Exception e)
            {
                ajaxResponse.Result = false;
                ajaxResponse.Message = "Something went wrong !!";
            }
            return Json(ajaxResponse);
        }

        public IActionResult IsActiveStateChange(int themeId, int isActive)
        {
            var ajaxResponse = new AjaxResponse();
            var theme = _db.Themes.Where(t => t.ThemeId == themeId).SingleOrDefault();

            try
            {
                theme.IsActive = (sbyte)isActive;
                _db.Themes.Update(theme);
                _db.SaveChanges();
                ajaxResponse.Result = true;
                var themeState = (isActive == 1) ? "Active":"Passive";
                ajaxResponse.Message = "Theme state changed as "+ themeState;
            }
            catch (Exception e)
            {
                ajaxResponse.Result = false;
                ajaxResponse.Message = "something went wrong !";
                ajaxResponse.DetailMessage = e.InnerException.Message;
            }

            return Json(ajaxResponse);
        }

        //GetLevelString method uses to getting string Enum values
        public List<string> GetLevelString()
        {
            var levelStringList = new List<string>();
            foreach (Levels enumVals in Enum.GetValues(typeof(Levels)))
            {
                levelStringList.Add(enumVals.ToString());
                //  System.Diagnostics.Debug.WriteLine("enum value" + " " + enumVals);
            }
            return levelStringList;
        }

        [HttpPost]
        public IActionResult Search(string searchString)
        {
            var ajaxResponse = new AjaxResponse();
            try
            {
                ajaxResponse.Data = _db.Themes.Where(t=>t.Title.Contains(searchString)).ToList();
                ajaxResponse.Result = true;
                ajaxResponse.LevelStringList = GetLevelString();
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
