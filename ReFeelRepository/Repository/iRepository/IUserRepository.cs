
using ReFeelRepository.Models.Entitites;
using ReFeelRepository.Repository.iRepository;
using System.Linq.Expressions;

namespace ReFeelRepository.iRepository
{
    public interface IUserRepository :IRepository<User>
    {
        Task<User> UpdateAsync(User entity);
    }
}
