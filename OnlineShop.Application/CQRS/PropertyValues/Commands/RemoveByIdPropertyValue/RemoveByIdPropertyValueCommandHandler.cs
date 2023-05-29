using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.PropertyValues.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.PropertyValues.Commands.RemoveByIdPropertyValue
{
    public class RemoveByIdPropertyValueCommandHandler : PropertyValueHandler, IRequestHandler<RemoveByIdPropertyValueCommand>
    {
        public RemoveByIdPropertyValueCommandHandler(IRepository<PropertyValue, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(RemoveByIdPropertyValueCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
        }
    }
}
