using OnlineShop.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Models
{
    public class BuyItem: BaseEntity<int>
    {
        public int Count { get; set; }


        public int ProductPropertyValuesInventoryId { get; set; }
        public virtual ProductPropertyValuesInventory ProductPropertyValuesInventory { get; set; }
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
