using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace HelpDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersComplaintsController : ControllerBase
    {
        private readonly HelpDeskContext _context;

        public UsersComplaintsController(HelpDeskContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAndComplaints()
        {
            var usersWithComplaints = await _context.Users
                .Include(u => u.Complaints)
                .Where(u => u.Complaints.Any())
                .ToListAsync();

            if (!usersWithComplaints.Any())
            {
                return NotFound();
            }

            var userComplaints = usersWithComplaints.Select(user => new
            {
                user.UserId,
                user.FirstName,
                user.LastName,
                user.Email,
                Complaints = user.Complaints.Select(complaint => new
                {
                    complaint.ComplaintId,
                    complaint.UniqueCode,
                    complaint.Description,
                    complaint.Status,
                    complaint.Approved
                })
            });

            return Ok(userComplaints);
        }
    }
}