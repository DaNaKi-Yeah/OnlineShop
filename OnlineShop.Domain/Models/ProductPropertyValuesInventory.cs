namespace OnlineShop.Domain.Models
{
    internal class ProductPropertyValuesInventory
    {
        public int ProductPropertyValuesId { get; set; }
        public ProductPropertyValue ProductPropertyValue { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
