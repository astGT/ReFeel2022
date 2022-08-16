using Microsoft.AspNetCore.Mvc;
using ReFeelRepository.Models.Entitites;
using ReFeelRepository.Models.DTo.Entities;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using ReFeelRepository.iRepository;

namespace ReFeelWebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _context;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTo>>> GetUser()
        {
            IEnumerable<User> userList = await _context.GetAllAsync();
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

            var user = await _context.GetAsync(x => x.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDTo>(user));    
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}", Name = "UpdatePartialUser")]
        public async Task<IActionResult> UpdatePartialUser(int id, JsonPatchDocument<UserUpdateDTo> updateDTo)
        {
            if (updateDTo != null && id == 0)
            {
                return BadRequest();
            }

            var user = await _context.GetAsync(x => x.UserId == id, tracked:false);

            UserUpdateDTo userDTo = _mapper.Map<UserUpdateDTo>(user);

            updateDTo.ApplyTo(userDTo, ModelState);
            User model  = _mapper.Map<User>(userDTo);

            if (userDTo == null)
            {
                return BadRequest();
            }

            await _context.UpdateAsync(model);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}", Name = "UpdateUser")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDTo updateDTo)
        {
            if (updateDTo != null ||  id != updateDTo.UserId)
            {
                return BadRequest();
            }

            User model = _mapper.Map<User>(updateDTo);

            await _context.UpdateAsync(model);
            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDTo>> CreateUser(UserCreateDTo createDTo)
        {
            var user = await _context.GetAsync(x => (x != null && x.Email.ToLower() == createDTo.Email.ToLower()
                                                                 || (x != null && x.PhoneNumber == createDTo.PhoneNumber)));
            if (user != null)
            {
                ModelState.AddModelError("CreateUserError", "User already exists");
                return BadRequest(ModelState);

            }

            if(createDTo == null)
            {
                return BadRequest(createDTo);
            }

            User model = _mapper.Map<User>(createDTo); 


           await _context.CreateAsync(model);        

            return CreatedAtRoute("GetUser", new { id = model.UserId }, model);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if(id == 0)
            {
                BadRequest();
            }

            var user = await _context.GetAsync(x => x.UserId == id);
            if(user == null)    
            {
                return NotFound();  
            }

            await _context.RemoveAsync(user);
            return NoContent();

            //return NoContent();
        }

        //private bool UserExists(int id)
        //{
        //    return _context.GetAsync(e => e.UserId == id);
        //}
    }
}
