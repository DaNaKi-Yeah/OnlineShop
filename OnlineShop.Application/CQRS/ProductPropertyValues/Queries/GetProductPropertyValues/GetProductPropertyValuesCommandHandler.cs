using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.CQRS.ProductPropertyValues.DTOs;
using OnlineShop.Application.CQRS.ProductPropertyValues.Handlers;
using OnlineShop.Application.CQRS.Reviews.DTOs;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValues.Queries.GetProductPropertyValues
{
    public class GetProductPropertyValuesCommandHandler : ProductPropertyValueHandler, IRequestHandler<GetProductPropertyValuesCommand, List<GetProductPropertyValueDTO>
    {
        public GetProductPropertyValuesCommandHandler(IRepository<ProductPropertyValue, int> repository, IMapper mapper) : base(repository, mapper) { }
        public async Task<List<GetProductPropertyValueDTO>> Handle(GetProductPropertyValuesCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return _mapper.Map<List<GetProductPropertyValueDTO>>(await _repository.GetAllAsync());
            }


            var baseResult = _mapper.Map<List<GetProductPropertyValueDTO>>((await _repository.GetQuery().AsNoTracking().ToListAsync()));

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
