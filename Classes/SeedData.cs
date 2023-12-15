using Microsoft.AspNetCore.Identity;
using Portfolio.Areas.Admin.Models;

namespace Portfolio.Classes
{
    public static class SeedData
    {
        public async static Task GenerateFirstUser(UserManager<User> userManager)
        {
            if (await userManager.FindByNameAsync("Admin") is null)
            {
                var user = new User
                {
                    UserName = "Admin",
                    Email = "mirze0777@gmail.com"
                };

              IdentityResult result =  await userManager.CreateAsync(user, "Codelandia123@#$");
                if (result.Succeeded)
                {

                }
            }
           
        }
    }
}
