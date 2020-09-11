using CheckAndTransferService.Repository.Entities;
using CheckAndTransferService.Repository.Managers.Interfaces;
using CheckAndTransferService.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace CheckAndTransferService.Repository.Managers
{
    public class ItemsTable1Manager : RepositoryBase<ItemsTable1>, IItemsTable1Manager
    {
        public ItemsTable1Manager(MosConsultTestDbContext repositoryContext) : base(repositoryContext)
        {

        }

        public IEnumerable<ItemsTable1> GetRowsToProcess(int num)
        {
            return RepositoryContext.ItemsTable1.Include(x => x.ItemsTable2).Where(x => x.ItemValue == num).ToList();
        }
    }
}
