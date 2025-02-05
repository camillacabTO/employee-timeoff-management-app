using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeTimeOffManagementApp.Data;
using EmployeeTimeOffManagementApp.Models.LeaveTypes;
using EmployeeTimeOffManagementApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeTimeOffManagementApp.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class LeaveTypesController(ILeaveTypesServices leaveTypesServices) : Controller
    {
        private readonly ILeaveTypesServices _leaveTypesServices = leaveTypesServices;

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var viewModel = await _leaveTypesServices.GetAllAsync();
            return View(viewModel);
        }
 
        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var leaveType = await _leaveTypesServices.GetByIdAsync<LeaveTypesReadOnlyVM>(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // public async Task<IActionResult> Create([Bind("Id,Name,NumberOfDays")] LeaveType leaveType)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypesCreateVM leaveTypeFromForm)
        {
            if (await _leaveTypesServices.LeaveTypeExists(leaveTypeFromForm.Name))
            {
                ModelState.AddModelError(nameof(leaveTypeFromForm.Name), "Leave type already exists");
            }
            if (ModelState.IsValid)
            {
                await _leaveTypesServices.CreateAsync(leaveTypeFromForm);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeFromForm);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var leaveType = await _leaveTypesServices.GetByIdAsync<LeaveTypesEditVM>(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypesEditVM  leaveTypeFromForm)
        {
            if (id != leaveTypeFromForm.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    await _leaveTypesServices.UpdateAsync(leaveTypeFromForm);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_leaveTypesServices.LeaveTypeExists(leaveTypeFromForm.Id))
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
            return View(leaveTypeFromForm);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var leaveType = await _leaveTypesServices.GetByIdAsync<LeaveTypesReadOnlyVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        // Ovewrites the action name since the 3 methods have the same signature & name
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leaveTypesServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
