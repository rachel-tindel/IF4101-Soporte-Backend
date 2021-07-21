using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soporte_HelpDesk.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soporte_HelpDesk.Controllers
{
    public class SupervisorController : Controller
    {

        private readonly IF4101_Project_SupportContext _context;

        public SupervisorController()
        {
            _context = new IF4101_Project_SupportContext();
        }

        [Route("[action]")]
        [EnableCors("GetAllPolicy")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supervisor>>> GetStudentsAngular()
        {
            return await _context.Supervisors.Include(s => s.IdIssueNavigation).Include(s => s.IdNoteNavigation).Select(supervisorItem => new Supervisor()
            {
                IdSupervisor = supervisorItem.IdSupervisor,
                DescriptionSupervisor = supervisorItem.DescriptionSupervisor,
                NameSupervisor = supervisorItem.NameSupervisor,
                FirstSurnameSupervisor = supervisorItem.FirstSurnameSupervisor,
                SecondSurnameSupervisor = supervisorItem.SecondSurnameSupervisor,
                EmailSupervisor = supervisorItem.EmailSupervisor,
                Password = supervisorItem.Password,
                IdIssueNavigation = supervisorItem.IdIssueNavigation,
                IdNoteNavigation = supervisorItem.IdNoteNavigation
            }).ToListAsync();
        }

        // GET: SupervisorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SupervisorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SupervisorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupervisorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupervisorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SupervisorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupervisorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupervisorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
