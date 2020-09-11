using System;
using System.Collections.Generic;
using System.Text;

namespace CheckAndTransferService.Repository.Entities
{
    public partial class ItemsTable1
    {
        public ItemsTable1()
        {
            ItemsTable2 = new HashSet<ItemsTable2>();
        }

        public int Id { get; set; }
        public string ItemInfo { get; set; }
        public int ItemValue { get; set; }

        public virtual ICollection<ItemsTable2> ItemsTable2 { get; set; }
    }
}
