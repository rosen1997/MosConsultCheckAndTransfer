using System.Collections.Generic;

namespace CheckAndTransferService.Repository.RepositoryBase
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Create(T entity);

        void Update(T entity);
    }
}
