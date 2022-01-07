using System.Linq;
namespace AspProj10.Models
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }
    }
}
