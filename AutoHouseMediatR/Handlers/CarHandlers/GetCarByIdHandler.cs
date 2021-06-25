using System.Threading;
using System.Threading.Tasks;
using AutoHouseMediatR.Mapping;
using AutoHouseMediatR.Queries.CarQueries;
using AutoHouseMediatR.Repositories;
using AutoHouseMediatR.Responses;
using MediatR;

namespace AutoHouseMediatR.Handlers.CarHandlers
{
    public class GetCarByIdHandler: IRequestHandler<GetCarByIdQuery, CarResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetCarByIdHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CarResponse> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetCarAsync(request.Id);
            return car == null ? null : await _mapper.MapCarDtoToCarResponse(car);
        }
    }
}
