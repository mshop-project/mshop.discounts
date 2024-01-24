using MediatR;
using Microsoft.AspNetCore.Mvc;
using mshop.discounts.application.Commands.Discounts;
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
        [ProducesResponseType(200, Type = typeof(ReadDiscountDto))]
        public async Task<IActionResult> CalculateDiscount([FromBody] CalculateDiscountDto calculateDiscountDto)
        {
            await _mediator.Send(new CalculateDiscountCommand(calculateDiscountDto));
            return Ok(new ReadDiscountDto());
        }
    }
}
