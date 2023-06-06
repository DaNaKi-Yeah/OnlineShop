using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Models;

namespace OnlineShop.API.Identity
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<UserAccount> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "_Aa123456adfew";
            string firstName = "Admin";
            string lastName = "Admin";

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<int>("admin"));
            }

            if (await roleManager.FindByNameAsync("client") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<int>("client"));
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                UserAccount admin = new UserAccount
                {
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = adminEmail,
                    Email = adminEmail,
                    NormalizedEmail = adminEmail.Normalize(),
                    NormalizedUserName = adminEmail.Normalize(),
                };

                IdentityResult result = await userManager.CreateAsync(admin, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}

