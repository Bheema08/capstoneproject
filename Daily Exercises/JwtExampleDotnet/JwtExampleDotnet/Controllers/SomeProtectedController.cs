using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtExampleDotnet.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SomeProtectedController : Controller
    {
       
        //public class SomeProtectedController : ControllerBase
        //{
            [HttpGet]
            public IActionResult GetProtectedData()
            {
                return Ok(new { message = "This is protected data" });
            }
        }
    }
//}
