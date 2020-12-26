using System.Threading.Tasks;
using Ajhs.Domain.Models;

namespace Ajhs.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task teste();
        Task<Usuario> Obter(string login);
        Task Incluir(Usuario usuario);
    }
}