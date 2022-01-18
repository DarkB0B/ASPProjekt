using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AspProj10.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProj10.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class ApiPostController : ControllerBase
    {
        private ICrudPostRepository postRepository;

        public ApiPostController(ICrudPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        
    }
}
