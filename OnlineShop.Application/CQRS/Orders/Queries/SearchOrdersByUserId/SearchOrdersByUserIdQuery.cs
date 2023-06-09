﻿using MediatR;

using OnlineShop.Application.CQRS.Orders.DTOs;
using OnlineShop.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.CQRS.Orders.Queries.SearchOrdersByUserId
{
    public class SearchOrdersByUserIdQuery : IRequest<List<GetOrderDTO>>
    {
        [Required]
        public int UserId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
