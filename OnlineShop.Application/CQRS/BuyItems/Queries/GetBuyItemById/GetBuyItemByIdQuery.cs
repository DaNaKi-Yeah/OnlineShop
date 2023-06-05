using MediatR;
using OnlineShop.Application.CQRS.BuyItems.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BuyItems.Queries.GetBuyItemById
{
    public class GetBuyItemByIdQuery : IRequest<GetBuyItemDTO>
    {
        [Required]
        public int Id { get; set; }
    }
}
