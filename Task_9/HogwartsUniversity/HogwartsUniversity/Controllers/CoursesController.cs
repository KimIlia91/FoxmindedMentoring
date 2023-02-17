using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HogwartsUniversity.Data;
using HogwartsUniversity.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using HogwartsUniversity.Serviсes.ServiceInterfaces;

namespace HogwartsUniversity.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: Courses 
        public async Task<IActionResult> Index()
        {
            var courseList = await _courseService.GetAllAsync();
            return View(courseList);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return NotFound();
            var groupsOfCourse = await _courseService.GetGroupsOfCourseAsync(id);
            if (groupsOfCourse is null) return NotFound();
            return View(groupsOfCourse);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                await _courseService.CreateAsync(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return NotFound();
            var courseToUpdate = await _courseService.GetByIdAsync(id);
            if (courseToUpdate is null) return NotFound();
            return View(courseToUpdate);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var courseToUpdate = await _courseService.GetByIdAsync(id);
            if (courseToUpdate is null) return NotFound();

            if (await TryUpdateModelAsync<Course>(courseToUpdate, "", 
                c => c.Name, c => c.Description))
            {
                try
                {
                    await _courseService.UpdateAsync(courseToUpdate);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again!.");
                }
            }

            return View(courseToUpdate);
        }

        //GET: /Courses/Delete/CourseId
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return NotFound();
            var courseToDelete = await _courseService.GetByIdAsync(id);
            if (courseToDelete is null) return NotFound();
            return View(courseToDelete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseToDelete = await _courseService.GetByIdAsync(id);
            if (courseToDelete is null) return NotFound();
            try
            {
                await _courseService.DeleteAsync(courseToDelete);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
    }
}
