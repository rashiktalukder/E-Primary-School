using E_Primary_School.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace E_Primary_School.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Employee employee { get; set; }

        public EmployeesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InsertEmployee(int? id)
        {
            
            Employee employee = new Employee();
            if(id== null)
            {
                //Create
                return View(employee);

            }
            //update
            employee = _db.Employees.FirstOrDefault(x => x.Id == id);
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertEmployee()
        {

            Employee employee = new Employee();
            if (ModelState.IsValid)
            {
                if(employee.Id==0)
                {
                    //Create
                    _db.Employees.Add(employee);
                }
                else
                {
                    _db.Employees.Update(employee);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
                
                return View(employee);

            }
            /*//update
            employee = _db.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }*/
            return View(employee);
        }



        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Employees.ToListAsync() });
        }
    }
    #endregion
}
