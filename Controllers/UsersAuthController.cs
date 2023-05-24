using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthController : ControllerBase
    {
        private readonly HelpDeskContext _context;

        public UsersAuthController(HelpDeskContext context)
        {
            _context = context;
        }

      

        // GET: api/UsersAuth/5
        [HttpGet]
        public async Task<ActionResult<User>> GetUser(String email, string password)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password); ;

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

    }
}
