namespace NewsSystem.Application.Identity.Commands.LoginUser
{
    public class LoginOutputModel
    {
        public LoginOutputModel(string token, string journalist) 
        {
            this.Token = token;
            this.Journalist = journalist;
        }  

        public string Token { get; }

        public string Journalist { get; }
    }
}
