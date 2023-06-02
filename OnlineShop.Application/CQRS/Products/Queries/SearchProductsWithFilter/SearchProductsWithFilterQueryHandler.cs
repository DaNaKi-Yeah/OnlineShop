using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Application.CQRS.Products.Handlers;
using OnlineShop.Application.CQRS.Products.Queries.SearchProductsByCategoryId;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Products.Queries.SearchProductsWithFilters
{
    public class SearchProductsWithFilterQueryHandler : ProductHandler, IRequestHandler<SearchProductsWithFilterQuery, List<SearchProductDTO>>
    {
        private readonly IRepository<ProductPropertyValue, int> _productPropertyValueRepository;
        private readonly IRepository<ProductPropertyValuesInventory, int> _productPropertyValueInventoryRepository;
        public SearchProductsWithFilterQueryHandler
            (IRepository<ProductPropertyValue, int> productPropertyValueRepository, IRepository<ProductPropertyValuesInventory, int> productPropertyValueInventoryRepository, IRepository<Product, int> repository, IMapper mapper)
            : base(repository, mapper)
        {
            _productPropertyValueRepository = productPropertyValueRepository;
            _productPropertyValueInventoryRepository = productPropertyValueInventoryRepository;
        }

        public async Task<List<SearchProductDTO>> Handle(SearchProductsWithFilterQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return _mapper.Map<List<SearchProductDTO>>(await _repository.GetAllAsync());
            }

            var ids = request.Filter.PropertyValueIds;

            var products = await _repository.GetAllAsync();

            var result = new List<Product>();

            foreach (var product in products)
            {
                foreach (var inventory in product.ProductPropertyValuesInventories)
                {
                    var propValueIds = inventory.ProductPropertyValues.Select(x => x.PropertyValueId);

                    var intersect = ids.Intersect(propValueIds);

                    if (intersect.Count() == ids.Count())
                    {
                        result.Add(product);
                        break;
                    }
                }
            }

            var baseResult = _mapper.Map<List<SearchProductDTO>>(result);

            //var inventoryIds = (await _repository.GetQuery()
            //        .Select(obj => obj.ProductPropertyValuesInventories
            //            .Where(inventory => ids.Intersect(inventory.ProductPropertyValues.Select(x => x.PropertyValueId)).Count() == ids.Count()))
            //        .Select(x => x.First().Id)
            //        .ToListAsync());

            //var baseResult = _mapper.Map<List<SearchProductDTO>>(await _repository.GetQuery()
            //    .Where(obj => obj.ProductPropertyValuesInventories.Any(x => inventoryIds.Contains(x.Id)))
            //    .ToListAsync());


            //var baseResult = _mapper.Map<List<SearchProductDTO>>(await _repository.GetQuery()
            //        .Where(obj => obj.ProductPropertyValuesInventories
            //            .Where(inventory => inventory.ProductPropertyValues
            //                .Where(pPropertyValue => ids.Intersect(inventory.ProductPropertyValues.Select(z => z.PropertyValueId)).Count() == ids.Count)
            //                .Select(u => u.ProductPropertyValuesInventory)
            //                == obj.ProductPropertyValuesInventories.Where(objInventory => objInventory.Equals(inventory)))
            //            == _repository.GetQuery().Where(outObj => outObj.ProductPropertyValuesInventories.Intersect(obj.ProductPropertyValuesInventories).Count() > 0))
            //        .ToListAsync());





            //var propertySets = await _productPropertyValueRepository.GetQuery()
            //    .Where(y => request.Filter.PropertyValueIds.All(z => z == y.PropertyValueId)).ToListAsync();

            //var products = await _productPropertyValueInventoryRepository.GetQuery()
            //        .Where(obj => obj.ProductPropertyValues.Intersect(propertySets).Any()).Select(x => x.Product).ToListAsync();



            if (request.PageSize == null || request.PageNumber == null)
            {
                return baseResult;
            }

            return baseResult
                .Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                .Take(request.PageSize.Value).ToList();
        }

        //private Product W1(Product product, List<int?> ids)
        //{
        //    var inventories = product.ProductPropertyValuesInventories.ToList();

        //    W2(inventories, ids);
        //    return 
        //}
        //private Product W2(List<ProductPropertyValuesInventory> inventories, List<int?> ids)
        //{
        //    var pPropertyValues = inventories.Select(x => x.ProductPropertyValues);

        //    foreach (var item in pPropertyValues)
        //    {
        //        W3(item, ids);
        //    }
        //    return 
        //}
        //private Product W3(List<ProductPropertyValue> productPropertyValues, List<int?> ids)
        //{
        //    var propertyValues = productPropertyValues.Select(x => x.PropertyValueId);

        //    bool isTrue = propertyValues.All(x => propertyValues.Contains(x));

        //    return 
        //}
    }
}
