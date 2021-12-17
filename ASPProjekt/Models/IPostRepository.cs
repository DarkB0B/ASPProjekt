using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASPProjekt.Models
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get;  }
    }
}
