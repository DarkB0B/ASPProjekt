using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using AspProj10.Models;
using AspProj10.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace AspProjTest
{
    public class webhost : IWebHostEnvironment
    {
        public string WebRootPath { get; set; }
        public IFileProvider WebRootFileProvider { get; set; }
        public string ApplicationName { get; set; }
        public IFileProvider ContentRootFileProvider { get; set; }
        public string ContentRootPath { get; set; }
        public string EnvironmentName { get; set; }
    }
    public class UnitTest1
    {
        // Post Controller{
        [Fact]
        public void AddComment()
        {
            ICrudRepository Repository = new MemoryPostRepository();
            IWebHostEnvironment hostEnvironment = new webhost();
            PostController controller = new PostController(Repository, hostEnvironment);
            var comment = new Comment() { Commentt = "Com1", PostId = '1' };
            controller.AddCo(comment);
            comment.Id = 2;
            Assert.Equal<Comment>(comment, Repository.FindByIdCo(2));

        }
        [Fact]
        public void AddPost()
        {
            ICrudRepository Repository = new MemoryPostRepository();
            IWebHostEnvironment hostEnvironment = new webhost();
            PostController controller = new PostController(Repository, hostEnvironment);
            var post = new Post() { Title = "Titel", Description = "Desc", CategoryId = '1', LikeAmmount = '0' };
            controller.AddP(post);
            post.Id = 2;
            Assert.Equal<Post>(post, Repository.FindByIdP(2));

        }
        [Fact]
        public void AddCategory()
        {
            ICrudRepository Repository = new MemoryPostRepository();
            IWebHostEnvironment hostEnvironment = new webhost();
            PostController controller = new PostController(Repository, hostEnvironment);
            var category = new Category() { CategoryName = "Cat1" };
            controller.AddC(category);
            category.Id = 2;
            Assert.Equal<Category>(category, Repository.FindByIdC(2));

        }
        [Fact]
        public void DeleteCategory()
        {
            ICrudRepository Repository = new MemoryPostRepository();
            IWebHostEnvironment hostEnvironment = new webhost();
            PostController controller = new PostController(Repository, hostEnvironment);

            controller.DeleteC(1);
            Assert.Null(Repository.FindByIdC(1));

        }
        [Fact]
        public void DeletePost()
        {
            ICrudRepository Repository = new MemoryPostRepository();
            IWebHostEnvironment hostEnvironment = new webhost();
            PostController controller = new PostController(Repository, hostEnvironment);

            controller.DeleteP(1);
            Assert.Null(Repository.FindByIdP(1));

        }
        [Fact]
        public void DeleteComment()
        {
            ICrudRepository Repository = new MemoryPostRepository();
            IWebHostEnvironment hostEnvironment = new webhost();
            PostController controller = new PostController(Repository, hostEnvironment);

            controller.DeleteCo(1);
            Assert.Null(Repository.FindByIdCo(1));

        }

        [Fact]
        public void LikePost()
        {
            ICrudRepository Repository = new MemoryPostRepository();
            IWebHostEnvironment hostEnvironment = new webhost();
            PostController controller = new PostController(Repository, hostEnvironment);
            var post = new Post() { Title = "Titel", Description = "Desc", CategoryId = '1', LikeAmmount = '0' };
            controller.AddP(post);
            post.Id = 2;
            Repository.LikeP(2);

            Assert.Equal<int>(1, post.LikeAmmount);
        }
        [Fact]
        public void FindByIdPost()
        {
            ICrudRepository Repository = new MemoryPostRepository();
            IWebHostEnvironment hostEnvironment = new webhost();
            PostController controller = new PostController(Repository, hostEnvironment);

            var post = Repository.FindByIdP(1);

            Assert.NotNull(post);

        }
        [Fact]
        public void FindByIdComment()
        {
            ICrudRepository Repository = new MemoryPostRepository();
            IWebHostEnvironment hostEnvironment = new webhost();
            PostController controller = new PostController(Repository, hostEnvironment);

            var com = Repository.FindByIdC(1);

            Assert.NotNull(com);

        }
        [Fact]
        public void FindByIdCategory()
        {
            ICrudRepository Repository = new MemoryPostRepository();
            IWebHostEnvironment hostEnvironment = new webhost();
            PostController controller = new PostController(Repository, hostEnvironment);

            var cat = Repository.FindByIdCo(1);

            Assert.NotNull(cat);

        }
        //}
        // Api Tests{
        [Fact]
        public void AddPApi()
        {
            ICrudRepository Repository = new MemoryPostRepository();           
            ApiPostController controller = new ApiPostController(Repository);

            var post = new Post() { Title = "Titel", Description = "Desc", CategoryId = '1', LikeAmmount = '0' };
            controller.Add(post);           
            Assert.NotNull(post);

        }
        [Fact]
        public void DeletePApi()
        {
            ICrudRepository Repository = new MemoryPostRepository();
            ApiPostController controller = new ApiPostController(Repository);

           
            controller.Delete(1);
            var post = Repository.FindByIdP(1);
            Assert.Null(post);

        }
        
        //}
    }
}
