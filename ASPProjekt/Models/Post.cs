using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProjekt.Models
{
    public class Post
    {   
        [Required(ErrorMessage = "Musisz podać tytuł!")]
        [MinLength(2)]
        public string Title { get; set; }
        public DateTime DateOfAdd { get; set; }
        [HiddenInput]
        public int Id { get; set; }
    }
}

