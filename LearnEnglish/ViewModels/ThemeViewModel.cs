using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LearnEnglish.Models;

namespace LearnEnglish.ViewModels
{
    public class ThemeViewModel
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Please select a level.")]
        public Levels Level { get; set; }
    }
}
