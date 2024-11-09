using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PD_212_MVC.Data;
using PD_212_MVC.Models;

namespace PD_212_MVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AcademyContext _context;

        public StudentsController(AcademyContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["LastNameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "last_name_desc" : "";
            ViewData["FirstNameSortParam"] = sortOrder == "FirstName" ? "first_name_desc" : "FirstName";
            ViewData["MiddleNameSortParam"] = sortOrder == "MiddleName" ? "middle_name_desc" : "MiddleName";
            ViewData["BirthDateSortParam"] = sortOrder == "BirthDate" ? "birth_date_desc" : "BirthDate";
            ViewData["CurrentFilter"] = searchString;

            IQueryable<Student> students = from s in _context.Students select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.last_name.Contains(searchString)
                                       || s.first_name.Contains(searchString)
                                       || s.middle_name!.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "last_name_desc":
                    students = students.OrderByDescending(t => t.last_name);
                    break;
                case "FirstName":
                    students = students.OrderBy(t => t.first_name);
                    break;
                case "first_name_desc":
                    students = students.OrderByDescending(t => t.first_name);
                    break;
                case "MiddleName":
                    students = students.OrderBy(t => t.middle_name);
                    break;
                case "middle_name_desc":
                    students = students.OrderByDescending(t => t.middle_name);
                    break;
                case "BirthDate":
                    students = students.OrderBy(t => t.birth_date);
                    break;
                case "birth_date_desc":
                    students = students.OrderByDescending(t => t.birth_date);
                    break;
                default:
                    students = students.OrderBy(t => t.last_name);
                    break;
            }

            return View(await students.AsNoTracking().ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.stud_id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("stud_id,last_name,first_name,middle_name,birth_date")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("stud_id,last_name,first_name,middle_name,birth_date")] Student student)
        {
            if (id != student.stud_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.stud_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.stud_id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.stud_id == id);
        }
    }
}
