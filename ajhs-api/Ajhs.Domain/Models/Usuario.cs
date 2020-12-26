namespace Ajhs.Domain.Models
{
    public class Usuario
    {
        public Usuario(string nome, string login, string email, string senha)
        {
            Nome = nome;
            Login = login;
            Email = email;
            Senha = senha;
        }

        public void CriptografarSenha()
        {
            Senha = new Senha(Senha).ToString();
        }

        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
    }
}