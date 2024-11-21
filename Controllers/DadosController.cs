using Microsoft.AspNetCore.Mvc;

namespace RotasParaOFuturo.Controllers
{
    public class DadosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
