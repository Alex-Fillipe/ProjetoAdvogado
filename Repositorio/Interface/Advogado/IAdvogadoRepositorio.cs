using System.Collections.Generic;
using Dominio.Advogado;

namespace Repositorio.Interface
{
    public interface IAdvogadoRepositorio
    {
        void Adicionar(Advogado advogado);
        void Atualizar(Advogado advogado);
        void Excluir(int id);
        Advogado ObterPorId(int id);
        List<Advogado> ListarTodos();

    }
}
