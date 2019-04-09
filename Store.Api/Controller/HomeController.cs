using Microsoft.AspNetCore.Mvc;

namespace Store.Api.Controllers
{

    [Route("")]
    public class HomeController : Controller
    {
        public string Get(){
            return "Hello World";
        }
    }
}