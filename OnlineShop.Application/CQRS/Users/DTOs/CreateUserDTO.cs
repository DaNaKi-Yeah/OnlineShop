using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Users.DTOs
{
    public class CreateUserDTO
    {
        public int UserId { get; set; }
        public int CartId { get; set; }
    }
}
