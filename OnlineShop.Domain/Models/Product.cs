using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Product : BaseEnitity<int>
    {
        public string ModelName { get; set; }
        public int YearOfProduction { get; set; }
        public string Description { get; set; }
        public string PictureLink { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int? CategoryId { get; set; }
    }
}
