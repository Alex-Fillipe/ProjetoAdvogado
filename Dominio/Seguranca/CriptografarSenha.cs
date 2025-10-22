using System;
using System.Security.Cryptography;
using System.Text;

namespace Dominio.Seguranca
{
    public static class CriptografarSenha
    {
        public static string GerarHash(string senha)
        {
            if (string.IsNullOrEmpty(senha))
                return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(senha);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
