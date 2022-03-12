using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnEnglish.Models;


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
            return View("Details");
        }

        public IActionResult Add()
        {
            return View("Add");
        }

      

       
        public IActionResult Edit(int id)
        {
            return View();
        }

      
      

      
    }
}
