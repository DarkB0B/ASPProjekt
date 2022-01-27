using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace AspProj10.Models
    {
        public interface ICrudCategoryRepository
    {
            Category AddC(Category ctegory);

            void DeleteC(int id);

            Category UpdateC(Category category);

            Category FindByIdC(int id);

            



            IList<Category> FindAllC();

            
        }
     
    }


