using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoHouseMediatR.Mapping;
using AutoHouseMediatR.Queries.DealerQueries;
using AutoHouseMediatR.Repositories;
using AutoHouseMediatR.Responses;
using MediatR;

namespace AutoHouseMediatR.Handlers.DealerHandlers
{
    public class GetAllDealersHandler: IRequestHandler<GetAllDealersQuery, IEnumerable<DealerResponse>>
    {
        private readonly IDealerRepository _dealerRepository;
        private readonly IMapper _mapper;

        public GetAllDealersHandler(IDealerRepository dealerRepository, IMapper mapper)
        {
            _dealerRepository = dealerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DealerResponse>> Handle(GetAllDealersQuery request, CancellationToken cancellationToken)
        {
            var dealers = await _dealerRepository.GetDealersAsync();
            return _mapper.MapDealerDtosToDealerResponses(dealers);
        }
    }
}
