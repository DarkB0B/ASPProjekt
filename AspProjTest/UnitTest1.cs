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
        [Fact]
        public void AddComment()
        {
            ICrudRepository Repository  = new MemoryPostRepository();
            IWebHostEnvironment hostEnvironment = new webhost();
            PostController controller = new PostController(Repository, hostEnvironment);
            var comment = new Comment() { Commentt="Commenttttttttttttt", PostId='1'};
            controller.AddCo(comment);
            comment.Id = 2;
            Assert.Equal<Comment>(comment, Repository.FindByIdCo(2));

        }
        [Fact]
        public void AddCategory()
        {
            ICrudRepository Repository = new MemoryPostRepository();
            IWebHostEnvironment hostEnvironment = new webhost();
            PostController controller = new PostController(Repository, hostEnvironment);
            var category = new Category() { CategoryName = "Commenttttttttttttt"};
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
        public void DeleteComment()
        {
            ICrudRepository Repository = new MemoryPostRepository();
            IWebHostEnvironment hostEnvironment = new webhost();
            PostController controller = new PostController(Repository, hostEnvironment);

            controller.DeleteCo(1);
            Assert.Null(Repository.FindByIdCo(1));

        }
        [Fact]
        public void IsNullNull()
        {
            Assert.Null(null);
        }
        
    }
}
