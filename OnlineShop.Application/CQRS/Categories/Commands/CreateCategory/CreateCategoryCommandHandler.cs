using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Categories.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : CategoryHandler, IRequestHandler<CreateCategoryCommand, int>
    {
        public CreateCategoryCommandHandler(IRepository<Category, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new Category { Name = request.Name };

            int id = await _repository.AddAsync(category);

            return id;
        }
    }
}
