using System;
using System.Threading.Tasks;
using AutoMapper;
using SuperTraders.Core.DTOs;
using SuperTraders.Core.Entities;
using SuperTraders.Data.Repositories.Infrastructure;
using SuperTraders.Infrastructure;
using SuperTraders.Services.Infrastructure;

namespace SuperTraders.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public async Task<User> Create(SignUpDto signUpDto)
        {
            var user = _mapper.Map<User>(signUpDto);
            return await _userRepository.Create(user);
        }
        
        public async Task<User> Login(LoginDto loginDto)
        {
            User user = await _userRepository.Find(user => (user.EMail == loginDto.UserKey || user.UserName == loginDto.UserKey) && user.Password == loginDto.Password);
            using (TokenGenerator tokenGenerator = new TokenGenerator())
            {
                user.AuthToken = tokenGenerator.GenerateToken();
            }
            return await _userRepository.Update(user);
        }

        public async Task Logout(User user)
        {
            user.AuthToken = "";
            await _userRepository.Update(user);
        }
        
        public async Task<User?> GetUserByToken(string token)
        {
            return await _userRepository.Find(user => user.AuthToken == token);
        }
    }
}