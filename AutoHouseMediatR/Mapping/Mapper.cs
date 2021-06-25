using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoHouseMediatR.Dtos;
using AutoHouseMediatR.Repositories;
using AutoHouseMediatR.Responses;

namespace AutoHouseMediatR.Mapping
{
    public class Mapper : IMapper
    {
        private readonly IDealerRepository _dealerRepository;

        public Mapper(IDealerRepository dealerRepository)
        {
            _dealerRepository = dealerRepository;
        }
        public List<DealerResponse> MapDealerDtosToDealerResponses(List<DealerDto> dtos)
        {
            return dtos.Select(x => new DealerResponse()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public DealerResponse MapDealerDtoToDealerResponse(DealerDto dealerDto)
        {
            return dealerDto == null ? null : new DealerResponse { Id = dealerDto.Id, Name = dealerDto.Name };
        }

        public List<CarResponse> MapCarDtosToCarResponses(List<CarDto> dealerCars)
        {
            return dealerCars.Select(async x => new CarResponse
            {
                Id = x.Id,
                Dealer = MapDealerDtoToDealerResponse(await _dealerRepository.GetDealerAsync(x.DealerId)),
                Factory = new FactoryResponse
                {
                    Id = x.FactoryId,
                    Name = "FactoryX",
                },
                CreatedAt = x.CreatedAt,
                IsNew = x.IsNew
            })
                .Select(_ => _.Result)
                .ToList();
        }

        public async Task<CarResponse> MapCarDtoToCarResponse(CarDto car)
        {
            return new CarResponse
            {
                Id = car.Id,
                Dealer = MapDealerDtoToDealerResponse(await _dealerRepository.GetDealerAsync(car.DealerId)),
                Factory = new FactoryResponse
                {
                    Id = car.FactoryId,
                    Name = "FactoryY",
                },
                CreatedAt = car.CreatedAt,
                IsNew = car.IsNew
            };
        }
    }
}
