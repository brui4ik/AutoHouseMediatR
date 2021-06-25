using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoHouseMediatR.Mapping;
using AutoHouseMediatR.Queries.CarQueries;
using AutoHouseMediatR.Repositories;
using AutoHouseMediatR.Responses;
using MediatR;

namespace AutoHouseMediatR.Handlers.DealerHandlers
{
    public class GetDealerCarsHandler : IRequestHandler<GetDealerCarsQuery, DealerCarsResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetDealerCarsHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<DealerCarsResponse> Handle(GetDealerCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.GetCarsAsync();
            var dealerCars = cars.Where(_ => _.DealerId == request.DealerId).ToList();

            return new DealerCarsResponse
            {
                DealerId = request.DealerId,
                Cars = _mapper.MapCarDtosToCarResponses(dealerCars)
            };
        }
    }
}
