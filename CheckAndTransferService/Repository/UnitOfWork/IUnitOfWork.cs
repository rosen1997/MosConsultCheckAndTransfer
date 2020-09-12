using CheckAndTransferService.Repository.Managers.Interfaces;
using System;

namespace CheckAndTransferService.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IItemsTable1Manager ItemsTable1Manager { get; }
        IItemsTable2Manager ItemsTable2Manager { get; }

        void SaveChanges();

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
