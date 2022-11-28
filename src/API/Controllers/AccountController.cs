using BLL.Models;
using BLL.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        private SignInManager<ApplicationUser> _signInManager;

        private IConfiguration _config;

        private IUnitOfWork _uof;

        public AccountController(SignInManager<ApplicationUser> _signInManager, UserManager<ApplicationUser> _userManager, IUnitOfWork uof, IConfiguration config)
        {
            this._signInManager = _signInManager;

            this._userManager = _userManager;

            _uof = uof;

            _config = config;
        }

        [HttpPost]
        [Route("roleuser")]
        public async Task<ActionResult> AssociateUserRole([FromBody] IdentityUserRole<Guid> identityUserRole)
        {
            await _uof.RoleIdentityRepository.AssociateUserRole(identityUserRole);

            await _uof.CommitAsync();

            return Ok();
        }

        [HttpPost]
        [Route("role")]
        public async Task<ActionResult> Role([FromBody] ApplicationRole applicationRole)
        {
            await _uof.RoleIdentityRepository.CreateAsync(applicationRole);

            await _uof.CommitAsync();

            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(UserDto model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, model.Password);            

            await _signInManager.SignInAsync(user, false);                                       

            var token = await GenerateTokenAsync(model);

            return Ok(token);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] UserDto userInfo)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userInfo.Email,

                    userInfo.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var token = await GenerateTokenAsync(userInfo);

                    return Ok(token);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel fazer o login. Entre em contato com o administrador \n" + ex.Message);
            }

            ModelState.AddModelError(String.Empty, "Login inválido");

            return Ok();
        }

        private async Task<UserToken> GenerateTokenAsync(UserDto userInfo)
        {
            try
            {
                var user = await _signInManager.UserManager.FindByEmailAsync(userInfo.Email);

                var userRoles = await _uof.RoleIdentityRepository.GetAllUserRolesAsync(user.Id);                

                var authClaims = new List<Claim>();

                foreach (var roles in userRoles)
                {
                    var role = await _uof.RoleIdentityRepository.GetRoleByIdAsync(roles.RoleId);

                    if (role != null)
                        authClaims.Add(new Claim(ClaimTypes.Role, role.Name));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:key"]));

                var creds =
                   new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var expiration = DateTime.UtcNow.AddHours(2);

                var message = "Token JWT criado com sucesso";

                JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: authClaims,
                expires: expiration,
                signingCredentials: creds);

                return new UserToken()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = expiration,
                    Message = message
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new UserToken();
        }
    }
}
