using MediatR;
using mshop.discounts.application.DTOs.Discounts;

namespace mshop.discounts.application.Commands.Discounts.CalculateDiscount
{
    public sealed record CalculateDiscountCommand(CalculateDiscountDto CalculateDiscountDto) : IRequest<ReadCalculatedDiscountDto>;
}
