using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Properties.Commands.RemoveProperty;
using OnlineShop.Application.CQRS.Properties.Handlers;
using OnlineShop.Application.CQRS.Values.Commands.RemoveByIdValue;
using OnlineShop.Application.CQRS.Values.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Properties.Commands.RemoveByIdProperty
{
    public class RemoveByIdCategoryCommandHandler : CategoryHandler, IRequestHandler<RemoveByIdCategoryCommand>
    {
        public RemoveByIdCategoryCommandHandler(IRepository<Category, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(RemoveByIdCategoryCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
        }
    }
}
