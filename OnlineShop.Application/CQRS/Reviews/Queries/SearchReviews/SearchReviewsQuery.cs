using System.ComponentModel.DataAnnotations;

using MediatR;

using OnlineShop.Application.CQRS.Reviews.DTOs;
using OnlineShop.Domain.Models;



public class SearchReviewsQuery : IRequest<List<GetReviewDTO>>
{
    public int ProductId { get; set; }
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
}
