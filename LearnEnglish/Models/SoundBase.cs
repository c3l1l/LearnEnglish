using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public abstract class SoundBase
    {
        [DisplayName("Sound Name")]
        public string SoundName { get; set; }
        [DisplayName("Sound Url")]
        public string SoundUrl { get; set; }
        [DisplayName("Sound Type")]
        public string Type { get; set; }
    }
}
