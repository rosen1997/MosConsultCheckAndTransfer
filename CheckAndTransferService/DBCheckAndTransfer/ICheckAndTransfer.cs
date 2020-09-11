using CheckAndTransferService.Repository.Entities;
namespace CheckAndTransferService.DBCheckAndTransfer
{
    public interface ICheckAndTransfer
    {
        void Check(int valueToCheck);
        void Transfer(ItemsTable1 table1Row);
    }
}
