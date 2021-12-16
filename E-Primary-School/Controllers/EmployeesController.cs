using E_Primary_School.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_Primary_School.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Employee Employee { get; set; }

        public EmployeesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InsertEmployee()
        {
            return View(Employee);
        }
        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Employees.ToListAsync() });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(employee);
              
                _db.SaveChanges();
            }
            return View(Employee);
        }
    }
    #endregion
}
