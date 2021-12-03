using System.Collections.Generic;
using System.Linq;
namespace ASPProjekt.Models
{
    public interface ICRUDPostRepository
    {
        Post Add(Post post);

        void Delete(int id);

        Post Update(Post post); 

        Post FindById(int id);

        IList<Post> FindAll();

        IList<Post> FindPage(int page, int size);

    }

    public class EFCRUDPostRepository : ICRUDPostRepository
    {

        private ApplicationDbContext context;

        public EFCRUDPostRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Post Add(Post post)
        {

            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Post> entityEntry = context.Posts.Add(post);
            context.SaveChanges();
            return entityEntry.Entity;
        }

        public void Delete(int id)
        {
            context.Posts.Remove(context.Posts.Find(id));
            context.SaveChanges();
        }

        public IList<Post> FindAll()
        {
            return context.Posts.ToList();
        }

        public Post FindById(int id)
        {
            return context.Posts.Find(id);
        }

        public IList<Post> FindPage(int page, int size)
        {
            return (from post in context.Posts orderby post.Title select post)
                .Skip(page * size)
                .Take(size)
                .ToList();
        }

        public Post Update(Post post)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Post> entityEntry = context.Posts.Update(post);
            context.SaveChanges();
            return entityEntry.Entity;
        }
    }
}
