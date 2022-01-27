using System;
using System.Collections.Generic;
using System.Linq;

namespace AspProj10.Models
{
    public class MemoryPostRepository : ICrudRepository

    {
        private Dictionary<int, Post> Posts = new Dictionary<int, Post>();
        private Dictionary<int, Category> Categories = new Dictionary<int, Category>();
        private Dictionary<int, Comment> Comments = new Dictionary<int, Comment>();
        private int PostIndex = 0;
        private int CategoryIndex = 0;
        private int CommentIndex = 0;

        public MemoryPostRepository()
        {
            Category category = new Category() { CategoryName = "Sport" };
            this.AddC(category);
            Post post = new Post()
            {
                Title = "Titel1",
                Description = "Description1",
                DateOfAdd = DateTime.Now,
                CategoryId = category.Id,
                LikeAmmount = 0,
                
            };
            this.AddP(post);           
            Comment comment = new Comment() { Commentt = "Comment1", PostId = post.Id};
            this.AddCo(comment);           
        }

        public Category AddC(Category category)
        {
            ++CategoryIndex;
            category.Id = CategoryIndex;
            Categories.Add(category.Id, category);
            return category;
        }

        public Post AddP(Post post)
        {
            ++PostIndex;
            post.Id = PostIndex;
            Posts.Add(post.Id, post);
            return post;
        }
        public Comment AddCo(Comment comment)
        {
            ++CommentIndex;
            comment.Id = CommentIndex;
            Comments.Add(comment.Id, comment);
            return comment;

        }
        
        public void DeleteP(int id)
        {
            Posts.Remove(id);
        }
        public void DeleteC(int id)
        {
            Categories.Remove(id);
        }
        public void DeleteCo(int id)
        {
            Comments.Remove(id);
        }
        public IList<Post> FindAllP()
        {
            return Posts.Values.ToList();
        }       
        public IList<Category> FindAllC()
        {
            return Categories.Values.ToList();
        }

        public Post FindByIdP(int id)
        {
            Posts.TryGetValue(id, out Post post);
            return post;
        }
        public Category FindByIdC(int id)
        {
            Categories.TryGetValue(id, out Category category);
            return category;
        }

       

        public Post UpdateP(Post post)
        {
            int id = post.Id;
            if (!Posts.ContainsKey(id))
            {
                return null;
            }
            Posts.Remove(id);
            post.Id = id;
            Posts.Add(id, post);
            return FindByIdP(id);
        }

        

        public void LikeP(int id)
        {
            Posts.TryGetValue(id, out Post post);
            post.LikeAmmount += 1;
        }

        public Comment UpdateCo(Comment comment)
        {
            int id = comment.Id;
            if (!Comments.ContainsKey(id))
            {
                return null;
            }
            Comments.Remove(id);
            comment.Id = id;
            Comments.Add(id, comment);
            return FindByIdCo(id);
        }

        public Comment FindByIdCo(int id)
        {
            Comments.TryGetValue(id, out Comment comment);
            return comment;
        }

        public IList<Comment> FindAllCo()
        {
            return Comments.Values.ToList();
        }

       
      

        public Category UpdateC(Category category)
        {
            int id = category.Id;
            if (!Categories.ContainsKey(id))
            {
                return null;
            }
            Categories.Remove(id);
            category.Id = id;
            Categories.Add(id, category);
            return FindByIdC(id);
        }
    }

}
