using CheckAndTransferService.Repository.Entities;
using CheckAndTransferService.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckAndTransferService.DBCheckAndTransfer
{
    public class CheckAndTransfer : ICheckAndTransfer
    {
        public CheckAndTransfer(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        private readonly IUnitOfWork unitOfWork;

        public void Check(int valueToCheck)
        {
            IEnumerable<ItemsTable1> tableContent = unitOfWork.ItemsTable1Manager.GetRowsToProcess(valueToCheck);

            if (!tableContent.Any())
                return;

            foreach (ItemsTable1 row in tableContent)
            {
                if (row.ItemValue == valueToCheck)
                {
                    Transfer(row);
                }
            }
        }

        public void Transfer(ItemsTable1 table1Row)
        {
            ItemsTable2 table2Row = new ItemsTable2 { ItemInfo = table1Row.ItemInfo, ItemValue = table1Row.ItemValue, Table1ItemId = table1Row.Id };
            table1Row.ItemValue = 0;

            try
            {
                unitOfWork.BeginTransaction();

                unitOfWork.ItemsTable1Manager.Update(table1Row);
                unitOfWork.SaveChanges();

                unitOfWork.ItemsTable2Manager.Create(table2Row);
                unitOfWork.SaveChanges();

                unitOfWork.CommitTransaction();
            }
            catch
            {
                unitOfWork.RollbackTransaction();
            }
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    unitOfWork.Dispose();
                }

                disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(true);
        }
    }
}
