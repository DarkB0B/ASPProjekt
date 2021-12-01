using ASPProjekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProjekt.Controllers
{
    public class PostController : Controller
    {
        static List<Post> posts = new List<Post>();
        private static int index = 0;
        public IActionResult Index()
        {
            return View(posts);
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
                index++;
                Post.Id = index;
                posts.Add(Post);
                Post.DateOfAdd = DateTime.Now;
                return View("ConfirmPost");
            }
            else
            {
                return View("AddPost");
            }
        }

        public IActionResult List()
        {
            return View(posts);
        }

        public IActionResult EditForm(int id)
        {
            return View(FindPost(id));
        }
        [HttpPost]
        public IActionResult Edit(Post editedPost)
        {
            if (ModelState.IsValid)
            {
                Post originalPost = FindPost(editedPost.Id);
                originalPost.Title = editedPost.Title;
                return View("List", posts);
            }
            else
            {
                return View("EditPost");
            }
        }
        public IActionResult DeleteConfirm(int id)
        {
            return View(FindPost(id));
        }
        public IActionResult Delete(int id)
        {
            posts.Remove(FindPost(id));
            return View("List", posts);
        }

        public Post FindPost(int id)
        {
            foreach(var post in posts)
            {
                if (post.Id == id)
                {
                    return post;
                }
            }
            throw new Exception("Taki Post Nie Istnieje");
        }
    }
}
