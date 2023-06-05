using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BuyItems.Commands.CreateBuyItem
{
    public class CreateBuyItemCommand : IRequest<int>
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int InventoryId { get; set; }
    }
}
