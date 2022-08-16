//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using ReFeelRepository.Data;
//using ReFeelRepository.Models;
//using ReFeelServices;
//using ReFeelCourtesy;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace ReFeelRepository
//{
//    public class AuthRepository : IAuthRepository
//    {
//        private readonly RefeelContext _context;
//        private readonly IConfiguration _configuration;

//        public AuthRepository (RefeelContext context, IConfiguration configuration) 
//        {
//            _context = context; 
//            _configuration = configuration;
//        }

//        public async Task<ServiceResponse<string>> Login(string email, string phoneNo, string password)
//        {
//            ServiceResponse<string> response = new ServiceResponse<string>();   
//            User user = await _context.User.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()) 
//                                                                                     || x.PhoneNumber.ToLower().Equals(phoneNo.ToLower()));
//            if (user == null)
//            {
//                response.Success = false;
//                response.Message = "User not found.";
//            }
//            else if(!VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
//            {
//                response.Success = false;
//                response.Message = "Wrong password";

//            }
//            else
//            {
//                response.Data = CreateToken(user);
//            }

//            return response;
//        }

//        public async Task<ServiceResponse<int>> Register(User user, string password)
//        {
//            ServiceResponse<int> response = new ServiceResponse<int>();
            
//            try
//            {
//                if (!Utils.IsValidPhone(user.PhoneNumber))
//                {
//                    //Todo add translated messages
//                    response.Success = false;
//                    response.Error = "Phone number is invalid!";
//                    return response;
//                }

//                if (!Utils.IsValidEmail(user.Email))
//                {
//                    //Todo add translated messages
//                    response.Success = false;
//                    response.Error = "Email is invalid!";
//                    return response;
//                }

//                if (await  UserExists(user.Email, user.PhoneNumber))
//                {
//                    //Todo add translated messages
//                    response.Success = false;
//                    response.Error = "Email or phone number already exists!";
//                    return response;
//                }

//                CreatePassWordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
//                user.PasswordHash = passwordHash;
//                user.PasswordSalt = passwordSalt;

//                await _context.User.AddAsync(user); ;
//                await _context.SaveChangesAsync();


//                response.Data = user.UserId;
//            }
//            catch (System.Exception)
//            {
//                //if 
//                response.Success = false;
//            }
           
//            return response;
//        }

//        public async Task<bool> UserExists(string email, string phoneNo)
//        {
//            if (await _context.User.AnyAsync(x => x.Email.ToLower() == email.ToLower()) 
//                    || 
//                await _context.User.AnyAsync(x => x.PhoneNumber == phoneNo))
//            {
//                return true;
//            }
//                return false;
//        }

//        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
//        {
//            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
//            {
//                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
//                for(int i = 0; i < computedHash.Length; i++)
//                {
//                    if(computedHash[i] != passwordHash[i])
//                    { return false;}
//                }
//                return true;
//            }
//        }

//        private void CreatePassWordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
//        {
//            using(var hmac = new System.Security.Cryptography.HMACSHA512())
//            {
//                passwordSalt = hmac.Key;
//                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
//            }
//        }

//        private string CreateToken(User User)
//        {
//            List<Claim> claims = new List<Claim>
//            {
//                new Claim(ClaimTypes.NameIdentifier, User.UserId.ToString()),
//                new Claim(ClaimTypes.Name, User.Firstname.ToString()),
//                new Claim(ClaimTypes.Name, User.Lastname.ToString()),
//                new Claim(ClaimTypes.Email, User.Email.ToString()),
//                new Claim(ClaimTypes.MobilePhone, User.PhoneNumber.ToString())
//                //new Claim ( "True", "Driver's License", Rights.Driver); add later for driver -- source https://docs.microsoft.com/en-us/dotnet/framework/wcf/extending/how-to-create-a-custom-claim
//            };

//            SymmetricSecurityKey key = new SymmetricSecurityKey(
//                    Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:AccessToken").Value)
//                );

//            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
//            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(claims),
//                Expires = DateTime.Now.AddDays(1),
//                SigningCredentials = creds
//            };

//            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
//            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
           
//            //to do add refresh token
//            return tokenHandler.WriteToken(token);
//        }

//    }
//}
