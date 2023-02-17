using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HogwartsUniversity.Data;
using HogwartsUniversity.Models;
using HogwartsUniversity.Serviсes.ServiceInterfaces;

namespace HogwartsUniversity.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var studentsList = await _studentService.GetAllAsync();
            return View(studentsList);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return NotFound();
            var student = await _studentService.GetStudentDetailsAsync(id);
            if (student is null) return NotFound();
            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create(int? id)
        {
            if (id is null) return NotFound();
            var viewStudent = new Student { GroupId = (int)id };
            return View(viewStudent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("GroupId,FirstName,LastName")] Student student)
        {
            student.GroupId = id;

            if (ModelState.IsValid)
            {
                await _studentService.CreateAsync(student);
                return Redirect($"/Groups/Details/{student.GroupId}");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return NotFound();
            var studentToUpdate = await _studentService.GetByIdAsync(id);
            ViewData["GroupId"] = await _studentService.GetGroupSelectListAsync();
            if (studentToUpdate is null) return NotFound();
            return View(studentToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var studentToUpdate = await _studentService.GetByIdAsync(id);
            if (studentToUpdate is null) return NotFound();

            if (await TryUpdateModelAsync<Student>(studentToUpdate, "",
                s => s.LastName, s => s.FirstName, s => s.GroupId))
            {
                try
                {
                    await _studentService.UpdateAsync(studentToUpdate);
                    return Redirect($"/Groups/Details/{studentToUpdate.GroupId}");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again!.");
                }
            }

            return View(studentToUpdate);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return NotFound();
            var studentToDelete = await _studentService.GetStudentDetailsAsync(id);
            if (studentToDelete is null) return NotFound();
            return View(studentToDelete);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentToDelete = await _studentService.GetByIdAsync(id);

            try
            {
                await _studentService.DeleteAsync(studentToDelete);
                return Redirect($"/Groups/Details/{studentToDelete.GroupId}");
            }
            catch (DbUpdateException ex)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
    }
}
