using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.BuyItems.Queries.SearchBuyItemsByUserId;
using OnlineShop.Application.CQRS.Carts.DTOs;
using OnlineShop.Application.CQRS.Carts.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Carts.Queries.SearchCartsByUserId
{
    public class GetCartByUserIdQueryHandler : CartHandler, IRequestHandler<GetCartByUserIdQuery, GetCartDTO>
    {
        private readonly IRepository<User, int> _userRepository;
        private readonly IMediator _mediator;

        public GetCartByUserIdQueryHandler(
            IRepository<Cart, int> repository,
            IRepository<User, int> userRepository,
            IMediator mediator,
            IMapper mapper)
            : base(repository, mapper)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<GetCartDTO> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            var cartId = (await _userRepository.GetByIdAsync(request.UserId)).CartId;

            var getCart = _mapper.Map<GetCartDTO>(await _repository.GetByIdAsync((int)cartId));

            var query = new SearchBuyItemsByUserIdQuery() { PageSize = 1 , PageNumber=1, UserId = request.UserId };

            var getBuyItems = await _mediator.Send(query);

            getCart.BuyItems = getBuyItems;

            return getCart;
        }
    }
}
