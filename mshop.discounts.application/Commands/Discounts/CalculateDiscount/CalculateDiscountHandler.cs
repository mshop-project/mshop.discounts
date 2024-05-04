using MediatR;
using mshop.discounts.application.DTOs.Discounts;
using mshop.discounts.application.Services.Clients.Products;
using mshop.discounts.application.Services.Clients.Orders;
using mshop.discounts.domain.Services;
using mshop.sharedkernel.coredata.Products;
using mshop.sharedkernel.coredata.Orders;
using mshop.sharedkernel.messaging.Data.Response.Products;
using mshop.sharedkernel.messaging.Data.Response.Orders;

namespace mshop.discounts.application.Commands.Discounts.CalculateDiscount
{
    internal class CalculateDiscountHandler : IRequestHandler<CalculateDiscountCommand, ReadCalculatedDiscountDto>
    {
        private readonly IProductsServiceClient _productsServiceClient;
        private readonly IOrdersServiceClient _ordersServiceClient;
        private readonly IDiscountService _discountService;

        public CalculateDiscountHandler(IProductsServiceClient productsServiceClient, IOrdersServiceClient ordersServiceClient, IDiscountService discountService)
        {
            _productsServiceClient = productsServiceClient;
            _ordersServiceClient = ordersServiceClient;
            _discountService = discountService;
        }

        public async Task<ReadCalculatedDiscountDto> Handle(CalculateDiscountCommand request, CancellationToken cancellationToken)
        {
            ValidateInput(request.CalculateDiscountDto);

            var products = await GetProductsAsync(request.CalculateDiscountDto.ProductIds);
            var customerOrders = await GetCustomerOrdersAsync(request.CalculateDiscountDto.CustomerEmail);

            EnsureDataRetrieved(products.Products, customerOrders.Orders);

            var discount = await _discountService.CalculateDiscount(products.Products, customerOrders.Orders);

            return new ReadCalculatedDiscountDto(discount);
        }

        private void ValidateInput(CalculateDiscountDto dto)
        {
            if (dto.ProductIds == null && dto.CustomerEmail == null)
                throw new ArgumentNullException("At least one of ProductIds and CustomerEmail must be provided.");
        }

        private async Task<ProductsResponse> GetProductsAsync(IEnumerable<Guid>? productIds)
        {
            return productIds != null
                ? await _productsServiceClient.GetProductsByIdsAsync(productIds)
                : new ProductsResponse();
        }

        private async Task<OrdersResponse> GetCustomerOrdersAsync(string? customerEmail)
        {
            return customerEmail != null
                ? await _ordersServiceClient.GetOrdersByEmailAsync(customerEmail)
                : new OrdersResponse();
        }

        private void EnsureDataRetrieved(IEnumerable<Product> products, IEnumerable<Order> customerOrders)
        {
            if (products is null && customerOrders is null)
                throw new InvalidOperationException("Unable to retrieve products or customer orders.");
        }

    }
}
