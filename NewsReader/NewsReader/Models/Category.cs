using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsReader.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<News> News {get;set;}
    }
}