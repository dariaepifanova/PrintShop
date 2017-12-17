namespace PrintShop.data
{
    public class AuthToken
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public AuthToken(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public AuthToken()
        {

        }
    }
}
