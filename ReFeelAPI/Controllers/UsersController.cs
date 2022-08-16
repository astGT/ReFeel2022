using Microsoft.AspNetCore.Mvc;
using ReFeelRepository.Models.Entitites;
using ReFeelRepository.Models.DTo.Entities;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using ReFeelRepository.iRepository;
using ReFeelRepository.Models;
using System.Net;

namespace ReFeelWebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [ApiController]
    [Route("api/User")]
    public class UsersController : ControllerBase
    {
        protected APIResponse _reponse;
        private readonly IUserRepository _context;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            this._reponse = new();
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetUsers()
        {
            try
            {
                IEnumerable<User> userList = await _context.GetAllAsync();
                _reponse.Result = _mapper.Map<List<UserDTo>>(userList);
                _reponse.StatusCode = HttpStatusCode.OK;
                return Ok(_reponse);
            }
            catch (Exception ex)
            {

                _reponse.IsSucces = false;
                _reponse.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
           
            return _reponse;
        }

        // GET: api/Users/5
        [HttpGet("{id:int}", Name = "GetUser")]
        public async Task<ActionResult<APIResponse>> GetUser(int id)
        {
            try
            {
                if (id == 0)
                {
                    _reponse.StatusCode = HttpStatusCode.BadRequest;
                    return (_reponse);
                }

                var user = await _context.GetAsync(x => x.UserId == id);
                if (user == null)
                {
                    _reponse.StatusCode = HttpStatusCode.NotFound;
                    return (_reponse);
                }

                _reponse.Result = _mapper.Map<UserDTo>(user);
                _reponse.StatusCode = HttpStatusCode.OK;
                return Ok(_reponse);
            }
            catch (Exception ex)
            {
                _reponse.IsSucces = false;
                _reponse.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }

            return _reponse;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id:int}", Name = "UpdatePartialUser")]
        //public async Task<IActionResult> UpdatePartialUser(int id, JsonPatchDocument<UserUpdateDTo> updateDTo)
        //{
        //    if (updateDTo != null && id == 0)
        //    {
        //        _reponse.StatusCode = HttpStatusCode.BadRequest;
        //        return BadRequest(_reponse);
        //    }

        //    var user = await _context.GetAsync(x => x.UserId == id, tracked:false);

        //    UserUpdateDTo userDTo = _mapper.Map<UserUpdateDTo>(user);

        //    updateDTo.ApplyTo(userDTo, ModelState);
        //    User model  = _mapper.Map<User>(userDTo);

        //    if (userDTo == null)
        //    {
        //        _reponse.StatusCode = HttpStatusCode.BadRequest;
        //        return BadRequest(_reponse);
        //    }

        //    await _context.UpdateAsync(model);

        //    if(!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    return NoContent();
        //}


        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}", Name = "UpdateUser")]
        public async Task<ActionResult<APIResponse>> UpdateUser(int id, [FromBody] UserUpdateDTo updateDTo)
        {
            try { 
            if (updateDTo != null ||  id != updateDTo.UserId)
            {
                return BadRequest();
            }

            User model = _mapper.Map<User>(updateDTo);

            await _context.UpdateAsync(model);
            _reponse.StatusCode = HttpStatusCode.NoContent;
            _reponse.IsSucces = true;
            return Ok(_reponse);
            }
            catch (Exception ex)
            {
                _reponse.IsSucces = false;
                _reponse.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }

            return _reponse;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateUser(UserCreateDTo createDTo)
        {
            var user = await _context.GetAsync(x => (x != null && x.Email.ToLower() == createDTo.Email.ToLower()
                                                                 || (x != null && x.PhoneNumber == createDTo.PhoneNumber)));
            try { 
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
            _reponse.Result = _mapper.Map<UserDTo>(model);
            _reponse.StatusCode = HttpStatusCode.Created;

            return CreatedAtRoute("GetUser", new { id = model.UserId }, model);
            }
            catch (Exception ex)
            {
                _reponse.IsSucces = false;
                _reponse.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }

            return _reponse;
        }

        // DELETE: api/Users/5
        [HttpDelete("{id:int}", Name = "DeleteUser")]
        public async Task<ActionResult<APIResponse>> DeleteUser(int id)
        {
            try { 
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
            _reponse.StatusCode = HttpStatusCode.NoContent;
            _reponse.IsSucces = true;
            return Ok(_reponse);
                //return NoContent();
            }
            catch (Exception ex)
            {
                _reponse.IsSucces = false;
                _reponse.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }

            return _reponse;
        }

        //private bool UserExists(int id)
        //{
        //    return _context.GetAsync(e => e.UserId == id);
        //}
    }
}
