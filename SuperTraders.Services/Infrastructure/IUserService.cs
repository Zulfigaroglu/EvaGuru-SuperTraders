using System.Threading.Tasks;
using SuperTraders.Core.DTOs;
using SuperTraders.Core.Entities;

namespace SuperTraders.Services.Infrastructure
{
    public interface IUserService
    {
        Task<User> Create(SignUpDto signUpDto);
        Task<User> Login(LoginDto loginDto);
        Task Logout(User user);
        Task<User?> GetUserByToken(string token);
    }
}