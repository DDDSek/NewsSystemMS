namespace NewsSystem.Startup
{
    using Microsoft.AspNetCore.Identity;
    public static class IdentityDataInitializer
    {
        public static void SeedData(RoleManager<IdentityRole> roleManager)
        {
        }

        // TO DO: TO USE IT IN IDENTITY MICROSERVICE LATER
        //public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        //{
        //    var roles = await roleManager.RoleExistsAsync(Roles.Journalist);

        //    // if not write it
        //    if (!roles)
        //    {
        //        var role = new IdentityRole(Roles.Journalist);
        //        await roleManager.CreateAsync(role);
        //    }
        //}
    }
}
