﻿using Events.Core.Auth.Dtos;
using Events.Core.Auth.Repository.Interface;
using Events.Core.Auth.Service.Interface;

namespace Events.Core.Auth.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<IList<string>> AssignRole(string email, List<string> roles)
        {
            return await _authRepository.AssignRole(email, roles);
        }

        public async Task<ResponseDto> Register(RegistrationRequestDto registerDto)
        {
            return await _authRepository.Register(registerDto);
        }

        public async Task<ResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            return await _authRepository.Login(loginRequestDto);
        }

    }
}
