using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.Values.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Values.Commands.UpdateValue
{
    public class UpdateValueCommandHandler : ValueHandler, IRequestHandler<UpdateValueCommand>
    {
        public UpdateValueCommandHandler(IRepository<Value, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(UpdateValueCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.Name = request.Name;

            await _repository.UpdateAsync(value);
        }
    }
}
