using System.Collections.Generic;
using System.Threading.Tasks;
using AutoHouseMediatR.Dtos;
using AutoHouseMediatR.Responses;

namespace AutoHouseMediatR.Mapping
{
    public interface IMapper
    {
        List<DealerResponse> MapDealerDtosToDealerResponses(List<DealerDto> dtos);
        DealerResponse MapDealerDtoToDealerResponse(DealerDto dealerDto);
        List<CarResponse> MapCarDtosToCarResponses(List<CarDto> dealerCars);
        Task<CarResponse> MapCarDtoToCarResponse(CarDto car);
    }
}