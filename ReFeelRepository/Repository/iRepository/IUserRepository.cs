using ReFeelRepository.Models.DTO.Identity;
using ReFeelRepository.Models.Entitites;

namespace ReFeelRepository.iRepository
{
    public interface IUserRepository 
    {        
        bool IsUniqueUser(string username);

        Task<LoginResponseDTO> Login(LoginRequestDTO loginResponseDTO);
        Task<LocalUser> Register(RegisterRequestDTO registerRequestDTO);
    }
}
