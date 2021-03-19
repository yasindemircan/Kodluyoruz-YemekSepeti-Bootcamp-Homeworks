using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using hotels.API.Contexts;
using hotels.API.Models;
using hotels.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace hotels.API.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly HotelApiDbContext _dbContext;
        private IConfiguration _configuration;
        public UserService(HotelApiDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<UserInfo> Authenticate(TokenRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.LoginUser) || string.IsNullOrWhiteSpace(req.LoginPass))
            {
                return null;
            }
            var user = await _dbContext.Users.SingleOrDefaultAsync(user => user.LoginName == req.LoginUser && user.Pass == req.LoginPass);
            if (user == null)
                return null;
            var secretKey = _configuration.GetValue<string>("JwtTokenKey");
            var singingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(singingKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var newToken = tokenHandler.CreateToken(tokenDesc);
            var UserInfo = _mapper.Map<UserInfo>(user);
            UserInfo.ExpireTime = tokenDesc.Expires ?? DateTime.Now.AddHours(1);
            UserInfo.Token = tokenHandler.WriteToken(newToken);

            return UserInfo;
        }
    }
}
