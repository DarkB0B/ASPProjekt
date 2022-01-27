using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace AspProj10.Models
{

    public class EFCrudRepository : ICrudRepository
    {
         private ApplicationDbContext _context;
        public EFCrudRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Category FindC(int id)
        {
            return _context.Categories.Find(id);
        }
        public void DeleteC(int id)
        {


            var post = _context.Categories.Remove(FindC(id)).Entity;
            _context.SaveChanges();



        }
        public Category AddC(Category category)
        {
            var entity = _context.Categories.Add(category).Entity;
            _context.SaveChanges();
            return entity;
        }
        public Category UpdateC(Category category)
        {
            EntityEntry<Category> entity = _context.Categories.Update(category);
            _context.SaveChanges();
            return entity.Entity;
        }
        public IList<Category> FindAllC()
        {
            return _context.Categories.ToList();
        }
        public Category FindByIdC(int id)
        {
            return _context.Categories.Find(id);
        }

        public Post FindP(int id)
        {
            return _context.Posts.Find(id);
        }
        public void LikeP(int id)
        {
            var post = _context.Posts.Find(id);
            post.LikeAmmount += 1;
            _context.SaveChanges();
        }
        public void DeleteP(int id)
        {


            var post = _context.Posts.Remove(FindP(id)).Entity;
            _context.SaveChanges();



        }
        public Post AddP(Post post)
        {
            var entity = _context.Posts.Add(post).Entity;
            _context.SaveChanges();
            return entity;
        }
        public Post UpdateP(Post post)
        {
            EntityEntry<Post> entity = _context.Posts.Update(post);
            _context.SaveChanges();
            return entity.Entity;
        }
        public IList<Post> FindAllP()
        {
            return _context.Posts.ToList();
        }
        public Post FindByIdP(int id)
        {
            return _context.Posts.Find(id);
        }


        public Comment FindCo(int id)
        {
            return _context.Comments.Find(id);
        }
        public void DeleteCo(int id)
        {


            var post = _context.Comments.Remove(FindCo(id)).Entity;
            _context.SaveChanges();



        }
        public Comment AddCo(Comment comment)
        {
            var entity = _context.Comments.Add(comment).Entity;
            _context.SaveChanges();
            return entity;
        }
        public Comment UpdateCo(Comment comment)
        {
            EntityEntry<Comment> entity = _context.Comments.Update(comment);
            _context.SaveChanges();
            return entity.Entity;
        }
        public IList<Comment> FindAllCo()
        {
            return _context.Comments.ToList();
        }
        public Comment FindByIdCo(int id)
        {
            return _context.Comments.Find(id);
        }



       

    }
}
