using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReFeelRepository.iRepository;
using ReFeelRepository.Models;
using ReFeelRepository.Models.DTO.Identity;
using ReFeelRepository.Models.Entitites;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReFeelRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private RefeelContext _context;
        private string secretKey;

        public UserRepository(RefeelContext context, IConfiguration _configuration) 
        {
            _context = context;
            secretKey = _configuration.GetValue<string>("ApiSettings:SecretToken");
        }

        public bool IsUniqueUser(string username)
        {
            var user = _context.LocalUser.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                return true;
            }

            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            //to do change with email or phone check.
            var user = _context.LocalUser.FirstOrDefault(x => x.UserName.ToLower() == loginRequestDTO.Username.ToLower()
            && x.Password == loginRequestDTO.Password);

            if(user == null)
            {
                return new LoginResponseDTO()
                { 
                    Token = "",
                    User = null
                };
            }

            //if user was found generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()), //use email insteed
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO
            {
                Token = tokenHandler.WriteToken(token),
                User = user
            };

            return loginResponseDTO;

        }

        public async Task<LocalUser> Register(RegisterRequestDTO registerRequestDTO)
        {
           LocalUser user = new LocalUser()
            {
                UserName = registerRequestDTO.UserName,
                Password = registerRequestDTO.Password,
                Firstname = registerRequestDTO.FirstName,
                Lastname = registerRequestDTO.LastName,
                Role = registerRequestDTO.Role
            };

            _context.LocalUser.Add(user);
            await _context.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}
