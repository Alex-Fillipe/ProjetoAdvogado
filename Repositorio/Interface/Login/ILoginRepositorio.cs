using Dominio.Login;
using System.Collections.Generic;

namespace Repositorio.Interface
{
    public interface ILoginRepositorio 
    {
        void Adicionar(Login login);
        void Atualizar(Login login);
        void Excluir(int id);
        Login ObterPorId(int id);
        Login ObterPorUsuario(string usuario);
        List<Login> ListarTodos();
    }
}
