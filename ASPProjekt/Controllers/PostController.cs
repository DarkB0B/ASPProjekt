﻿using ASPProjekt.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjekt.Controllers
{
    public class PostController : Controller
    {
        private ICRUDPostRepository posts;
        

        public PostController(ICRUDPostRepository posts)
        {
            this.posts = posts;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddForm()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Add(Post Post)
        {
            if (ModelState.IsValid)
            {
                
                Post = posts.Add(Post);
                return View("ConfirmPost", Post);
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            posts.Delete(id);
            return View("List", posts.FindAll());
        }
        public IActionResult EditForm(int id)
        {
            return View(posts.FindById(id));
        }
        public IActionResult List()
        {
            return View(posts);
        }
        public IActionResult Edit(Post editedPost)
        {
            if(ModelState.IsValid)
            {
                Post originalPost = posts.FindById(editedPost.Id);
                originalPost.Title = editedPost.Title;
                return View("List", posts);
            }
            else
            {
                return View("EditForm");
            }
        }
        public IActionResult DeleteConfirm(int id)
        {
            return View(posts.FindById(id));
        }
        
        
    }
}
  