using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public abstract class Sound
    {  
        public string SoundName { get; set; }
        public string SoundUrl { get; set; }
        public string Type { get; set; }
    }
}
