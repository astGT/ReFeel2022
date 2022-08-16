using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReFeelRepository.Models.Entitites;
using ReFeelRepository.Models;
using ReFeelRepository.Models.DTo.Entities;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace ReFeelWebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly RefeelContext _context;
        private readonly IMapper _mapper;

        public UsersController(RefeelContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTo>>> GetUser()
        {
            IEnumerable<User> userList = await _context.User.ToListAsync();
            return Ok(_mapper.Map<List<UserDTo>>(userList));
        }

        // GET: api/Users/5
        [HttpGet("{id:int}", Name = "GetUser")]
        public async Task<ActionResult<UserDTo>> GetUser(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDTo>(user));    
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePartialUser(int id, JsonPatchDocument<UserUpdateDTo> updateDTo)
        {
            if (updateDTo != null && id == 0)
            {
                return BadRequest();
            }

            var user = await _context.User.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == id);

            UserUpdateDTo userDTo = _mapper.Map<UserUpdateDTo>(user);

            updateDTo.ApplyTo(userDTo, ModelState);
            User model  = _mapper.Map<User>(userDTo);

            if (userDTo == null)
            {
                return BadRequest();
            }

            _context.User.Update(model);
            await _context.SaveChangesAsync();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDTo>> CreateUser(UserCreateDTo createDTo)
        {
            if (_context.User.Any(x => (x != null && x.Email.ToLower() == createDTo.Email.ToLower()
                                                                 || (x != null && x.PhoneNumber == createDTo.PhoneNumber))))
            {
                ModelState.AddModelError("CreateUserError", "User already exists");
                return BadRequest(ModelState);

            }

            if(createDTo == null)
            {
                return BadRequest(createDTo);
            }


            User model = _mapper.Map<User>(createDTo); 


           await _context.AddAsync(model);
           await _context.SaveChangesAsync();            

            return CreatedAtRoute("GetUser", new { id = model.UserId }, model);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
