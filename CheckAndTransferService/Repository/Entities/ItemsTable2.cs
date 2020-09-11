using System;
using System.Collections.Generic;
using System.Text;

namespace CheckAndTransferService.Repository.Entities
{
    public partial class ItemsTable2
    {
        public int Id { get; set; }
        public int Table1ItemId { get; set; }
        public string ItemInfo { get; set; }
        public int ItemValue { get; set; }

        public virtual ItemsTable1 Table1Item { get; set; }
    }
}
