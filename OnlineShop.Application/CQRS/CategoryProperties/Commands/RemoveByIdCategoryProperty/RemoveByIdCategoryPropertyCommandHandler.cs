using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.CategoryProperties.Commands.CreateCategoryProperty;
using OnlineShop.Application.CQRS.CategoryProperties.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.CategoryProperties.Commands.RemoveByIdCategoryProperty
{
    public class RemoveByIdCategoryPropertyCommandHandler : CategoryPropertyHandler, IRequestHandler<RemoveByIdCategoryPropertyCommand>
    {
        public RemoveByIdCategoryPropertyCommandHandler(IRepository<CategoryProperty, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(RemoveByIdCategoryPropertyCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
        }
    }
}
