using CareCenterApi.Model;

namespace CareCenterApi.Service
{
    public interface ILogin
    {
        Task<string> Signup(LoginUser model);
        Task<string> Signin(string userName, string password);
    }

}