using LearnEnglish.Base;
using LearnEnglish.Models;
using LearnEnglish.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace LearnEnglish.Controllers
{
    public class ContentController : Controller
    {
        private readonly LearnEnglishContext _db;
        public ContentController(LearnEnglishContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var contents = (from co in _db.Contents
                            join ca in _db.Categories on co.CategoryId equals ca.CategoryId
                            join se in _db.Sections on ca.SectionId equals se.SectionId
                            join th in _db.Themes on se.ThemeId equals th.ThemeId
                            select new ContentViewModel
                            {
                                ContentId = co.ContentId,
                                Rank = co.Rank,
                                Title = co.Title,
                                Category = co.Category,
                                CreatedDate = co.CreatedDate,
                                SectionId = ca.SectionId,
                                ContentType = co.ContentType,
                                SectionName = se.Title,
                                ThemeName = th.Title

                            }).ToList();


            return View(contents);
        }
        public IActionResult Add()
        {
            ViewBag.Categories = new SelectList(_db.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Add(string Title, int CategoryId, ContentType ContentType)
        {             
            if (ContentType == ContentType.Instruction)
            {
                try
                {
                    var instruction = new Instruction();
                    instruction.Title = Title;
                    instruction.CreatedDate = DateTime.Now;
                    _db.Instruction.Add(instruction);
                    _db.SaveChanges();
                    var instructionId = instruction.InstructionId;
                   var content= AddContent(instructionId,Title,CategoryId,ContentType);                  
                    TempData["instruction"] = JsonConvert.SerializeObject(instruction);                   
                    return RedirectToAction("Index", "Instruction");
                }
                catch (Exception)
                {
                    return View("Error");                   
                }                         
            }
            if (ContentType.Equals(ContentType.QuestionActivity))
            {
                //question activity kodlari yazilacak/
            }           
            return RedirectToAction("Index","Instruction");
        }

        public Content AddContent(int instructionId,string Title, int CategoryId, ContentType ContentType)
        {
            try
            {
                var content = new Content();
                content.Title = Title;
                content.ContentType = ContentType;
                content.InstructionId= instructionId;
                content.CreatedDate = DateTime.Now;
                content.CategoryId = CategoryId;
                content.Rank = byte.MinValue;
                _db.Contents.Add(content);
                _db.SaveChanges();
                return content;
            }
            catch (Exception)
            {
                throw;
            }          
        }      
    }
}
