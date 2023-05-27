using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Values.Commands.UpdateValue
{
    public class UpdateValueCommand : IRequest
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
