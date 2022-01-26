using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace AspProj10.Models
    {
        public interface ICrudCategoryRepository
    {
            Category Add(Category ctegory);

            void Delete(int id);

            Category Update(Category category);

            Category FindById(int id);

            



            IList<Category> FindAll();

            
        }
        public class EFCrudCategoryRepository : ICrudCategoryRepository
    {
            private ApplicationDbContext _context;
            public EFCrudCategoryRepository(ApplicationDbContext context)
            {
                _context = context;
            }
            public Category Find(int id)
            {
                return _context.Categories.Find(id);
            }
            public void Delete(int id)
            {


                var post = _context.Categories.Remove(Find(id)).Entity;
                _context.SaveChanges();



            }
            public Category Add(Category category)
            {
                var entity = _context.Categories.Add(category).Entity;
                _context.SaveChanges();
                return entity;
            }
            public Category Update(Category category)
            {
                EntityEntry<Category> entity = _context.Categories.Update(category);
                _context.SaveChanges();
                return entity.Entity;
            }
            public IList<Category> FindAll()
            {
                return _context.Categories.ToList();
            }
            public Category FindById(int id)
            {
                return _context.Categories.Find(id);
            }
            

               
            
        }
    }


