using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        //now we have access to our database via the dbcontext 
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }


        //now we will have some endpoint 
        //one for all the users in the database
        //and other for specific user in our database

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //var users = _context.Users.ToList();
            //return users;
            //simply write in one line as it does the same job
            return await _context.Users.ToListAsync(); 
        }

        //so if the user wants a specific id it will come to this end point
        //like if the user asks for api/users/3
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            //var user = _context.Users.Find(id);
            //return user;
            //simply write return

            return await _context.Users.FindAsync(id);
        }




    }
}