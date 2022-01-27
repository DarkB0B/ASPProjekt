using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace AspProj10.Models
             {
            public interface ICrudCommentRepository
              {
            Comment AddCo(Comment comment);

            void DeleteCo(int id);

            Comment UpdateCo(Comment comment);
    
            Comment FindByIdCo(int id);

            



            IList<Comment> FindAllCo();

            
        }
       
    }


