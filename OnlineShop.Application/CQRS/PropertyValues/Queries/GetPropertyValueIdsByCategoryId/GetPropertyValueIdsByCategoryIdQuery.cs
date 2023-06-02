using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.PropertyValues.Queries.GetPropertyValueIdsByCategoryId
{
    public class GetPropertyValueIdsByCategoryIdQuery : IRequest<List<int>>
    {
        [Required]
        public int CategoryId { get; set; }
    }
}
