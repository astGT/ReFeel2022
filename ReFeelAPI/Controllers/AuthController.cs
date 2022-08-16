//using Microsoft.AspNetCore.Mvc;
//using ReFeelRepository.Models;
//using System.Threading.Tasks;
//using ReFeelRepository;
//using ReFeelServices;
//using ReFeelRepository.DTO.User;
//using Microsoft.AspNetCore.Authorization;

//namespace ReFeelWebApi.Controllers
//{    
//    [ApiController]
//    [Route("[controller]")]
//    public class AuthController : ControllerBase
//    {

//        public readonly IAuthRepository _authRepo;

//        public AuthController(IAuthRepository authRepo)
//        {
//            _authRepo = authRepo; 
//        }

//        [Microsoft.AspNetCore.Mvc.HttpPost("Register")]        
//        public async Task<IActionResult> Register(UserRegisterDTo request)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            //Todo Add more details for user later
//            //To do rework so Services talk only with repository
//            ServiceResponse<int> response = await _authRepo.Register(
//                    new User { Firstname = request.FirstName, Lastname = request.LastName, Email = request.Email, PhoneNumber = request.PhoneNumber }, request.Password
//                );
//            if(!response.Success)
//            {
//                return BadRequest(response);
//            }

//            return Ok(response);    
//        }


//        [HttpPost("Login")]
//        //[Authorize]
//        public async Task<IActionResult> Login(UserLoginDTo request)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            //Todo Add more details for user later
//            ServiceResponse<string> response = await _authRepo.Login(request.Email, request.PhoneNumber, request.Password);
//            if (!response.Success)
//            {
//                return BadRequest(response);
//            }

//            return Ok(response);
//        }
//    }
//}
