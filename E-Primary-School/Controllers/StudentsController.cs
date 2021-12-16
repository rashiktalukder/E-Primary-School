using E_Primary_School.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace E_Primary_School.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Students students { get; set; }

        public StudentsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            students = new Students();
            if(id== null)
            {
                //create req
                return View(students);
            }
            else
            {
                //update
                students = _db.Students.FirstOrDefault(u => u.Id == id);
                if(students==null)
                {
                    return NotFound();
                }
                return View(students);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if(ModelState.IsValid)
            {
                if(students.Id==0)
                {
                    //create
                    _db.Students.Add(students);
                }
                else
                {
                    _db.Students.Update(students);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students);
            

        }

        #region API Calls

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Students.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var stdFromDb = await _db.Students.FirstOrDefaultAsync(u=>u.Id==id);
            if(stdFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _db.Students.Remove(stdFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Deleted successfully" });
        }

        #endregion
    }
}
