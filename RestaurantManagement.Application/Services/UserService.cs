﻿using AutoMapper;
using RestaurantManagement.Application.Dtos;
using RestaurantManagement.Application.Interfaces;
using RestaurantManagement.Domain.Entities;
using RestaurantManagement.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on users.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="UserRepository">The repository for accessing UserDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<UserDto>> GetUsersDetails(int? id)
        {
            var Users = await _userRepository.GetUsersDetails(id);

            var UserDetails = _mapper.Map<IEnumerable<UserDto>>(Users);
            return UserDetails;
        }
        /// <inheritdoc/>
        public async Task<UserDto> InsertUserDetails(UserDto userDto)
        {

            var User = _mapper.Map<Users>(userDto);
            var enPassword = BCrypt.Net.BCrypt.HashPassword(User.Password);
            User.Password = enPassword;
            var insertedData = await _userRepository.InsertUserDetails(User);
            if (insertedData == null)
            {
                // Handle the case where the insertion was not successful
                throw new Exception("User insertion failed.");
            }
            return _mapper.Map<UserDto>(insertedData);

        }
        /// <inheritdoc/>
        public async Task UpdateUserDetails(UserDto userDto)
        {
            var User = _mapper.Map<Users>(userDto);
            await _userRepository.UpdateUserDetails(User);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteUserDetails(int id)
        {
            return await _userRepository.DeleteUserDetails(id);
        }
        
        
    }
}
