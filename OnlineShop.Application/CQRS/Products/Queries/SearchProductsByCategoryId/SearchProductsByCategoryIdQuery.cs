using MediatR;

using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace OnlineShop.Application.CQRS.Products.Queries.SearchProductsByCategoryId
{
    public class SearchProductsByCategoryIdQuery : IRequest<List<SearchProductDTO>>
    {
        [Required]
        public int CategoryId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }

    //protected class Filter
    //{
    //    public int MyProperty { get; set; }
    //    public List<int> PropertyValues { get; set; }
    //}
}
