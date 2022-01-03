using System.Linq;

namespace AspProj10.Models
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }
       
    }
}
