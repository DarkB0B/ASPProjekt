using System.Linq;
namespace AspProj10.Models
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; }
    }
}
