using System;

namespace Dominio.Login
{
    [Serializable]
    public class Login
    {
        public int Id { get; set; }
        public string Nome { get; set; }  
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
