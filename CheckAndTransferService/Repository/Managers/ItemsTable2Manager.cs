using CheckAndTransferService.Repository.Entities;
using CheckAndTransferService.Repository.Managers.Interfaces;
using CheckAndTransferService.Repository.RepositoryBase;

namespace CheckAndTransferService.Repository.Managers
{
    public class ItemsTable2Manager : RepositoryBase<ItemsTable2>, IItemsTable2Manager
    {
        public ItemsTable2Manager(MosConsultTestDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
