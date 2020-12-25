using Google.Cloud.Firestore; 

namespace Ajhs.Infra.DbModels
{
    [FirestoreData]
    public class UsuarioDbModel
    { 
        [FirestoreProperty]
        public string Nome { get; set; } 
        
        [FirestoreProperty]
        public string Login { get; set; } 

        [FirestoreProperty]
        public string Email { get; set; } 

        [FirestoreProperty]
        public string Senha { get; set; }
    }
}