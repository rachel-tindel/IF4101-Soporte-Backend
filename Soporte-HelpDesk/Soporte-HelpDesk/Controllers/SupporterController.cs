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
            return await _context.Supporters.Include(s => s.IdServiceNavigation).Include(s => s.IdSupervisorNavigation).Include(s => s.IdIssueNavigation).Include(s => s.IdNoteNavigation).Select(supporterItem => new Supporter()
            {
                IdSoporter = supporterItem.IdSoporter,
                NameSupporter = supporterItem.NameSupporter,
                FirstSurnameSupporter = supporterItem.FirstSurnameSupporter,
                SecondSurnameSupporter = supporterItem.SecondSurnameSupporter,
                EmailSupporter = supporterItem.EmailSupporter,
                Password = supporterItem.Password,
                IdServiceNavigation = supporterItem.IdServiceNavigation,
                IdSupervisorNavigation = supporterItem.IdSupervisorNavigation,
                IdIssueNavigation = supporterItem.IdIssueNavigation,
                IdNoteNavigation = supporterItem.IdNoteNavigation
            }).ToListAsync();
        }

        [Route("[action]/{id}")]
        [EnableCors("GetAllPolicy")]
        [HttpGet]
        public async Task<ActionResult<Supporter>> GetSupporter (int id)
        {
            var supporter = await _context.Supporters.FindAsync(id);

            if (supporter == null)
            {
                return NotFound();
            }

            return supporter;
        }

        [Route("[action]")]
        [EnableCors("GetAllPolicy")]
        [HttpPost]
        public async Task<ActionResult<Supporter>> PostSupporter(Supporter supporter)
        {
            _context.Supporters.Add(supporter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupervisor", new { id = supporter.IdSoporter }, supporter);
        }

    }
}
