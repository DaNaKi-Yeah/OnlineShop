using AutoMapper;
using MediatR;
using Microsoft.VisualBasic;
using OnlineShop.Application.CQRS.BankAccounts.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BankAccounts.Commands.RemoveBankAccountById
{
    public class RemoveBankAccountByIdCommandHandler : BankAccountHandler, IRequestHandler<RemoveBankAccountByIdCommand>
    {
        public RemoveBankAccountByIdCommandHandler(IRepository<BankAccount, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(RemoveBankAccountByIdCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
        }
    }
}
