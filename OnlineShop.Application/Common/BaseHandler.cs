using AutoMapper;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Common;

namespace OnlineShop.Application.Common
{
    public class BaseHandler<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected readonly IRepository<TEntity, TKey> _repository;
        protected readonly IMapper _mapper;


        public BaseHandler(IRepository<TEntity, TKey> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
