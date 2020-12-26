using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Ajhs.Domain.Models
{
    public class Senha
    {
        public Senha(string senha)
        {
            // byte[] salt = new byte[128 / 8];
            // using (var rng = RandomNumberGenerator.Create())
            // {
            //     rng.GetBytes(salt);
            // }
            // Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            var salt = Convert.FromBase64String("AbFSoqbRHLPGOadqQT3dzw==");
    
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            Valor = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: senha,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }

        public string Valor { get; set; }

        public override string ToString() => Valor;
    }
}