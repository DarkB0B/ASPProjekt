using Microsoft.AspNetCore.Mvc;
using AspProj10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AspProj10.Controllers
{
    [DisableBasicAuthentication]

    public class PostController : Controller
    {

        private ICrudPostRepository postRepository;
        private ICrudCategoryRepository categoryRepository;
        private ICrudCommentRepository commentRepository;
        private readonly IWebHostEnvironment hostEnvironment;

        public PostController(ICrudPostRepository postRepository, ICrudCategoryRepository categoryRepository, ICrudCommentRepository commentRepository, IWebHostEnvironment hostEnvironment)
        {
            this.postRepository = postRepository;
            this.categoryRepository = categoryRepository;
            this.commentRepository = commentRepository;
            this.hostEnvironment = hostEnvironment;
        }

        // Post{
        public IActionResult Details(int id)
        {
            ViewModel model = new ViewModel();
            model.post = postRepository.FindById(id);
            model.Comments = (List<Comment>)commentRepository.FindAll();
            // ViewBag.id = id;
            return View(model);
            
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddPost()
        {
            ViewBag.Kat = categoryRepository.FindAll();
            return View();
        }
        public IActionResult List()
        {
            ViewBag.CR = categoryRepository;
            return View("List", postRepository.FindAll());
        }
        public IActionResult Like(int id)
        {
            var post = postRepository.FindById(id);
            if (id > 0)
            {
                postRepository.Like(id);
                return LocalRedirect("/Post/Details/" + post.Id); 
            }
            else
            {
                return LocalRedirect("/Post/Details/" + post.Id); 
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddP([Bind("Id,Title,ImageFile,CategoryId,Description")]Post post)
        {
            //zapisz zdjęcie do www.root/image{
            string wwwRootPath = hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(post.ImageFile.FileName);
            string extension = Path.GetExtension(post.ImageFile.FileName);
            post.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            string path = Path.Combine(wwwRootPath + "/Image", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await post.ImageFile.CopyToAsync(fileStream);
            }           
            // }

            DateTime datenow = DateTime.Now;
            //   if (ModelState.IsValid)
            //   {
            post.LikeAmmount = 0;
            post.DateOfAdd = datenow;
            postRepository.Add(post);
            return RedirectToAction("List");
            //    }
            //   return View();
        }
        [Authorize]
        public IActionResult DeleteP(int id)
        {
            var post = postRepository.FindById(id);
            //usuń zdjęcie z folderu{

            var imagePath = Path.Combine(hostEnvironment.WebRootPath, "image", post.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            // }
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
        [Authorize]
        public IActionResult DeletePost(int id)
        {
            return View(postRepository.FindById(id));
        }
        [Authorize]
        public IActionResult EditPost(int id)
        {
            return View(postRepository.FindById(id));
        }
        [Authorize]
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

        // } Post

        // Category{ 
        [Authorize]
        public IActionResult AddCategory()
        {
            return View();
        }
        [Authorize]
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
        [Authorize]
        public IActionResult DeleteC(int id)
        {
            if (id > 0)
            {
                categoryRepository.Delete(id);
                return View("CatList", categoryRepository.FindAll());
            }
            else
            {
                return View("CatList");
            }

        }
        [Authorize]
        public IActionResult CategoryActions()
        {
            return View();
        }
        [Authorize]
        public IActionResult CatList()
        {
            return View("CatList", categoryRepository.FindAll());
        }
        // } Category
        // Comment{

        public IActionResult AddComment(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddCo(Comment comment)
        {

            //  comment.PostId = id;
            //   if (ModelState.IsValid)
            //   {

            commentRepository.Add(comment);
            return LocalRedirect("/Post/Details/" + comment.PostId);
            //    }
            //   return View();
        }
        [Authorize]
        public IActionResult DeleteCo(int id)
        {
            var com = commentRepository.FindById(id);
            if (id > 0)
            {

                commentRepository.Delete(id);
                return LocalRedirect("/Post/Details/" + com.PostId);
            }
            else
            {
                return LocalRedirect("/Post/Details/" + com.PostId);
            }

        }


        // } Comment

    }
}
