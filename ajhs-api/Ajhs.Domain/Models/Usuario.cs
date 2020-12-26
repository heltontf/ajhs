namespace Ajhs.Domain.Models
{
    public class Usuario
    {
        public Usuario(string id, string nome, string login, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Email = email;
            Senha = senha;
        }

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
    }
}