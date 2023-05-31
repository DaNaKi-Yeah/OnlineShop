using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Reviews.DTOs
{
    public class GetReviewDTO : IMapWith<Review>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreateDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Review, GetReviewDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.ProductId, opt => opt.MapFrom(y => y.ProductId))
                .ForMember(x => x.ProductName, opt => opt.MapFrom(y => y.Product.ModelName))
                .ForMember(x => x.Comment, opt => opt.MapFrom(y => y.Comment))
                .ForMember(x => x.Rating, opt => opt.MapFrom(y => y.Rating))
                .ForMember(x => x.CreateDate, opt => opt.MapFrom(y => y.CreateDate));
        }
    }
}
