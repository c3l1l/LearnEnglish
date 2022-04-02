using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnEnglish.Models;

namespace LearnEnglish.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public CategoryType CategoryType { get; set; }
        public int SectionId { get; set; }

    }
}
