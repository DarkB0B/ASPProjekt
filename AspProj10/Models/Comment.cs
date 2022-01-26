using System.ComponentModel;

namespace AspProj10.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [DisplayName("Coemment")]
        public string Commentt { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
