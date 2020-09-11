using System.Collections.Generic;

namespace CheckAndTransferService.Repository.RepositoryBase
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected MosConsultTestDbContext RepositoryContext { get; set; }


        public RepositoryBase(MosConsultTestDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }


        public virtual IEnumerable<T> GetAll()
        {
            return RepositoryContext.Set<T>();
        }

        public virtual void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }
    }
}
