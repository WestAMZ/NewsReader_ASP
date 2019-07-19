using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsReader.Models.Base;
namespace NewsReader.Models
{
    public class News : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public virtual Category Category {get;set;}
        public virtual Country Country { get; set; }
        public News()
            : base()
        {
            
        }
    }
}