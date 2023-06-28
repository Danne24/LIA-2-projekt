namespace Zhipster.Internal.Api.Location.Features.UserService
{
    public interface IZhipsterUserService
    {
        bool ValidateCredentials(string username, string password);
    }
}
