using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Payments.DTOs;
using OnlineShop.Application.CQRS.Payments.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Payments.Queries.GetPaymentById
{
    public class GetPaymentByIdQueryHandler : PaymentHandler, IRequestHandler<GetPaymentByIdQuery, GetPaymentDTO>
    {
        private readonly IRepository<User, int> _userRepository;

        public GetPaymentByIdQueryHandler(IRepository<Payment, int> repository, IRepository<User, int> userRepository, IMapper mapper)
            : base(repository, mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<GetPaymentDTO> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var payment = await _repository.GetByIdAsync(request.Id);

            var result = _mapper.Map<GetPaymentDTO>(payment);

            var user = await _userRepository.GetByIdAsync((int)payment.Order.Cart.UserId);

            result.FullName = $"{user.FirsName} + {user.LastName}";

            return result;
        }
    }
}
