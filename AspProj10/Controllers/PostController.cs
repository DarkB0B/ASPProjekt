using Microsoft.AspNetCore.Mvc;
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
        public PostController(ICrudPostRepository postRepository)
        {
            this.postRepository = postRepository;
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
        [HttpPost]
        public IActionResult Add(Post post)
        {
            DateTime datenow = DateTime.Now;
           //   if (ModelState.IsValid)
          //   {
            post.DateOfAdd = datenow;
            postRepository.Add(post);
            return View("ConfirmPost", post);
           //    }
            //   return View();
        }
        public IActionResult Delete(int id)
        {
            if (id > 0 & id != null) 
            { 
            postRepository.Delete(id);
            return View("List", postRepository.FindAll());
            }
            else
            {
                return View("List");
            }
        
        }
        public IActionResult EditPost(int id)
        {
            return View(postRepository.FindById(id));
        }
        public IActionResult Edit(Post editedPost)
        {
            if (ModelState.IsValid)
            {
                Post originalPost = postRepository.FindById(editedPost.Id);
                originalPost.Title = editedPost.Title;
                return View("List", postRepository);
            }
            else
            {
                return View("EditForm");
            }
        }
        public IActionResult DeleteConfirm(int id)
        {
            return View(postRepository.FindById(id));
        }
    }
}
