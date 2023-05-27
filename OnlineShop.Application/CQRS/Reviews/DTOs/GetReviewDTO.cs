using AutoMapper;

using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.Relations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Reviews.DTOs
{
    public class GetReviewDTO : IMapWith<Review>
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
