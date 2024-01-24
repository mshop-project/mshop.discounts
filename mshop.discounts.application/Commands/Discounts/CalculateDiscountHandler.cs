using MediatR;
using mshop.discounts.application.DTOs.Discounts;
using mshop.discounts.application.Services.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mshop.discounts.application.Commands.Discounts
{
    internal class CalculateDiscountHandler : IRequestHandler<CalculateDiscountCommand, ReadDiscountDto>
    {
        private readonly IProductsServiceClient _productsService;

        public CalculateDiscountHandler(IProductsServiceClient productsService)
        {
            _productsService = productsService;
        }

        public async Task<ReadDiscountDto> Handle(CalculateDiscountCommand request, CancellationToken cancellationToken)
        {
            await _productsService.GetProductsByIdsAsync(request.CalculateDiscountDto.ProductIds);
            return null;
        }
    }
}
