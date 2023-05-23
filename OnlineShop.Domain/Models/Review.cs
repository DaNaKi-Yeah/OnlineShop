using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Review: BaseEntity<int>
    {
        public string Comment { get; set; }
        public int Rating { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
