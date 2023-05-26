using MediatR;
using OnlineShop.Domain.Models;



public class SearchReviewsQuery : IRequest<List<Review>>
{
    public string? Search { get; set; }
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
}
