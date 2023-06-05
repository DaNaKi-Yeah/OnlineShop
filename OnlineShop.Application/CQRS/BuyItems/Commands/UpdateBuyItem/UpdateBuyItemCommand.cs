using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BuyItems.Commands.UpdateBuyItem
{
    public class UpdateBuyItemCommand : IRequest
    {
        public int Id { get; set; }
        public int Count { get; set; }
    }
}
