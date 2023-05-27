using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.Properties.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Properties.Commands.UpdateProperty
{
    public class UpdatePropertyCommandHandler : PropertyHandler, IRequestHandler<UpdatePropertyCommand>
    {
        public UpdatePropertyCommandHandler(IRepository<Property, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            var property = await _repository.GetByIdAsync(request.Id);
            property.Name = request.Name;

            await _repository.UpdateAsync(property);
        }
    }
}
