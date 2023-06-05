using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BuyItems.Commands.CreateBuyItem
{
    public class CreateBuyItemCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int InventoryId { get; set; }
    }
}
