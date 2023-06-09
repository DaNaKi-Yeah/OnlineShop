﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using OnlineShop.Application.CQRS.BankAccounts.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BankAccounts.Queries.GetBankAccountById
{
    public class GetBankAccountByIdQueryHandler : BankAccountHandler, IRequestHandler<GetBankAccountByIdQuery, GetBankAccountDTO>
    {
        public GetBankAccountByIdQueryHandler(IRepository<BankAccount, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetBankAccountDTO> Handle(GetBankAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var bankAccount = await _repository.GetQuery().FirstOrDefaultAsync(x => x.Id == request.Id);

            if (bankAccount is null)
            {
                throw new ArgumentException($"Not found BankAccount with id ({request.Id})");
            }

            var result = await _repository.GetByIdAsync(request.Id);

            return _mapper.Map<GetBankAccountDTO>(result);
        }
    }
}
