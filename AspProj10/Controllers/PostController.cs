﻿using Microsoft.AspNetCore.Mvc;
using AspProj10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspProj10.Controllers
{
    public class PostController : Controller
    {
        
        private ICrudPostRepository postRepository;
        private ICrudCategoryRepository categoryRepository;
        public PostController(ICrudPostRepository postRepository, ICrudCategoryRepository categoryRepository)
        {
            this.postRepository = postRepository;
            this.categoryRepository = categoryRepository;
        }
        
        // Post{
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddPost()
        {
            return View();
        }
        public IActionResult List()
        {          
            return View("List", postRepository.FindAll());
        }
        public IActionResult Like(Post post)
        {
            post.LikeAmmount += 1;
            return View();
        }
        [HttpPost]
        public IActionResult AddP(Post post)
        {   
            
            DateTime datenow = DateTime.Now;
            //   if (ModelState.IsValid)
            //   {
            post.LikeAmmount = 0;
            post.DateOfAdd = datenow;
            postRepository.Add(post);
            return View("ConfirmPost", post);
           //    }
            //   return View();
        }
        public IActionResult DeleteP(int id)
        {
            if (id > 0) 
            { 
            postRepository.Delete(id);
            return View("List", postRepository.FindAll());
            }
            else
            {
                return View("List");
            }
        
        }
        public IActionResult DeletePost(int id)
        {
            return View(postRepository.FindById(id));
        }
        public IActionResult EditPost(int id)
        {
            return View(postRepository.FindById(id));
        }
        public IActionResult EditP(Post editedPost)
        {
            if (ModelState.IsValid)
            {
                postRepository.Update(editedPost);
                return View("List", postRepository.FindAll());
            }
            else
            {
                return View("EditPost");
            }
        }
        
        // } Post

        // Category{ 

        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddC(Category category)
        {
            DateTime datenow = DateTime.Now;
            //   if (ModelState.IsValid)
            //   {
            
            
            categoryRepository.Add(category);
            return View("ConfirmCategory", category);
            //    }
            //   return View();
        }
        public IActionResult DeleteC(int id)
        {
            if (id > 0)
            {
                categoryRepository.Delete(id);
                return View("List", categoryRepository.FindAll());
            }
            else
            {
                return View("List");
            }

        }
        // } Category
    }
}