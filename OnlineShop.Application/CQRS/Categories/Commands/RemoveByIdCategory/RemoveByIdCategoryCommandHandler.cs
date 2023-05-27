using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Categories.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Categories.Commands.RemoveByIdCategory
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
