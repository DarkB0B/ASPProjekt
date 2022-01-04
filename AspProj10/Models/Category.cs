using System;
using System.Linq;
using System.Collections.Generic;
namespace AspProj10.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
