﻿using MediatR;

using OnlineShop.Application.CQRS.Properties.DTOs;
using OnlineShop.Application.CQRS.Reviews.DTOs;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Properties.Queries.GetPropertyById
{
    public class GetPropertyByIdQuery : IRequest<GetPropertyDTO>
    {
        public int Id { get; set; }
    }
}
