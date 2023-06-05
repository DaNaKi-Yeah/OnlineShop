using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using OnlineShop.Application.CQRS.BankAccounts.Handlers;
using OnlineShop.Application.CQRS.Orders.DTOs;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BankAccounts.Queries.SearchBankAccountsByUserId
{
    public class SearchBankAccountsByUserIdQueryHandler : BankAccountHandler, IRequestHandler<SearchBankAccountsByUserIdQuery, List<GetBankAccountDTO>>
    {
        public SearchBankAccountsByUserIdQueryHandler(IRepository<BankAccount, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<GetBankAccountDTO>> Handle(SearchBankAccountsByUserIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null || request.UserId == 0)
            {
                return _mapper.Map<List<GetBankAccountDTO>>(await _repository.GetAllAsync());
            }

            var baseResult = _mapper.Map<List<GetBankAccountDTO>>(await _repository.GetQuery().Where(x => x.UserId == request.UserId)
                .ToListAsync());

            if (request.PageSize == null || request.PageNumber == null)
            {
                return baseResult;
            }

            return baseResult
                .Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                .Take(request.PageSize.Value).ToList();
        }
    }
}
