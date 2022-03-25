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
        public int ThemeId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        public sbyte IsActive { get; set; }
        [Required(ErrorMessage = "Please select a level.")]
        public string Level { get; set; }
    }
}
