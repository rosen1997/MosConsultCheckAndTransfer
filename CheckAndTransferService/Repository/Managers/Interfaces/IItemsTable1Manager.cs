using CheckAndTransferService.Repository.Entities;
using CheckAndTransferService.Repository.RepositoryBase;
using System.Collections.Generic;

namespace CheckAndTransferService.Repository.Managers.Interfaces
{
    public interface IItemsTable1Manager : IRepositoryBase<ItemsTable1>
    {
        IEnumerable<ItemsTable1> GetRowsToProcess(int num);
    }
}
