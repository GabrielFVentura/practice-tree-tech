using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Base;

namespace Domain.Interfaces.IRepository.Base
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> CadastrarAsync(T item);
        Task<T> AtualizarAsync(T item);
        Task<bool> DeletarAsync(Guid id);
        Task<T> BuscarAsync(Guid id);
        Task<IEnumerable<T>> BuscarAsync();
    }
}