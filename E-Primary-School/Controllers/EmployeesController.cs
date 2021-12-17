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
        public IActionResult InsertEmployee(int ? id)
        {
            Employee employee = new Employee();
            if(id == null)
            {
                return View(Employee);
            }
            employee = _db.Employees.FirstOrDefault(x => x.Id == id);
            if(employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (Employee.Id == 0)
                {
                    _db.Employees.Add(employee);
                }
                else
                {
                    _db.Employees.Update(employee);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Employee);
        }



        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Employees.ToListAsync() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var employyeFromDb = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if(Equals(employyeFromDb, null))
            {
                return Json(new { success = false, message = "error " });
            }
            _db.Employees.Remove(employyeFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Successfully Deleted" });
        }
        #endregion
    }

}
