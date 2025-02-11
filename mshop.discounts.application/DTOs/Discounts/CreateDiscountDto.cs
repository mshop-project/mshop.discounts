﻿using mshop.sharedkernel.coredata.Discounts.Enums;

namespace mshop.discounts.application.DTOs.Discounts
{
    public class CreateDiscountDto
    {
        public string? Name { get; set; }
        public int? MinimumNumberOrdersPerUser { get; set; }
        public Guid? CategoryId { get; set; }
        public int? MinimumNumberProductsPerCategory { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal DiscountPercentValue { get; set; }
    }
}
