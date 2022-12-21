using Application.Features.Auths.Dtos;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using KodlamaioDevs.Application.Features.Auths.Rules;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommand : IRequest<LoggedDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginCommandHandler(IUserRepository userRepository, IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<LoggedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.EmailMustExistWhenRequested(request.UserForLoginDto.Email);

                User? userToLogin = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);

                await _authBusinessRules.PasswordMustVerifyWhenLogged(userToLogin, request.UserForLoginDto.Password);
                

                LoggedDto loggedDto = new();

                AccessToken accessToken = await _authService.CreateAccessToken(userToLogin);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(userToLogin, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken); // fix bugs



                loggedDto.AccessToken = accessToken;
                loggedDto.RefreshToken = createdRefreshToken;

                return loggedDto;


            }
        }
    }
}
