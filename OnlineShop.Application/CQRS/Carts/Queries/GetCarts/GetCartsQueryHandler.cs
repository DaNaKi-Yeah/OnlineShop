using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.Carts.DTOs;
using OnlineShop.Application.CQRS.Carts.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Carts.Queries.SearchCarts
{
    public class GetCartsQueryHandler : CartHandler,IRequestHandler<GetCartsQuery, List<GetCartDTO>>
    {
        public GetCartsQueryHandler(IRepository<Cart, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<GetCartDTO>> Handle(GetCartsQuery request, CancellationToken cancellationToken)
        {
            var getCarts = _mapper.Map<List<GetCartDTO>>(await _repository.GetAllAsync());

            if (request == null)
            {
                return getCarts;
            }
            else if (request.PageSize == null || request.PageNumber == null)
            {
                return getCarts;
            }

            return getCarts
                .Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                .Take(request.PageSize.Value).ToList();
        }
    }
}
