﻿using Events.Core.Auth.Dtos;

namespace Events.Core.Auth.Service.Interface
{
    public interface IAuthService
    {
        Task<ResponseDto> Register(RegistrationRequestDto registerDto);
        Task<ResponseDto> Login(LoginRequestDto loginDto);
        Task<IList<string>> AssignRole(string email, List<string> roles);
    }
}
