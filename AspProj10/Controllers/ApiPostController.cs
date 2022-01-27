using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AspProj10.Models;
using Microsoft.AspNetCore.Http;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProj10.Controllers
{
    [Route("api/Posts")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public class ApiPostController : ControllerBase
    {
        private ICrudPostRepository postRepository;


        public ApiPostController(ICrudPostRepository postRepository)
        {
            this.postRepository = postRepository;

        }

        [HttpDelete]
        [Route("{id?}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                postRepository.DeleteP(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Add([FromBody] Post post)
        {
            if (ModelState.IsValid)
            {
                Post post1 = postRepository.AddP(post);
                return new CreatedResult($"/api/Posts/{post1.Id}", post);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("{id?}")]
        public IActionResult Get(int id)
        {
            Post post = postRepository.FindByIdP(id);
            if (post != null)
            {
                return new OkObjectResult(post);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public List<Post> GetAll()
        {
            return postRepository.FindAllP().ToList();
        }

    }
}
