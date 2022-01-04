namespace AspProj10.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Commentt { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
