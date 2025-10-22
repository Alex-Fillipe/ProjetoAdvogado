using Dominio.Advogado;
using Dominio.Enums;
using Repositorio.Interface;
using System;
using System.Collections.Generic;

namespace Repositorio.Implementacao
{
    public class AdvogadoRepositorio : MySqlRepositorio, IAdvogadoRepositorio
    {
        public void Adicionar(Advogado advogado)
        {
            string sql = @"INSERT INTO advogado 
                           (Nome, Senioridade, Logradouro, Bairro, Estado, CEP, Numero, Complemento)
                           VALUES (@Nome, @Senioridade, @Logradouro, @Bairro, @Estado, @CEP, @Numero, @Complemento)";

            var parametros = new Dictionary<string, object>
            {
                { "@Nome", advogado.Nome },
                { "@Senioridade", advogado.Senioridade.ToString() },
                { "@Logradouro", advogado.Logradouro },
                { "@Bairro", advogado.Bairro },
                { "@Estado", advogado.Estado.ToString() },  
                { "@CEP", advogado.CEP },
                { "@Numero", advogado.Numero },
                { "@Complemento", advogado.Complemento }
            };

            ExecutarNonQuery(sql, parametros);
        }

        public void Atualizar(Advogado advogado)
        {
            string sql = @"UPDATE advogado SET 
                           Nome=@Nome, Senioridade=@Senioridade, Logradouro=@Logradouro, 
                           Bairro=@Bairro, Estado=@Estado, CEP=@CEP, Numero=@Numero, Complemento=@Complemento
                           WHERE Id=@Id";

            var parametros = new Dictionary<string, object>
            {
                { "@Id", advogado.Id },
                { "@Nome", advogado.Nome },
                { "@Senioridade", advogado.Senioridade.ToString() },
                { "@Logradouro", advogado.Logradouro },
                { "@Bairro", advogado.Bairro },
                { "@Estado", advogado.Estado.ToString() },  
                { "@CEP", advogado.CEP },
                { "@Numero", advogado.Numero },
                { "@Complemento", advogado.Complemento }
            };

            ExecutarNonQuery(sql, parametros);
        }

        public void Excluir(int id)
        {
            string sql = "DELETE FROM advogado WHERE Id=@Id";
            var parametros = new Dictionary<string, object> { { "@Id", id } };
            ExecutarNonQuery(sql, parametros);
        }

        public Advogado ObterPorId(int id)
        {
            string sql = "SELECT * FROM advogado WHERE Id=@Id";
            var parametros = new Dictionary<string, object> { { "@Id", id } };

            return ExecutarQuerySingle(sql, parametros, reader => new Advogado
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nome = reader["Nome"].ToString(),
                Senioridade = (SenioridadeEnum)Enum.Parse(typeof(SenioridadeEnum), reader["Senioridade"].ToString()),
                Logradouro = reader["Logradouro"].ToString(),
                Bairro = reader["Bairro"].ToString(),
                Estado = (EstadoEnum)Enum.Parse(typeof(EstadoEnum), reader["Estado"].ToString()),  
                CEP = reader["CEP"].ToString(),
                Numero = Convert.ToInt32(reader["Numero"]),
                Complemento = reader["Complemento"].ToString()
            });
        }

        public List<Advogado> ListarTodos()
        {
            string sql = "SELECT * FROM advogado";

            return ExecutarQueryList(sql, null, reader => new Advogado
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nome = reader["Nome"].ToString(),
                Senioridade = (SenioridadeEnum)Enum.Parse(typeof(SenioridadeEnum), reader["Senioridade"].ToString()),
                Logradouro = reader["Logradouro"].ToString(),
                Bairro = reader["Bairro"].ToString(),
                Estado = (EstadoEnum)Enum.Parse(typeof(EstadoEnum), reader["Estado"].ToString()),  
                CEP = reader["CEP"].ToString(),
                Numero = Convert.ToInt32(reader["Numero"]),
                Complemento = reader["Complemento"].ToString()
            });
        }
    }
}
