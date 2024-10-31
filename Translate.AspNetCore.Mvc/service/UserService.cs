using Microsoft.EntityFrameworkCore;
using Translate.AspNetCore.Mvc.Entities;
using Translate.AspNetCore.Mvc.Models;

namespace Translate.AspNetCore.Mvc.service
{
    public interface IUserService
    {
        Task<UserModel> ValidateUserAsync(string email, string password);
    }

    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> ValidateUserAsync(string email, string password)
        {
            return await _context.Users
                .Where(x => x.Email == email && x.Password == password)
                .FirstOrDefaultAsync();
        }
    }
}
