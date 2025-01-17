using AutoMapper;
using Business.Dtos.Auth;
using Business.Services.Abstract;
using Business.Validators.Auth;
using Business.Wrappers;
using Core.Constants.Enums;
using Core.Entities;
using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService( UserManager<User> userManager,IMapper mapper,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async  Task<Response> RegisterAsync(AuthRegisterDto model)
        {
            var result = await  new AuthRegisterDtoValidator().ValidateAsync(model);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);
            var user =await _userManager.FindByEmailAsync(model.Email);
            if (user is not null)
                throw new ValidationException("already exists");
           user= _mapper.Map<User>(model);
            var registerResult = await _userManager.CreateAsync(user, model.Password);
            if (!registerResult.Succeeded)
                throw new ValidationException(registerResult.Errors.Select(x=>x.Description));

          var addRoleResult=  await _userManager.AddToRoleAsync(user,UserRoles.User.ToString());
            if (!addRoleResult.Succeeded)
                throw new ValidationException(addRoleResult.Errors.Select(x=>x.Description));
            return new Response
            {
                Message = "User successfuly created"
            };
        }

        public async Task<Response<AuthLoginResponseDto>> LoginAsync(AuthLoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
                throw new UnauthorizedAccessException("email or password is incorrect");

            var isSucceededCheck = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!isSucceededCheck)
                throw new UnauthorizedAccessException("email or password is incorrect");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.Email)
            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var token = new JwtSecurityToken
            ( 
              claims: claims,
               issuer: _configuration.GetSection("JWT:Issuer").Value,
               audience: _configuration.GetSection("JWT:Audience").Value,
               expires:DateTime.Now.AddDays(1),
               signingCredentials:new SigningCredentials(authSigningKey,SecurityAlgorithms.HmacSha256)
            );
           
            return new Response<AuthLoginResponseDto>
            {
                 Data = new AuthLoginResponseDto
                 {
                     Token = new JwtSecurityTokenHandler().WriteToken(token)
                 }
            };
        }
    }
}
