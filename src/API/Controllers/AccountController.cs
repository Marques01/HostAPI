using BLL.Models;
using DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        private SignInManager<ApplicationUser> _signInManager;

        private ApplicationDbContext _context;

        public AccountController(SignInManager<ApplicationUser> _signInManager, UserManager<ApplicationUser> _userManager, ApplicationDbContext context)
        {
            this._signInManager = _signInManager;

            this._userManager = _userManager;

            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserDto model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(model);
            }

            string perfil = "Admin";

            Claim claim = new Claim(perfil, perfil, ClaimValueTypes.String);

            IdentityResult resultClaim = await _userManager.AddClaimAsync(user, claim);

            await _signInManager.SignInAsync(user, false);

            return Ok(model);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(UserDto userInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(userInfo);
            }

            try
            {
                var result = await _signInManager.PasswordSignInAsync(userInfo.Email,

                    userInfo.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(userInfo.Email));

                    var claims = Enumerable.Empty<Claim>();

                    if (user != null)
                        claims = await _userManager.GetClaimsAsync(user);

                    return Ok(claims);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel fazer o login. Entre em contato com o administrador \n" + ex.Message);
            }

            ModelState.AddModelError(String.Empty, "Login inválido");

            return Ok();
        }
    }
}
