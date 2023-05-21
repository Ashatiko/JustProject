using JustProject.Domain.Entity;
using JustProject.Domain.Response;
using System.Text;
using JustProject.Domain.ViewModels;
using ProjectAspMvc.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using JustProject.Domain.Helpers;
using Microsoft.AspNetCore.Authentication;
using JustProject.DAL.Repositories;

using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace JustProject.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly UserTestsRepository _userTestsRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TestsRepository _testsRepository;
        private readonly JWTSettings _options; 

        public UserService(UserRepository userRepository, IHttpContextAccessor context, UserTestsRepository userTestsRepository, TestsRepository testsRepository, IOptions<JWTSettings> settings)
        {
            _userRepository = userRepository;
            _httpContextAccessor = context;
            _userTestsRepository = userTestsRepository;
            _testsRepository = testsRepository;            
            _options = settings.Value;
        }

        public async Task<bool> Register(RegisterViewModel model)
        {
            if (string.IsNullOrEmpty(model.Email)|| string.IsNullOrEmpty(model.Password))
            {
                User user = new User
                {
                    Name = "DefaultName",
                    Surname = "DefaultSurname",
                    Patronumic = "DefaultPatronumic",
                    Phone = 0,
                    AuthorizedTest = false,
                    Role = "User",
                    Email = model.Email,
                    Password = HashPassword.HashPasswordHelper(model.Password)
                };
                if (await _userRepository.Create(user))
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<string> Login(LoginViewModel model)
        {
            if (string.IsNullOrEmpty(model.Email)|| string.IsNullOrEmpty(model.Password))
            {
                return null;
            }

            var user = (await _userRepository.GetAll()).FirstOrDefault(x => x.Email == model.Email && x.Password == HashPassword.HashPasswordHelper(model.Password));

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.UserData, Convert.ToString(user.AuthorizedTest)),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

                var jwt = new JwtSecurityToken(
                    issuer: _options.Issuer,
                    audience: _options.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(50)),
                    notBefore:DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                    );

                string token = new JwtSecurityTokenHandler().WriteToken(jwt);

                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return token;                
            }
            return null;
        }

        //var identity = new ClaimsIdentity(claims, "Token");
        //User.Identity = new ClaimsPrincipal(identity);

        //var authenticationProperties = new AuthenticationProperties();
        //authenticationProperties.StoreTokens(new[]
        //{
        //    new AuthenticationToken { Name = "access_token", Value = token }
        //});
        //await _httpContextAccessor.HttpContext.SignInAsync("Token", new ClaimsPrincipal(identity), authenticationProperties);

        //public async Task<ClaimsPrincipal> Login(LoginViewModel model)
        //{
        //    if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
        //    {
        //        return null;
        //    }

        //    var user = (await _userRepository.GetAll()).FirstOrDefault(x => x.Email == model.Email && x.Password == HashPassword.HashPasswordHelper(model.Password));

        //    if (user != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Email, user.Email),
        //            new Claim(ClaimTypes.UserData, Convert.ToString(user.AuthorizedTest)),
        //            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
        //            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role),
        //    };

        //        var claimsIdentity = new ClaimsIdentity(claims, "Cookies", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

        //        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        //        await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

        //        return claimsPrincipal;
        //    }
        //    return null;
        //}

        public async Task<bool> LogOut()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return true;
        }

        public async Task<bool> LoginTest()
        {
            var user = (await _userRepository.GetAll()).FirstOrDefault(x => x.Email == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value);

            if (user != null)
            {
                user.AuthorizedTest = true;
                user.UserTests = user.Id;
                await _userRepository.Update(user);

                var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;

                identity.RemoveClaim(identity.FindFirst(ClaimTypes.UserData));

                identity.AddClaim(new Claim(ClaimTypes.UserData, Convert.ToString(user.AuthorizedTest)));

                var principal = new ClaimsPrincipal(identity);                

                var authUser = _httpContextAccessor.HttpContext.User.Identity;
                if (authUser is not null && authUser.IsAuthenticated)
                {
                    await _httpContextAccessor.HttpContext.SignInAsync(principal);
                    return true;
                }

                return false;
            }
            return false;
        }

        public async Task<IBaseResponse<User>> GetUser()
        {
            var baseResponse = new BaseResponse<User>();
            baseResponse.Data = (await _userRepository.GetAll()).FirstOrDefault(x => x.Email == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value);            
            return baseResponse;
        }

        public async Task<IBaseResponse<User>> GetEditUser(AccountViewModel model)
        {
            var baseResponse = new BaseResponse<User>();
            var user = (await _userRepository.GetAll()).FirstOrDefault(x => x.Email == model.Email);
            if (user == null)
            {
                return baseResponse;
            }
            string[] fullName = model.FullName.Split(' ');
            if (fullName[1] != "" && fullName[0] != "" && fullName[0] != " " && fullName[1] != " ")
            {
                user.Surname = fullName[0];
                user.Name = fullName[1];
                user.Patronumic = fullName[2];
            }
            else
            {
                baseResponse.Data = (await _userRepository.GetAll()).FirstOrDefault(x => x.Email == _httpContextAccessor.HttpContext.User.Identity.Name);
                return baseResponse;
            }
            user.Patronumic = fullName[2];
            user.Phone = model.Phone;
            user.Email = model.Email;                       
            baseResponse.Data = await _userRepository.Update(user);
            if (ClaimTypes.Name != fullName[0])
            {
                var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;

                identity.RemoveClaim(identity.FindFirst(ClaimTypes.Name));

                identity.AddClaim(new Claim(ClaimTypes.Name, fullName[1]));

                var principal = new ClaimsPrincipal(identity);

                await _httpContextAccessor.HttpContext.SignInAsync(principal);
            }
            return baseResponse;            
        }

        public async Task<IEnumerable<UserTests>> GetHistoryTest()
        {
            try
            {
                var user = (await _userRepository.GetAll()).FirstOrDefault(x => x.Email == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value);                

                return (await _userTestsRepository.GetAll()).Where(x => x.UserTestId == user.UserTests);                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<UserTests>> GetHistoryTestAdd(int id)
        {
            try
            {
                var user = (await _userRepository.GetAll()).FirstOrDefault(x => x.Email == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value);
                
                var test = (await _testsRepository.GetAll()).FirstOrDefault(x => x.Id == id);

                if (test.Type == "Организация")
                {
                    IEnumerable<Tests> tests;
                    switch (test.NameTest)
                    {
                        case "Базовый пакет":
                            tests = (await _testsRepository.GetAll()).Where(x=>x.Type == "Школьник");
                            foreach (var item in tests)
                            {
                                UserTests userTestBase = new UserTests()
                                {
                                    UserTestId = user.Id,
                                    Complete = 0,
                                    Date = DateTime.Now,
                                    NameTest = item.NameTest,
                                    Type = item.Type,
                                };
                                await _userTestsRepository.Create(userTestBase);
                            }
                            break;
                        case "Комплексное тестирование":
                            tests = (await _testsRepository.GetAll()).Where(x => x.Type == "Специалисты");
                            foreach (var item in tests)
                            {
                                UserTests userTestBase = new UserTests()
                                {
                                    UserTestId = user.Id,
                                    Complete = 0,
                                    Date = DateTime.Now,
                                    NameTest = item.NameTest,
                                    Type = item.Type,
                                };
                                await _userTestsRepository.Create(userTestBase);
                            }
                            break;
                        case "Все включено":
                            tests = (await _testsRepository.GetAll()).Where(x => x.Type == "Школьник" || x.Type == "Специалисты");
                            foreach (var item in tests)
                            {
                                UserTests userTestBase = new UserTests()
                                {
                                    UserTestId = user.Id,
                                    Complete = 0,
                                    Date = DateTime.Now,
                                    NameTest = item.NameTest,
                                    Type = item.Type,
                                };
                                await _userTestsRepository.Create(userTestBase);
                            }
                            break;
                    }                    
                    return (await _userTestsRepository.GetAll()).Where(x => x.UserTestId == user.UserTests);
                }
                UserTests userTest = new UserTests()
                {
                    UserTestId = user.Id,
                    Complete = 0,
                    Date = DateTime.Now,
                    NameTest = test.NameTest,
                    Type = test.Type,
                };
                await _userTestsRepository.Create(userTest);
                return (await _userTestsRepository.GetAll()).Where(x => x.UserTestId == user.UserTests);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> GetHistoryTestDelete(int id)
        {
            try
            {
                var test = (await _userTestsRepository.GetAll()).FirstOrDefault(x => x.Id == id);
                if (test == null)
                {
                    return false;
                }
                if (await _userTestsRepository.Delete(test))
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
