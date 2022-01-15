using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace AspProj10.Models
             {
            public interface ICrudCommentRepository
              {
            Comment Add(Comment comment);

            void Delete(int id);

            Comment Update(Comment comment);
    
            Comment FindById(int id);

            



            IList<Comment> FindAll();

            IList<Comment> FindPage(int page, int size);
        }
        public class EFCrudCommentRepository : ICrudCommentRepository
    {
            private ApplicationDbContext _context;
            public EFCrudCommentRepository(ApplicationDbContext context)
            {
                _context = context;
            }
            public Comment Find(int id)
            {
                return _context.Comments.Find(id);
            }
            public void Delete(int id)
            {


                var post = _context.Comments.Remove(Find(id)).Entity;
                _context.SaveChanges();



            }
            public Comment Add(Comment comment)
            {
                var entity = _context.Comments.Add(comment).Entity;
                _context.SaveChanges();
                return entity;
            }
            public Comment Update(Comment comment)
            {
                EntityEntry<Comment> entity = _context.Comments.Update(comment);
                _context.SaveChanges();
                return entity.Entity;
            }
            public IList<Comment> FindAll()
            {
                return _context.Comments.ToList();
            }
            public Comment FindById(int id)
            {
                return _context.Comments.Find(id);
            }
            

               
            public IList<Comment> FindPage(int page, int size)
            {
                return (from comment in _context.Comments orderby comment.Commentt select comment).Skip(page * size).Take(size).ToList();
            }
        }
    }


