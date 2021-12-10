using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPProjekt.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set}
    }
    public class EFPostRepository : IPostRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public EFPostRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IQueryable<Post> Posts => _applicationDbContext.Posts;
        public IQueryable<Autrhor> Authors => _applicationDbContext.Authors;
        
    }
}
