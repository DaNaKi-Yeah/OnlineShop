using MediatR;
using OnlineShop.Application.CQRS.BuyItems.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BuyItems.Queries.SearchBuyItemsByUserId
{
    public class SearchBuyItemsByUserIdQuery : IRequest<List<GetBuyItemDTO>>
    {
        [Required]
        public int UserId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
