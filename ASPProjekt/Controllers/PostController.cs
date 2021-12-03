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
        static List<Post> post = new List<Post>();
        private static int index = 0;
        public IActionResult Index()
        {
            return View(post);
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
                post.Add(Post);
                return View("ConfirmBook", Post);
            }
            else
                return View("AddForm");

        }

        public IActionResult List()
        {
            return View(post);
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
                return View("List", post);
            }
            else
            {
                return View("EditForm");
            }
        }
        public IActionResult DeleteConfirm(int id)
        {
            return View(FindPost(id));
        }
        public IActionResult Delete(int id)
        {
            post.Remove(FindPost(id));
            return View("List", post);
        }

        public Post FindPost(int id)
        {
            foreach(var post in post)
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
