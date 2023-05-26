using System.ComponentModel.DataAnnotations;

using MediatR;

namespace OnlineShop.Application.CQRS.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<int>
    {
        public string Comment { get; set; }
        public int Rating { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
