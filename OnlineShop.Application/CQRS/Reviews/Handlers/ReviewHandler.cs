using AutoMapper;

using OnlineShop.Application.Common;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Reviews.Handlers
{
    public class ReviewHandler : BaseHandler<Review, int>
    {
        public ReviewHandler(IRepository<Review, int> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
