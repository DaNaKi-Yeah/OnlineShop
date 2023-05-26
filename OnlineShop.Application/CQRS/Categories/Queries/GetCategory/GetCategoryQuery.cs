﻿using MediatR;
using OnlineShop.Application.CQRS.Categories.DTOs;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Categories.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<GetCategoryDTO>
    {
        public int Id { get; set; }
    }
}