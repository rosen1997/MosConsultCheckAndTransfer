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
    }
}
