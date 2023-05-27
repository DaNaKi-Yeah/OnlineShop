using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Product : BaseEntity<int>
    {
        public string ModelName { get; set; }
        public int? YearOfProduction { get; set; }
        public string Description { get; set; }
        public string PictureLink { get; set; }
        public decimal Price { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual List<ProductPropertyValuesInventory> ProductPropertyValuesInventories { get; set; }
        public virtual List<BuyItem> BuyItems { get; set; }
    }
}
