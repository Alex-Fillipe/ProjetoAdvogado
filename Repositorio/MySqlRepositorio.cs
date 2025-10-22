using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Repositorio
{
    public abstract class MySqlRepositorio
    {
        private readonly string _connectionString;

        protected MySqlRepositorio()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ProjetoAdvogadoDB"].ConnectionString;
        }

        /// <summary>
        /// Executa comandos INSERT, UPDATE ou DELETE
        /// </summary>
        protected void ExecutarNonQuery(string sql, Dictionary<string, object> parametros)
        {
            using (var conexao = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand(sql, conexao))
            {
                if (parametros != null)
                {
                    foreach (var par in parametros)
                    {
                        cmd.Parameters.AddWithValue(par.Key, par.Value);
                    }
                }

                conexao.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Executa uma query que retorna um único registro
        /// </summary>
        protected T ExecutarQuerySingle<T>(string sql, Dictionary<string, object> parametros, Func<MySqlDataReader, T> map)
        {
            using (var conexao = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand(sql, conexao))
            {
                if (parametros != null)
                {
                    foreach (var par in parametros)
                        cmd.Parameters.AddWithValue(par.Key, par.Value);
                }

                conexao.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return map(reader);
                    }
                }
            }
            return default;
        }

        /// <summary>
        /// Executa uma query que retorna uma lista de registros
        /// </summary>
        protected List<T> ExecutarQueryList<T>(string sql, Dictionary<string, object> parametros, Func<MySqlDataReader, T> map)
        {
            var lista = new List<T>();

            using (var conexao = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand(sql, conexao))
            {
                if (parametros != null)
                {
                    foreach (var par in parametros)
                        cmd.Parameters.AddWithValue(par.Key, par.Value);
                }

                conexao.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(map(reader));
                    }
                }
            }

            return lista;
        }

        /// <summary>
        /// Executa uma query que retorna um único valor
        /// </summary>
        protected object ExecutarEscalar(string sql, Dictionary<string, object> parametros)
        {
            using (var conexao = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand(sql, conexao))
            {
                if (parametros != null)
                {
                    foreach (var par in parametros)
                        cmd.Parameters.AddWithValue(par.Key, par.Value);
                }

                conexao.Open();
                return cmd.ExecuteScalar();
            }
        }

    }
}
