using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Application.CQRS.Products.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : ProductHandler, IRequestHandler<GetProductByIdQuery, GetProductDTO>
    {
        public GetProductByIdQueryHandler(IRepository<Product, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product product = await _repository.GetByIdAsync(request.Id);

            return _mapper.Map<GetProductDTO>(product);
        }
    }
}
