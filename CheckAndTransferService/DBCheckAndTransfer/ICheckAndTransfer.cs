using CheckAndTransferService.Repository.Entities;
using System;

namespace CheckAndTransferService.DBCheckAndTransfer
{
    public interface ICheckAndTransfer : IDisposable
    {
        void Check(int valueToCheck);
        void Transfer(ItemsTable1 table1Row);
    }
}
