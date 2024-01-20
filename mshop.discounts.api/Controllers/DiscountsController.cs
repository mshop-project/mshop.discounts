using Microsoft.AspNetCore.Mvc;
using mshop.discounts.application.DTOs.Discounts;

namespace mshop.discounts.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiscountsController: ControllerBase
    {
        [HttpPost("Calculate")]
        public async Task<IActionResult> CalculateDiscount([FromBody] CalculateDiscountDto calculateDiscountDto)
        {
            return Ok(new ReadDiscountDto());
        }
    }
}
