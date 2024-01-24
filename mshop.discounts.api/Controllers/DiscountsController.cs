using MediatR;
using Microsoft.AspNetCore.Mvc;
using mshop.discounts.application.Commands.Discounts.CalculateDiscount;
using mshop.discounts.application.Commands.Discounts.CreateDiscount;
using mshop.discounts.application.DTOs.Discounts;

namespace mshop.discounts.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiscountsController: ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Calculate")]
        [ProducesResponseType(200, Type = typeof(ReadCalculatedDiscountDto))]
        public async Task<IActionResult> CalculateDiscount([FromBody] CalculateDiscountDto calculateDiscountDto)
        {
            var result = await _mediator.Send(new CalculateDiscountCommand(calculateDiscountDto));
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateDiscount([FromBody] CreateDiscountDto discountDto)
        {
            await _mediator.Send(new CreateDiscountCommand(discountDto));
            return Ok();
        }
    }
}
