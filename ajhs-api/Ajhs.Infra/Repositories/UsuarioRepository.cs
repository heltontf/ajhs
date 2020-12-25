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

        public async Task teste()
        {
            CollectionReference colRef = _fireStoreDb.Collection("usuarios"); 

            var usuario = new Usuario("Helton Faria", "heltontf", "helton.faria@outlook.com.br", "123456");

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