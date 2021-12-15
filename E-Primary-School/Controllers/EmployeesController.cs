using Microsoft.AspNetCore.Mvc;

namespace E_Primary_School.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
