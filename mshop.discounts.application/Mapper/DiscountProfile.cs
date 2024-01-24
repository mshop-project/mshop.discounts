using AutoMapper;
using mshop.discounts.application.DTOs.Discounts;
using mshop.discounts.domain.Entities;

namespace mshop.discounts.application.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<CreateDiscountDto, Discount>();
        }
    }
}
