using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common;
using OnlineShop.Application.CQRS.BankAccounts.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BankAccounts.Commands.CreateBankAccount
{
    public class CreateBankAccountCommandHandler : BankAccountHandler, IRequestHandler<CreateBankAccountCommand, int>
    {
        private readonly IRepository<User, int> _userRepository;
        public CreateBankAccountCommandHandler(IRepository<BankAccount, int> repository, IRepository<User, int> userRepository, IMapper mapper) : base(repository, mapper)
        {
            _userRepository = userRepository;
        }


        public async Task<int> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var bankAccount = new BankAccount()
            {
                CardNumber = request.CardNumber,
                CardDataHash = Hasher.HashString($"{request.CardNumber} {request.FirstName} {request.SecondName}"),
                Sum = request.Sum
            };

            
            if (request.UserId != null)
            {
                bankAccount.UserId = request.UserId;
            }

            var user = await _userRepository.GetQuery().FirstOrDefaultAsync(x => x.Id == request.UserId);

            if (user is null)
            {
                throw new ArgumentException($"Not found User with id ({request.UserId})");
            }


            var id = await _repository.AddAsync(bankAccount);

            return id;
        }
    }
}
