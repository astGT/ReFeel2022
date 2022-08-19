using Microsoft.AspNetCore.Mvc;
using ReFeelRepository.Models.Entitites;
using ReFeelRepository.Models.DTo.Entities;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using ReFeelRepository.iRepository;
using ReFeelRepository.Models;
using System.Net;
using ReFeelRepository.Models.DTO.Identity;

namespace ReFeelWebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [ApiController]
    [Route("api/UsersAuth")]
    public class UsersController : ControllerBase
    {
        protected APIResponse _reponse;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            this._reponse = new();
        }


        [HttpPost("login")]
        public async Task<IActionResult>Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var LoginResponse = await _userRepo.Login(loginRequestDTO);
            if (LoginResponse == null || string.IsNullOrEmpty(LoginResponse.Token))
            {
                _reponse.StatusCode = HttpStatusCode.BadRequest;
                _reponse.IsSucces = false;
                _reponse.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_reponse);
            }

            _reponse.StatusCode = HttpStatusCode.OK;
            _reponse.IsSucces = false;
            _reponse.Result = LoginResponse;
            return Ok(_reponse);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            bool ifUserNameUnique = _userRepo.IsUniqueUser(registerRequestDTO.UserName);
            if (!ifUserNameUnique)
            {
                _reponse.StatusCode = HttpStatusCode.BadRequest;
                _reponse.IsSucces = false;
                _reponse.ErrorMessages.Add("Username already exists");
                return BadRequest(_reponse);
            }

            var user = await _userRepo.Register(registerRequestDTO);
            if(user == null)
            {
                _reponse.StatusCode = HttpStatusCode.BadRequest;
                _reponse.IsSucces = false;
                _reponse.ErrorMessages.Add("Error WHile registering");
                return BadRequest(_reponse);
            }

            _reponse.StatusCode = HttpStatusCode.OK;
            _reponse.IsSucces = true;
            return Ok(_reponse);
        }
    }
}
