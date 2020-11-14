using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Student2.BL.Entities;
using Student2.DAL;
using Student2.Server.Models.Auth;
using Student2.Utils;

namespace Student2.Server.Services
{
    public class AuthService
    {
        readonly AppJwtTokenHandler _tokenHandler;
        readonly SignInManager<AppUser> _signInManager;
        readonly UserManager<AppUser> _userManager;
        readonly AppDbContext _dbContext;

        public AuthService(AppJwtTokenHandler tokenHandler, SignInManager<AppUser> manager,
            UserManager<AppUser> userManager, AppDbContext dbContext)
        {
            (_tokenHandler, _signInManager, _userManager, _dbContext) =
                (tokenHandler, manager, userManager, dbContext);
        }

        public async Task<Result<Tuple<UserDto, string>>> LoginUser(LoginDto form)
        {
            var user = await _userManager.FindByEmailAsync(form.Email);
            if (user == null) return new Error("Invalid username or password");

            var result = await _signInManager.CheckPasswordSignInAsync(user, form.Password, false);

            if (!result.Succeeded) return new Error("Invalid username or password");

            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenHandler.CreateSignedToken(user, roles.FirstOr(AppRole.REGULAR));
            await _dbContext.Entry(user).Reference(u => u.University).LoadAsync();

            return Tuple.Create(new UserDto(user, roles), token);
        }

        public async Task<Result<Tuple<AppUser, string>>> CreateUser(RegisterDto form)
        {
            var domain = form.Email.Split('@')[1];
            var univeristy = await _dbContext.University.Where(u => u.Domain == domain).FirstOrDefaultAsync();
            if (univeristy == null) return new Error($@"No university with domain ""{domain}"" found");

            var user = new AppUser
            {
                Email = form.Email,
                UserName = form.Username ?? form.Email,
                UniversityId = univeristy.Id,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, form.Password);
            if (!result.Succeeded) return new Error(result.Errors.First().Description);

            await _userManager.AddToRoleAsync(user, AppRole.REGULAR);
            var token = _tokenHandler.CreateSignedToken(user, AppRole.REGULAR, univeristy.Id);

            return Tuple.Create(user, token);
        }

        public async Task<(AppUser user, IList<string> roles)?> GetUser(ClaimsPrincipal principal)
        {
            var user =  await _userManager.GetUserAsync(principal);
            if (user == null) return null;
            await _dbContext.Entry(user).Reference(u => u.University).LoadAsync();
            var roles = await _userManager.GetRolesAsync(user);

            return (user, roles);
        }

        public Task<IList<string>> GetUserRoles(AppUser user) => _userManager.GetRolesAsync(user);
    }
}
