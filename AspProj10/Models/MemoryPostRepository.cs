using System;
using System.Collections.Generic;
using System.Linq;

namespace AspProj10.Models
{
    public class MemoryPostRepository : ICrudPostRepository

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
            this.Add(category);
            Post post = new Post()
            {
                Title = "Title1",
                Description = "Description1",
                DateOfAdd = DateTime.Now,
                CategoryId = category.Id,
                LikeAmmount = 0,
                ImageName = "nonexistant",
            };
            this.Add(post);
            this.AddPostToCategory(post.Id, category.Id);
            Comment comment = new Comment() { Commentt = "Comment1", PostId = post.Id};
            this.Add(comment);
            this.AddCommentToPost(comment.Id, post.Id);
        }

        private Category Add(Category category)
        {
            ++CategoryIndex;
            category.Id = CategoryIndex;
            Categories.Add(category.Id, category);
            return category;
        }

        public Post Add(Post post)
        {
            ++PostIndex;
            post.Id = PostIndex;
            Posts.Add(post.Id, post);
            return post;
        }
        public Comment Add(Comment comment)
        {
            ++CommentIndex;
            comment.Id = CommentIndex;
            Comments.Add(comment.Id, comment);
            return comment;

        }
        public void AddCommentToPost(int CommentId, int PostId)
        {
            Posts.TryGetValue(PostId, out Post post);
            Comments.TryGetValue(CommentId, out Comment comment);
            post.Comments.Add(comment);
        }
        public void AddPostToCategory(int PostId, int CategoryId)
        {
            Posts.TryGetValue(PostId, out Post post);
            Categories.TryGetValue(CategoryId, out Category category);
            category.Posts.Add(post);
        }
        public void Delete(int id)
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
        public IList<Post> FindAll()
        {
            return Posts.Values.ToList();
        }       
        public IList<Category> FindAllC()
        {
            return Categories.Values.ToList();
        }

        public Post FindById(int id)
        {
            Posts.TryGetValue(id, out Post post);
            return post;
        }
        public Category FindByIdC(int id)
        {
            Categories.TryGetValue(id, out Category category);
            return category;
        }

       

        public Post Update(Post post)
        {
            int id = post.Id;
            if (!Posts.ContainsKey(id))
            {
                return null;
            }
            Posts.Remove(id);
            post.Id = id;
            Posts.Add(id, post);
            return FindById(id);
        }

        

        public void Like(int id)
        {
            Posts.TryGetValue(id, out Post post);
            post.LikeAmmount += 1;
        }

        

        
    }

}
