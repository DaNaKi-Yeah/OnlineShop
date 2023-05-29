using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.Properties.DTOs;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using OnlineShop.Application.CQRS.PropertyValues.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.PropertyValues.Commands.CreatePropertyValue
{
    public class CreatePropertyValueCommandHandler : PropertyValueHandler, IRequestHandler<CreatePropertyValueCommand, GetPropertyValueDTO>
    {
        public CreatePropertyValueCommandHandler(IRepository<PropertyValue, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetPropertyValueDTO> Handle(CreatePropertyValueCommand request, CancellationToken cancellationToken)
        {
            var propertyValue = _mapper.Map<PropertyValue>(request);

            int id = await _repository.AddAsync(propertyValue);

            var result = _mapper.Map<GetPropertyValueDTO>((await _repository.GetByIdAsync(id)));

            return result;
        }
    }
}
