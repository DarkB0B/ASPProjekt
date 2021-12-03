using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProjekt.Models
{
    public class Post
    {
        [Required(ErrorMessage = "Musisz podać tytuł książki!")]
        [MinLength(2)]
        public string Title { get; set; }
        public DateTime DateOfAdd { get; set; }

        public int Id { get; set; }
    }
}

