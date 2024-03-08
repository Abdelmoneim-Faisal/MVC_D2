using Microsoft.AspNetCore.Mvc;

namespace MVC_D2.Controllers
{
    public class ClientSideController : Controller
    {
        public IActionResult Address(string address)
        {
            if (address == "Cairo" || address == "Alex" || address == "Giza")
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}
