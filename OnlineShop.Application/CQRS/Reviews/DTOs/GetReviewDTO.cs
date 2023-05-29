using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Reviews.DTOs
{
    public class GetReviewDTO : IMapWith<Review>
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
