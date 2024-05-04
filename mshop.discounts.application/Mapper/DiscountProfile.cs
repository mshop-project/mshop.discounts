using AutoMapper;
using mshop.discounts.application.DTOs.Discounts;
using mshop.sharedkernel.coredata.Discounts;

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
