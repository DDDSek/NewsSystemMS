namespace NewsSystem.Infrastructure.Identity
{
    using System.Linq;
    using System.Threading.Tasks;
    
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Application.Identity; 
    using Application.Common; 
    using Application.Identity.Commands;
    using Application.Identity.Commands.ChangePassword;
    using Application.Identity.Commands.LoginUser; 

    using static Infrastructure.Common.ConstantsInfrastructure;

    internal class IdentityService : IIdentity
    {
        private const string InvalidErrorMessage = "Invalid credentials.";

        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public IdentityService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result<IUser>> Register(UserInputModel userInput)
        {
            var user = new User(userInput.Email, userInput.UserName, userInput.PhoneNumber);

            var identityResult = await this.userManager.CreateAsync(user, userInput.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result<IUser>.SuccessWith(user)
                : Result<IUser>.Failure(errors);
        }

        public async Task<Result<LoginSuccessModel>> Login(UserInputModel userInput)
        {
            var user = await this.userManager.FindByEmailAsync(userInput.Email);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, userInput.Password);
            if (!passwordValid)
            {
                return InvalidErrorMessage;
            }

            var token = this.jwtTokenGenerator.GenerateToken(user);

            return new LoginSuccessModel(user.Id, token);
        }

        public async Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput)
        {
            var user = await this.userManager.FindByIdAsync(changePasswordInput.UserId);

            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var identityResult = await this.userManager.ChangePasswordAsync(
                user,
                changePasswordInput.CurrentPassword,
                changePasswordInput.NewPassword);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }

        public async Task<string> IsJournalist(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            var userInRole = await userManager.IsInRoleAsync(user, "journalist");
            
            if (!userInRole)
            {
                return Roles.NoJournalist;
            }
            return Roles.Confirmed;
        }

        public async Task<Result> AddToRoleJournalist(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user is null)
            {
                return Result.Failure(System.Array.Empty<string>());   
            } 

            var inRole = await userManager.IsInRoleAsync(user, Roles.Journalist);

            if (!inRole)
            {
                await userManager.AddToRoleAsync(user, Roles.Journalist);

            } 

            return Result.Success;
        }
    }
}
