using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.IdentityServer.API1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Course.IdentityServer.API2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetPicture()
        {
            var pictures = new List<Picture>()
            {
                new Picture{Id = 1,Path = "gooles.jpeg"},
                new Picture{Id = 2,Path = "gooles.jpeg"}
            };
            return Ok(pictures);
        }
    }
}
