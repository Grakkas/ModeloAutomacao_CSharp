
namespace ModeloAutomacao_CSharp.Model
    {
    class CustomerModel
        {
        private string _email;
        public string Email { get => _email; set => _email = value; }

        private string _password;
        public string Password { get => _password; set => _password = value; }

        public CustomerModel(string email, string password)
            {
            Email = email;
            Password = password;
            }
        }
    }
