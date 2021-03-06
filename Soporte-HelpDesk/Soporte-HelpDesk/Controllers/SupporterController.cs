using Microsoft.AspNetCore.Cors;
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
    public class SupporterController : Controller
    {
        private readonly Models.Entities.IF4101_Project_SupportContext _context;

        public SupporterController()
        {
            _context = new IF4101_Project_SupportContext();
        }

        [Route("[action]")]
        [EnableCors("GetAllPolicy")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supporter>>> GetSupporters()
        {
            try {

                return await _context.Supporters.Include(s => s.IdSupervisorNavigation).Include(s => s.IdIssueNavigation).Include(s => s.IdNoteNavigation).Select(supporterItem => new Supporter()
                {
                    IdSoporter = supporterItem.IdSoporter,
                    NameSupporter = supporterItem.NameSupporter,
                    FirstSurnameSupporter = supporterItem.FirstSurnameSupporter,
                    SecondSurnameSupporter = supporterItem.SecondSurnameSupporter,
                    EmailSupporter = supporterItem.EmailSupporter,
                    Password = supporterItem.Password,
                    IdSupervisorNavigation = supporterItem.IdSupervisorNavigation,
                    IdIssueNavigation = supporterItem.IdIssueNavigation,
                    IdNoteNavigation = supporterItem.IdNoteNavigation
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
        public async Task<ActionResult<Supporter>> GetSupporter (int id)
        {
            try
            {
                var supporter = await _context.Supporters.FindAsync(id);

                if (supporter == null)
                {
                    return NotFound();
                }
                return supporter;
            }
            catch (DbUpdateConcurrencyException) {

                return BadRequest();
            }                
        }

        [Route("[action]")]
        [EnableCors("GetAllPolicy")]
        [HttpPost]
        public async Task<ActionResult<Supporter>> PostSupporter(Supporter supporter)
        {
            try {

                _context.Supporters.Add(supporter);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSupervisor", new { id = supporter.IdSoporter }, supporter);

            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }           
        }

        private bool SupporterExists(string email)
        {
            return _context.Supporters.Any(e => e.EmailSupporter == email);
        }

        [Route("[action]/{email}/{password}")]
        [EnableCors("GetAllPolicy")]
        [HttpGet]
        public async Task<ActionResult<Supporter>> GetLogin(string email, string password)
        {
            try
            {
                List<Supporter> supervisorsList = await _context.Supporters.Include(s => s.IdSupervisorNavigation).Include(s => s.IdIssueNavigation).Include(s => s.IdNoteNavigation).Select(supporterItem => new Supporter()
                {
                    IdSoporter = supporterItem.IdSoporter,
                    NameSupporter = supporterItem.NameSupporter,
                    FirstSurnameSupporter = supporterItem.FirstSurnameSupporter,
                    SecondSurnameSupporter = supporterItem.SecondSurnameSupporter,
                    EmailSupporter = supporterItem.EmailSupporter,
                    Password = supporterItem.Password,
                    IdSupervisorNavigation = supporterItem.IdSupervisorNavigation,
                    IdIssueNavigation = supporterItem.IdIssueNavigation,
                    IdNoteNavigation = supporterItem.IdNoteNavigation
                }).ToListAsync();

                foreach (Supporter supervisors in supervisorsList)
                {
                    if (supervisors.EmailSupporter.Equals(email) && supervisors.Password.Equals(password))
                    {
                        return supervisors;
                    }
                }
                return BadRequest();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!SupporterExists(email))
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
