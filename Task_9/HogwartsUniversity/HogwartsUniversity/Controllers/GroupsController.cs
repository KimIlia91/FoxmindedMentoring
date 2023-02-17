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
    public class GroupsController : Controller
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            var universityContext = await _groupService.GetAllAsync();
            return View(universityContext);
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return NotFound();
            var group = await _groupService.GetStudentsOfGroupAsync(id);
            if (group is null) return NotFound();
            return View(group);
        }

        // GET: Groups/Create/courseId
        public IActionResult Create(int? id)
        {
            if (id is null) return NotFound();
            var newGroup = new Group { CourseId = (int)id };
            return View(newGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("CourseId,Name")] Group group)
        {
            group.CourseId = id;

            if (ModelState.IsValid)
            {
                await _groupService.CreateAsync(group);
                return Redirect($"/Courses/Details/{group.CourseId}");
            }

            return View(group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return NotFound();
            var groupToUpdate = await _groupService.GetByIdAsync(id);
            if (groupToUpdate is null) return NotFound();
            return View(groupToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var groupToUpdate = await _groupService.GetByIdAsync(id);
            if (groupToUpdate is null) return NotFound();

            if (await TryUpdateModelAsync<Group>(groupToUpdate, "", g => g.Name))
            {
                try
                {
                    await _groupService.UpdateAsync(groupToUpdate);
                    return Redirect($"/Courses/Details/{groupToUpdate.CourseId}");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again!.");
                }
            }

            return View(groupToUpdate);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return NotFound();
            var groupToDelete = await _groupService.GetByIdAsync(id);
            if (groupToDelete is null) return NotFound();
            return View(groupToDelete);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id is null) return NotFound();
            var groupToDelete = await _groupService.GetByIdAsync(id);
            if (groupToDelete is null) return NotFound();
            if (groupToDelete.Students.Count > 0) return View(groupToDelete);

            try
            {
                await _groupService.DeleteAsync(groupToDelete);
                return Redirect($"/Courses/Details/{groupToDelete.CourseId}");
            }
            catch (DbUpdateException ex)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
    }
}
