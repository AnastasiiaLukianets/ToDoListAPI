﻿using AutoMapper;
using ToDoListAPI.Models;
using ToDoListAPI.Repository;
using ToDoListAPI.ResponseDto;

namespace ToDoListAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        #region IUserService_implementation
        public async Task<IEnumerable<UserResponse?>> GetUsers()
        {
            var usersSource = await _userRepository.GetAll();
            var users = _mapper.Map<IEnumerable<User?>, IEnumerable<UserResponse>>(usersSource);
            return users;
        }

        public async Task<UserResponse?> GetUser(int id)
        {
            User? userSource = await _userRepository.GetById(id);
            var user = _mapper.Map<UserResponse>(userSource);
            return user;
        }

        public async Task<User?> AddUser(User user)
        {
            return await _userRepository.Add(user);
        }

        public async Task<User?> UpdateUser(User user)
        {
            return await _userRepository.Update(user);
        }

        public async Task<User?> DeleteUser(int id)
        {
            return await _userRepository.DeleteById(id);
        }
        #endregion


    }
}
