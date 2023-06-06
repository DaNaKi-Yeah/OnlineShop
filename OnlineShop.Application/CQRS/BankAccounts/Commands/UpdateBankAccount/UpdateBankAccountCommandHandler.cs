using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.BankAccounts.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BankAccounts.Commands.UpdateBankAccount
{
    public class UpdateBankAccountCommandHandler : BankAccountHandler, IRequestHandler<UpdateBankAccountCommand>
    {
        public UpdateBankAccountCommandHandler(IRepository<BankAccount, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var ba = await _repository.GetByIdAsync(request.Id);

            ba.Sum += request.AddSum;

            await _repository.UpdateAsync(ba);
        }
    }
}
