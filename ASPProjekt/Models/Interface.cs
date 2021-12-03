using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace ASPProjekt.Models
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
       base(options)
        { }
        public DbSet<Post> Posts { get; set; }
    }
    public class EFProductRepository : IPostRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public EFProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IQueryable<Post> Posts => _applicationDbContext.Posts;


    }
}
