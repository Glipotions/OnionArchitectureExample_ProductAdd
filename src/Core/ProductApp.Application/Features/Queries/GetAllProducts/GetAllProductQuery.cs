using MediatR;
using ProductApp.Application.Dto;
using ProductApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQuery:IRequest<List<ProductViewDto>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductViewDto>>
        {
            private readonly IProductRepository productRepository;

            public GetAllProductsQueryHandler(IProductRepository productRepository)
            {
                this.productRepository = productRepository;
            }
            public async Task<List<ProductViewDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await productRepository.GetAllAsync();

                return products.Select(x => new ProductViewDto()
                {
                    Id = x.Id,
                    Name=x.Name,
                }).ToList();
            }
        }
    }
}
