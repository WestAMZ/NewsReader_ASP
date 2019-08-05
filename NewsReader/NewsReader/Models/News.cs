using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace NewsReader.Models
{
    public class News : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime Published { get; set; }

        public int IdCategory { get; set; }
        public int IdCountry { get; set; }
        public virtual Category Category {get;set;}
        public virtual Country Country { get; set; }
    }
}