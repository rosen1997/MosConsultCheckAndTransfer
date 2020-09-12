using CheckAndTransferService.Repository.Managers;
using CheckAndTransferService.Repository.Managers.Interfaces;

namespace CheckAndTransferService.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MosConsultTestDbContext repositoryContext;

        public UnitOfWork(MosConsultTestDbContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
            ItemsTable1Manager = new ItemsTable1Manager(repositoryContext);
            ItemsTable2Manager = new ItemsTable2Manager(repositoryContext);
        }

        public IItemsTable1Manager ItemsTable1Manager { get; }
        public IItemsTable2Manager ItemsTable2Manager { get; }

        public void SaveChanges()
        {
            repositoryContext.SaveChanges();
        }

        public void BeginTransaction()
        {
            repositoryContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            repositoryContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            repositoryContext.Database.RollbackTransaction();
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    repositoryContext.Dispose();
                }
                this.disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
    }
}
