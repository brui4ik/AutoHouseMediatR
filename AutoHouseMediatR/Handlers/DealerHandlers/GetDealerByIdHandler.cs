using System.Threading;
using System.Threading.Tasks;
using AutoHouseMediatR.Mapping;
using AutoHouseMediatR.Queries.DealerQueries;
using AutoHouseMediatR.Repositories;
using AutoHouseMediatR.Responses;
using MediatR;

namespace AutoHouseMediatR.Handlers.DealerHandlers
{
    public class GetDealerByIdHandler: IRequestHandler<GetDealerByIdQuery, DealerResponse>
    {
        private readonly IDealerRepository _dealerRepository;
        private readonly IMapper _mapper;

        public GetDealerByIdHandler(IDealerRepository dealerRepository, IMapper mapper)
        {
            _dealerRepository = dealerRepository;
            _mapper = mapper;
        }

        public async Task<DealerResponse> Handle(GetDealerByIdQuery request, CancellationToken cancellationToken)
        {
            var dealer = await _dealerRepository.GetDealerAsync(request.Id);
            return dealer == null ? null :_mapper.MapDealerDtoToDealerResponse(dealer);
        }
    }
}
