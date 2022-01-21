using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AspProj10.Models;
using Microsoft.AspNetCore.Http;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/*
namespace AspProj10.Controllers
{
    [Route("api/posts")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    
    public class ApiPostController : ControllerBase
    {
        private ICrudPostRepository postRepository;
        private ICrudCategoryRepository categoryRepository;
        
        public ApiPostController(ICrudPostRepository postRepository, ICrudCategoryRepository categoryRepository)
        {
            this.postRepository = postRepository;
            this.categoryRepository = categoryRepository;
        }

             
        public IActionResult AddPost()
        {
            Kat = categoryRepository.FindAll();
            return View();
        }
        public IActionResult List()
        {
            ViewBag.CR = categoryRepository;
            return View("List", postRepository.FindAll());
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
            ViewBag.CR = categoryRepository;
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
                return LocalRedirect("/Post/Details/" + editedPost.Id);
            }
            else
            {
                return View("EditPost");
            }
        }

    }
}
*/