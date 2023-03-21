namespace KP11WebAPI.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        ViewData["Message"] = "Главная";
        return View();
    }
}