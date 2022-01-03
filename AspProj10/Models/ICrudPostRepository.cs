using System.Collections.Generic;
using System.Linq;

namespace AspProj10.Models
{
    public interface ICrudPostRepository
    {
        Post Add(Post post);

        void Delete(int id);

        Post Update(Post post);

        Post FindById(int id);



        IList<Post> FindAll();

        IList<Post> FindPage(int page, int size);
    }
   public class EFCrudPostRepository : ICrudPostRepository
    {
        private ApplicationDbContext _context;
        public EFCrudPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Post Find(int id)
        {
            return _context.Posts.Find(id);
        }
        public void Delete(int id)
        {
            
            
                var post = _context.Posts.Remove(Find(id)).Entity;
                _context.SaveChanges();
            
           
            
        }
        public Post Add(Post post)
        {
            var entity = _context.Posts.Add(post).Entity;
            _context.SaveChanges();
            return entity;
        }
        public Post Update(Post post)
        {
            var entity = _context.Posts.Update(post).Entity;
            _context.SaveChanges();
            return entity;
        }
        public IList<Post> FindAll()
        {
            return _context.Posts.ToList();
        }
        public Post FindById(int id)
        {
            return _context.Posts.Find(id);
        }
        public IList<Post> FindPage(int page, int size)
        {
            return (from post in _context.Posts orderby post.Title select post).Skip(page * size).Take(size).ToList();
        }
    }
}
