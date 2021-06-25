using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoHouseMediatR.Mapping;
using AutoHouseMediatR.Queries.CarQueries;
using AutoHouseMediatR.Repositories;
using AutoHouseMediatR.Responses;
using MediatR;

namespace AutoHouseMediatR.Handlers.CarHandlers
{
    public class GetAllCarsHandler: IRequestHandler<GetAllCarsQuery, IEnumerable<CarResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetAllCarsHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarResponse>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.GetCarsAsync();
            return _mapper.MapCarDtosToCarResponses(cars);
        }
    }
}
