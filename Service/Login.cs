using MongoDB.Driver;
using CareCenterApi.Model; 

namespace CareCenterApi.Service
{
    public class Login : ILogin
    {
        private readonly IMongoCollection<LoginUser> _loginUserCollection;

        public Login(IMongoDatabase database)
        {
            _loginUserCollection = database.GetCollection<LoginUser>("LoginUser");
        }
        public async Task<string> Signup(LoginUser model)
        {
            var loginUser = new LoginUser
            {
            UserName = model.UserName,
            Password = model.Password,
            Email = model.Email
            };

            await _loginUserCollection.InsertOneAsync(loginUser);
            return loginUser.UserName;
        }
        public async Task<string> Signin(string userName, string password)
        {
            var filter = Builders<LoginUser>.Filter.Eq(u => u.UserName, userName) & Builders<LoginUser>.Filter.Eq(u => u.Password, password);
            var user = await _loginUserCollection.Find(filter).FirstOrDefaultAsync();

            if (user != null)
            {
                return user.UserName;
            }

            return "Failure";
        }
    }
}
