using AutoHouseMediatR.Commands;
using AutoHouseMediatR.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoHouseMediatR.Mapping;
using AutoHouseMediatR.Repositories;
using Microsoft.Extensions.Logging;

namespace AutoHouseMediatR.Handlers.CarHandlers
{
    public class CreateDealerCarHandler : IRequestHandler<CreateDealerCarCommand, CarResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateDealerCarHandler> _logger;

        public CreateDealerCarHandler(ICarRepository carRepository, IMapper mapper, ILogger<CreateDealerCarHandler> logger)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CarResponse> Handle(CreateDealerCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.AddCarAsync(request.DealerId, request.FactoryId);
            _logger.LogInformation($"Added car for dealer: {car.DealerId} from factory: {car.FactoryId}");

            return await _mapper.MapCarDtoToCarResponse(car);
        }
    }
}
