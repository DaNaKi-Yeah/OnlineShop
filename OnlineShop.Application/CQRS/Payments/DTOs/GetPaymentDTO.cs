﻿using AutoMapper;

using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.Relations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Payments.DTOs
{
    public class GetPaymentDTO : IMapWith<Payment>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Payment, GetPropertyDTO>()
                .ForMember(gp => gp.Id, opt => opt.MapFrom(p => p.Id))
                .ForMember(gp => gp.Name, opt => opt.MapFrom(p => p.Name));
        }
    }
}
