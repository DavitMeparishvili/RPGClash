using RPGClash.Domain.Entities;

namespace RPGClash.Domain.Repositories
{
    public interface IUserRepo
    {
        public Task<User> GetUserAsync(string userId);
    }
}
