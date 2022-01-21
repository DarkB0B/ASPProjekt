using System.Collections.Generic;

namespace AspProj10.Models
{
    public class MemoryPostRepository : ICrudPostRepository

    {
        private Dictionary<int, Post> Posts = new Dictionary<int, Post>();
        private Dictionary<int, Category> Categories = new Dictionary<int, Category>();
        private Dictionary<int, Comment> Comments = new Dictionary<int, Comment>();



        public MemoryPostRepository()
        {

        }
            public Post Add(Post post)
            {
                throw new System.NotImplementedException();
            }

            public void Delete(int id)
            {
                throw new System.NotImplementedException();
            }

            public IList<Post> FindAll()
            {
                throw new System.NotImplementedException();
            }

            public Post FindById(int id)
            {
                throw new System.NotImplementedException();
            }

            public IList<Post> FindPage(int page, int size)
            {
                throw new System.NotImplementedException();
            }

            public void Like(int id)
            {
                throw new System.NotImplementedException();
            }

            public Post Update(Post post)
            {
                throw new System.NotImplementedException();
            }
        }
    
}
