using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Users.DTOs
{
    public class GetUserDTO : IMapWith<User>
    {
        public int Id { get; set; }
        public int? UserAccountId { get; set; }
        public string FullName { get; set; }
        public int? CartId { get; set; }
        public int BankAccountsCount { get; set; }
        public List<int> BankAccountIds { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetUserDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.UserAccountId, opt => opt.MapFrom(y => y.UserAccountId))
                .ForMember(x => x.FullName, opt => opt.MapFrom(y => $"{y.FirsName} {y.LastName}"))
                .ForMember(x => x.CartId, opt => opt.MapFrom(y => y.CartId))
                .ForMember(x => x.BankAccountsCount, opt => opt.MapFrom(y => y.BankAccounts.Count))
                .ForMember(x => x.BankAccountIds, opt => opt.MapFrom(y => y.BankAccounts.Select(x => x.Id)));
        }
    }
}
