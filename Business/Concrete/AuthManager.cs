using Business.Abstract;
using Core.Constants;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IHttpContextAccessor _contextAccessor;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IHttpContextAccessor contextAccessor)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _contextAccessor = contextAccessor;
        }


        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            _userService.Add(user);
            return new SuccessDataResult<User>(user, AspectMessages.UserRegistered);

        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(AspectMessages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(AspectMessages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, AspectMessages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            var result = _userService.GetByEmail(email);
            if (result.Data == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(AspectMessages.UserAlreadyExists);

        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, AspectMessages.AccessTokenCreated);

        }

        public IResult AddClaimCookie(string token)
        {
            JwtSecurityToken DecodedToken = new JwtSecurityToken(jwtEncodedString: token);
            string Role = DecodedToken.Claims.First(c => c.Type.Contains("role")).Value;
            _contextAccessor.HttpContext.Session.SetString("UserRole", Role);

            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Role,Role)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            return new SuccessResult();
        }
    }
}
