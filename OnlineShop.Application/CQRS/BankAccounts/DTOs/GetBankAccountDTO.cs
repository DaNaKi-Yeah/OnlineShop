using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BankAccounts.DTOs
{
    public class GetBankAccountDTO : IMapWith<BankAccount>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public decimal Sum { get; set; }
        public string CardDataHash { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BankAccount, GetBankAccountDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.FullName, opt => opt.MapFrom(y => $"{y.User.FirsName} {y.User.LastName}"))
                .ForMember(x => x.UserId, opt => opt.MapFrom(y => y.UserId))
                .ForMember(x => x.CardNumber, opt => opt.MapFrom(y => y.CardNumber))
                .ForMember(x => x.Sum, opt => opt.MapFrom(y => y.Sum))
                .ForMember(x => x.CardDataHash, opt => opt.MapFrom(y => y.CardDataHash));
        }
    }
}
