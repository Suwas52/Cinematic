﻿using Microsoft.AspNetCore.Identity;
using Movie_Catlog_Application.DTOs.User;
using Movie_Catlog_Application.Interfaces.Abstract;
using Movie_Catlog_Application.Models;
using System.Security.Claims;

namespace Movie_Catlog_Application.Interfaces.Implements
{
    public class UserAuthenticationService : IUserAuthenticationService
    {

        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UserAuthenticationService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager , RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<Status> LoginAsync(Login model)
        {
            var status = new Status();

            var user = await userManager.FindByNameAsync(model.Username);

            if(user == null)
            {

                status.StatusCode = 0;
                status.Message = "Invalid Username";
                return status;
            }

            if (!await userManager.CheckPasswordAsync(user, model.Password))
            {
                status.StatusCode = 0;
                status.Message = "Password not match";
                return status;


            }

            var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, true);

            if (signInResult.Succeeded)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                };

                foreach(var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                status.StatusCode = 1;
                status.Message = "Logged in Successfully";
                return status;
            }
            else if (signInResult.IsLockedOut)
            {
                status.StatusCode = 0;
                status.Message = "User Logged Out";
                return status;
            }
            else
            {
                status.StatusCode = 0;
                status.Message = "Invalid Login";
                return status;
            }
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<Status> RegisterAsync(Register model)
        {
            var status = new Status();
            var userExist = await userManager.FindByNameAsync(model.Username);

            if (userExist != null)
            {
                status.StatusCode = 0;
                status.Message = "User Already Existed";
                return status;
            }

            ApplicationUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = model.Name,
                UserName = model.Username,
                Email = model.Email,
                EmailConfirmed = true,
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User Creation Faild";
                return status;
            }
            if (!await roleManager.RoleExistsAsync(model.Role))
                await roleManager.CreateAsync(new IdentityRole(model.Role));

            if (await roleManager.RoleExistsAsync(model.Role))
            {
                await userManager.AddToRoleAsync(user, model.Role);
            }

            status.StatusCode = 1;
            status.Message = "User Create Successfully";
            return status;
        }
    }
}
