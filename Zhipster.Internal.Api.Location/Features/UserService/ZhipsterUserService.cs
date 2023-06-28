namespace Zhipster.Internal.Api.Location.Features.UserService
{
    public class ZhipsterUserService : IZhipsterUserService
    {
        public bool ValidateCredentials(string username, string password)
        {
            return username.Equals("Admin") && password.Equals("Password");
        }
    }
}
