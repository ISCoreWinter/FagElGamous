﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models
{
    public class IdentitySeedData
    {
        public static void CreateAdminAccount(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            CreateAdminAccountAsync(serviceProvider, configuration).Wait();
        }
        public static async Task CreateAdminAccountAsync(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            serviceProvider = serviceProvider.CreateScope().ServiceProvider;
            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string username = configuration["Data:AdminUser:Name"] ?? "admin";
            string email = configuration["Data:AdminUser:Email"] ?? "admin@example.com";
            string password = configuration["Data:AdminUser:Password"] ?? "1qaz@wsx3e";
            string role = configuration["Data:AdminUser:Role"] ?? "Admins";
            string role2 = configuration["Data:AdminUser:Role"] ?? "Researchers";

            if (await userManager.FindByNameAsync(username) == null)
            {

                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                    await roleManager.CreateAsync(new IdentityRole(role2));
                }
                IdentityUser user = new IdentityUser
                {
                    UserName = username,
                    Email = email
                };

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
