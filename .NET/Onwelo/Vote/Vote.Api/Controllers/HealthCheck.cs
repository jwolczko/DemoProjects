using Microsoft.AspNetCore.Mvc;

namespace Vote.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheck : ControllerBase
    {
        [HttpGet]
        public bool IsAlive()
        {
            return true;
        }
    }
}
