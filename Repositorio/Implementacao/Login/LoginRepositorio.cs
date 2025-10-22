using Dominio.Login;
using Dominio.Seguranca;  
using Repositorio.Interface;
using System;
using System.Collections.Generic;

namespace Repositorio.Implementacao
{
    public class LoginRepositorio : MySqlRepositorio, ILoginRepositorio
    {
        public void Adicionar(Login login)
        {
            string sql = @"INSERT INTO login (Nome, Usuario, Senha)
                           VALUES (@Nome, @Usuario, @Senha)";

            
            string senhaCriptografada = CriptografarSenha.GerarHash(login.Senha);

            var parametros = new Dictionary<string, object>
            {
                { "@Nome", login.Nome },
                { "@Usuario", login.Usuario },
                { "@Senha", senhaCriptografada }
            };

            ExecutarNonQuery(sql, parametros);
        }

        public void Atualizar(Login login)
        {
            string sql = @"UPDATE login SET 
                           Nome=@Nome, Usuario=@Usuario, Senha=@Senha
                           WHERE Id=@Id";

          
            string senhaCriptografada = CriptografarSenha.GerarHash(login.Senha);

            var parametros = new Dictionary<string, object>
            {
                { "@Id", login.Id },
                { "@Nome", login.Nome },
                { "@Usuario", login.Usuario },
                { "@Senha", senhaCriptografada }
            };

            ExecutarNonQuery(sql, parametros);
        }

        public void Excluir(int id)
        {
            string sql = "DELETE FROM login WHERE Id=@Id";
            var parametros = new Dictionary<string, object> { { "@Id", id } };
            ExecutarNonQuery(sql, parametros);
        }

        public Login ObterPorId(int id)
        {
            string sql = "SELECT * FROM login WHERE Id=@Id";
            var parametros = new Dictionary<string, object> { { "@Id", id } };

            return ExecutarQuerySingle(sql, parametros, reader => new Login
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nome = reader["Nome"].ToString(),
                Usuario = reader["Usuario"].ToString(),
                Senha = reader["Senha"].ToString()
            });
        }

        public Login ObterPorUsuario(string usuario)
        {
            string sql = "SELECT * FROM login WHERE Usuario=@Usuario";
            var parametros = new Dictionary<string, object> { { "@Usuario", usuario } };

            return ExecutarQuerySingle(sql, parametros, reader => new Login
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nome = reader["Nome"].ToString(),
                Usuario = reader["Usuario"].ToString(),
                Senha = reader["Senha"].ToString()
            });
        }

        public List<Login> ListarTodos()
        {
            string sql = "SELECT * FROM login";

            return ExecutarQueryList(sql, null, reader => new Login
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nome = reader["Nome"].ToString(),
                Usuario = reader["Usuario"].ToString(),
                Senha = reader["Senha"].ToString()
            });
        }

         
        public bool Autenticar(string usuario, string senhaDigitada)
        {
            string sql = "SELECT Senha FROM login WHERE Usuario = @Usuario";
            var parametros = new Dictionary<string, object> { { "@Usuario", usuario } };

            string senhaBanco = ExecutarEscalar(sql, parametros)?.ToString();

            if (string.IsNullOrEmpty(senhaBanco))
                return false;

           
            string senhaCriptografada = CriptografarSenha.GerarHash(senhaDigitada);

           
            return senhaBanco == senhaCriptografada;
        }
    }
}
