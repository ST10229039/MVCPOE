using Microsoft.AspNetCore.Mvc;

namespace MVCPOE.Controllers
{
    public class ProgrammeManager : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
