namespace NewsSystem.Application.Identity.Commands.LoginUser
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using NewsSystem.Application.Common;
    using NewsSystem.Application.Identity;
    using NewsSystem.Application.Identity.Commands;
    using NewsSystem.Application.Identity.Commands.LoginUser;

    public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
    {
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginOutputModel>>
        {
            private readonly IIdentity identity;

            public LoginUserCommandHandler(IIdentity identity)
            {
                this.identity = identity;
            }

            public async Task<Result<LoginOutputModel>> Handle(
                LoginUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Login(request);

                var isJournalist = await this.identity.IsJournalist(result.Data.UserId);

                if (!result.Succeeded)
                {
                    return result.Errors;
                }

                var user = result.Data;
               // var journalistId = await this.journalistRepository.GetJournalistId(user.UserId, cancellationToken); NO WAY!
                return new LoginOutputModel(user.Token, isJournalist);   
            }
        }
    }
}
