using MediatR;
using OnlineShop.Application.CQRS.Carts.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Carts.Queries.SearchCartsByUserId
{
    public class GetCartByUserIdQuery : IRequest<GetCartDTO> 
    {
        [Required]
        public int UserId { get; set; }
    }
}
