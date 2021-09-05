using Microsoft.AspNetCore.Mvc;

namespace BookApi.Web.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {

    }
}
