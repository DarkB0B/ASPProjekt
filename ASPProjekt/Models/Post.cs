using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ASPProjekt.Models;
namespace ASPProjekt.Models
{
    public class Post
    {   
        
        public string Title { get; set; }
        public ICollection<Author> Authors { get; set; }
        public DateTime DateOfAdd { get; set; }
        [HiddenInput]
        public int Id { get; set; }
    }
}

