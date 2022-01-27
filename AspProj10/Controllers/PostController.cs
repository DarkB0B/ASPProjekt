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

        private ICrudRepository _repository;
        private readonly IWebHostEnvironment hostEnvironment;

        public PostController(ICrudRepository _repository, IWebHostEnvironment hostEnvironment)
        {
            this._repository = _repository;
            this.hostEnvironment = hostEnvironment;
        }

        // Post{
        public IActionResult Details(int id)
        {
            ViewModel model = new ViewModel();
            model.post = _repository.FindByIdP(id);
            model.Comments = (List<Comment>)_repository.FindAllCo();
            // ViewBag.id = id;
            return View(model);

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddPost()
        {
            ViewBag.Kat = _repository.FindAllC();
            return View();
        }
        public IActionResult List()
        {
            ViewBag.CR = _repository;
            return View("List", _repository.FindAllP());
        }
        public IActionResult Like(int id)
        {
            var post = _repository.FindByIdP(id);
            if (id > 0)
            {
                _repository.LikeP(id);
                return LocalRedirect("/Post/Details/" + post.Id);
            }
            else
            {
                return LocalRedirect("/Post/Details/" + post.Id);
            }
        }
        [HttpPost]
        public IActionResult AddP(Post post)
        {
            if (ModelState.IsValid)
            {
                //zapisz zdjęcie do www.root/image{
                string wwwRootPath = hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(post.ImageFile.FileName);
                string extension = Path.GetExtension(post.ImageFile.FileName);
                post.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    post.ImageFile.CopyTo(fileStream);
                }
                // }

                DateTime datenow = DateTime.Now;

                post.LikeAmmount = 0;
                post.DateOfAdd = datenow;
                _repository.AddP(post);
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("List");
            }
            //   return View();
        }
        [Authorize]
        public IActionResult DeleteP(int id)
        {
            var post = _repository.FindByIdP(id);
            //usuń zdjęcie z folderu{

            var imagePath = Path.Combine(hostEnvironment.WebRootPath, "image", post.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            // }
            ViewBag.CR = _repository;
            if (id > 0)
            {
                _repository.DeleteP(id);
                return View("List", _repository.FindAllP());
            }
            else
            {
                return View("List");
            }

        }
        [Authorize]
        public IActionResult DeletePost(int id)
        {
            return View(_repository.FindByIdP(id));
        }
        [Authorize]
        public IActionResult EditPost(int id)
        {
            return View(_repository.FindByIdP(id));
        }
        [Authorize]
        public IActionResult EditP(Post editedPost)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateP(editedPost);
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


            _repository.AddC(category);
            return View("ConfirmCategory", category);
            //    }
            //   return View();
        }
        [Authorize]
        public IActionResult DeleteC(int id)
        {
            if (id > 0)
            {
                _repository.DeleteC(id);
                return View("CatList", _repository.FindAllC());
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
            return View("CatList", _repository.FindAllC());
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

            _repository.AddCo(comment);
            return LocalRedirect("/Post/Details/" + comment.PostId);
            //    }
            //   return View();
        }
        [Authorize]
        public IActionResult DeleteCo(int id)
        {
            var com = _repository.FindByIdCo(id);
            if (id > 0)
            {

                _repository.DeleteCo(id);
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
