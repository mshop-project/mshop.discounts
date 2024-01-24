using MediatR;
using mshop.discounts.application.DTOs.Discounts;

namespace mshop.discounts.application.Commands.Discounts.CreateDiscount
{
    public sealed record CreateDiscountCommand(CreateDiscountDto DiscountDto) : IRequest;
}
