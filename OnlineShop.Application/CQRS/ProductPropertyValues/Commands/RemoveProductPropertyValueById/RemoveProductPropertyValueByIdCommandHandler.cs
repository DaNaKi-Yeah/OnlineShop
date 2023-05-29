using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.ProductPropertyValues.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValues.Commands.RemoveProductPropertyValueById
{
    public class RemoveProductPropertyValueByIdCommandHandler : ProductPropertyValueHandler, IRequestHandler<RemoveProductPropertyValueByIdCommand>
    {
        public RemoveProductPropertyValueByIdCommandHandler(IRepository<ProductPropertyValue, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(RemoveProductPropertyValueByIdCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
        }
    }
}
