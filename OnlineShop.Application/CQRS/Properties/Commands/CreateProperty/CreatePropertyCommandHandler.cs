﻿using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Properties.Handlers;
using OnlineShop.Application.CQRS.Reviews.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Properties.Commands.CreateProperty
{
    public class CreateReviewCommandHandler : ReviewHandler, IRequestHandler<CreateReviewCommand, int>
    {
        public CreateReviewCommandHandler(IRepository<Property, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            Property property = new Property { Name = request.Name };

            int id = await _repository.AddAsync(property);

            return id;
        }
    }
}
