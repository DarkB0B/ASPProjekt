using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace AspProj10.Models
{
    public interface ICrudPostRepository
    {
        Post AddP(Post post);

        void DeleteP(int id);

        Post UpdateP(Post post);

        Post FindByIdP(int id);

        void LikeP(int id);

        IList<Post> FindAllP();

        
    }
  

}
