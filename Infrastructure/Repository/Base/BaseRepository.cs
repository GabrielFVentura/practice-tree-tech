using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Base;
using Domain.Interfaces.IRepository.Base;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Base
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly TreeTechContext _context;
        private DbSet<T> _dataSet;
        public BaseRepository(TreeTechContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }
        public async Task<T> CadastrarAsync(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                    item.Id = Guid.NewGuid();
                
                item.DataCadastro = DateTime.Now;
                _dataSet.Add(item);

                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }

            return item;
        }

        public async Task<T> AtualizarAsync(T item)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

                if (result == null) return null;
            
                item.DataAlteracao = DateTime.Now;
                item.DataCadastro = result.DataCadastro;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return item;
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null) return false;

                _dataSet.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> BuscarAsync(Guid id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> BuscarAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}