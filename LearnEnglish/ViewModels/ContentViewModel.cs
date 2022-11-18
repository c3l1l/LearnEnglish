using LearnEnglish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.ViewModels
{
    public class ContentViewModel
    {
        public int ContentId { get; set; }
        public string Title { get; set; }
        public byte Rank { get; set; }
        public DateTime CreatedDate { get; set; }
        public ContentType ContentType { get; set; }
        public Category Category { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int ThemeId { get; set; }
        public string ThemeName { get; set; }

    }
}
