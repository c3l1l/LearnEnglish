using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Base
{
    [Serializable()]
    public class AjaxResponse
    {
        public bool Result { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public string DetailMessage { get; set; }
        public List<string> LevelStringList  { get; set; }
    }
}
