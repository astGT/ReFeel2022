using Microsoft.EntityFrameworkCore;
using ReFeelRepository.iRepository;
using ReFeelRepository.Models;
using ReFeelRepository.Models.Entitites;


namespace ReFeelRepository.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private RefeelContext _context;

        public UserRepository(RefeelContext context) : base (context)
        {
            _context = context;
        }

        public async Task<User> UpdateAsync(User entity)
        {
            entity.UpdateDate = DateTime.Now;   
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
