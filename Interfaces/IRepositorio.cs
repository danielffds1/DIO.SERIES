using System.Collections.Generic;

namespace DIO.SERIES.Interfaces
{
    public interface IRepositorio<T>
    {
        //Métodos que deverão ser implementados
         List<T> Lista();
         T RetornaPorId(int id);
         void Insere(T entidade);
         void Excluir(int id);
         void Atualiza(int id, T entidade);
         int ProximoId();
    }
}