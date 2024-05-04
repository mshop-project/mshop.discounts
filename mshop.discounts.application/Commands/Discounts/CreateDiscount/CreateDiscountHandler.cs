using AutoMapper;
using MediatR;
using mshop.discounts.domain.Repositories;
using mshop.sharedkernel.coredata.Discounts;

namespace mshop.discounts.application.Commands.Discounts.CreateDiscount
{
    internal sealed class CreateDiscountHandler : IRequestHandler<CreateDiscountCommand>
    {
        private readonly IDiscountsRepository _discountsRepository;
        private readonly IMapper _mapper;

        public CreateDiscountHandler(IDiscountsRepository discountsRepository, IMapper mapper)
        {
            _discountsRepository = discountsRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = _mapper.Map<Discount>(request.DiscountDto);

            await _discountsRepository.CreateAsync(discount);
        }
    }
}
