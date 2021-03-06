using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AspProj10.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int LikeAmmount { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfAdd { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [DisplayName("Image Name")]
        public string ImageName { get; set; }
        [Required]
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
        public Post()
        {

        }

    }
}
