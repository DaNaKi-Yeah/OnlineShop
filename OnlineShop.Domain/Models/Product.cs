using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Product : BaseEnitity<int>
    {
        public string ModelName { get; set; }
        public int? YearOfProduction { get; set; }
        public string Description { get; set; }
        public string PictureLink { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Review> Reviews { get; set; }
        public List<ProductPropertyValuesInventory> ProductPropertyValuesInventories { get; set; }
        public List<BuyItem> BuyItems { get; set; }
    }
}
