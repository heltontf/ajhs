using System.Linq;
using System;
using Ajhs.Domain.Interfaces;
using Ajhs.Domain.Models;
using Ajhs.Infra.DbModels;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Ajhs.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly FirestoreDb _fireStoreDb; 

        public UsuarioRepository() 
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "/home/daniela/Downloads/ajhs.json");
            _fireStoreDb = FirestoreDb.Create("ajhs-299719"); 
        }

        public async Task<Usuario> Obter(string login)
        {
            var collection = _fireStoreDb.Collection("usuarios");

            var snapshot = await collection.WhereEqualTo("Login", login).GetSnapshotAsync();

            var documento = snapshot.Documents.FirstOrDefault();

            if (documento.Exists)
            {
                var usuario = documento.ConvertTo<UsuarioDbModel>();

                return new Usuario(documento.Id, usuario.Nome, usuario.Login, usuario.Email, usuario.Senha);
            }

            return default(Usuario);
        }

        public async Task Incluir(Usuario usuario)
        {
            var collection = _fireStoreDb.Collection("usuarios"); 

            await collection.AddAsync(new UsuarioDbModel()
            {
                Nome = usuario.Nome,
                Login = usuario.Login,
                Email = usuario.Email,
                Senha = usuario.Senha
            });
        }

        public async Task teste()
        {
            CollectionReference colRef = _fireStoreDb.Collection("usuarios"); 
            
            var usuario = new Usuario(string.Empty, "Helton Faria", "heltontf", "helton.faria@outlook.com.br", "123456");

            await colRef.AddAsync(new UsuarioDbModel()
            {
                Nome = usuario.Nome,
                Login = usuario.Login,
                Email = usuario.Email,
                Senha = usuario.Senha
            });  
        }
    }
}