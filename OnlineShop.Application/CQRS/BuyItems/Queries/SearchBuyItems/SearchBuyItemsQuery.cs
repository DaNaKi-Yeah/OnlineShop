using MediatR;
using OnlineShop.Application.CQRS.BuyItems.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BuyItems.Queries.SearchBuyItems
{
    public class SearchBuyItemsQuery : IRequest<List<GetBuyItemDTO>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
