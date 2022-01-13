using System.Collections.Generic;

namespace AspProj10.Models
{
    public class ViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
