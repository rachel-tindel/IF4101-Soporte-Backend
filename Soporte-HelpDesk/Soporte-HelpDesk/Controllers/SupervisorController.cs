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
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult<IEnumerable<Supervisor>>> GetSupervisors()
        {
            try {
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
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
            
        }

        [Route("[action]/{id}")]
        [EnableCors("GetAllPolicy")]
        [HttpGet]
        public async Task<ActionResult<Supervisor>> GetSupervisor(int id)
        {
            try {
                  var supervisor = await _context.Supervisors.FindAsync(id);

                  if (supervisor == null)
                  {
                    return NotFound();
                  }

               return supervisor;
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
  
        }

        // GET: SupervisorController/Details/5
        [Route("[action]/{id}")]
        [EnableCors("GetAllPolicy")]
        [HttpPut]
        public async Task<IActionResult> PutSupervisor(int id, Supervisor supervisor) 
        {
            if (id != supervisor.IdSupervisor)
            {
                return BadRequest();
            }

            _context.Entry(supervisor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupervisorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [Route("[action]")]
        [EnableCors("GetAllPolicy")]
        [HttpPost]
        public async Task<ActionResult<Supervisor>> PostSupervisor(Supervisor supervisor)
        {
            try {
                _context.Supervisors.Add(supervisor);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSupervisor", new { id = supervisor.IdSupervisor }, supervisor);
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest();

            }
        }

        private bool SupervisorExists(int id)
        {
            return _context.Supervisors.Any(e => e.IdSupervisor == id);
        }

        private bool SupervisorExists(string email)
        {
            return _context.Supervisors.Any(e => e.EmailSupervisor == email);
        }

        [Route("[action]/{email}/{password}")]
        [EnableCors("GetAllPolicy")]
        [HttpGet]
        public async Task<ActionResult<Supervisor>> GetLogin(string email, string password)
        {

            try
            {

                List<Supervisor> supervisorsList = await _context.Supervisors.Include(s => s.IdIssueNavigation).Include(s => s.IdNoteNavigation).Select(supervisorItem => new Supervisor()
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

                foreach (Supervisor supervisors in supervisorsList)
                {
                    if (supervisors.EmailSupervisor.Equals(email) && supervisors.Password.Equals(password))
                    {
                         return supervisors;
                    } 
                }

                return BadRequest();
               
            }
            catch (DbUpdateConcurrencyException)
            {
               
                if (!SupervisorExists(email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }
    }
}
