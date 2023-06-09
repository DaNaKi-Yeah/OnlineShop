﻿using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using OnlineShop.Application.CQRS.CategoryProperties.DTOs;
using OnlineShop.Application.CQRS.CategoryProperties.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.CategoryProperties.Commands.CreateCategoryProperty
{
    internal class CreateCategoryPropertyCommandHandler : CategoryPropertyHandler, IRequestHandler<CreateCategoryPropertyCommand, int>
    {
        public CreateCategoryPropertyCommandHandler(IRepository<CategoryProperty, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<int> Handle(CreateCategoryPropertyCommand request, CancellationToken cancellationToken)
        {
            var categoryProperty = _mapper.Map<CategoryProperty>(request);

            var id = await _repository.AddAsync(categoryProperty);

            return id;
        }
    }
}
