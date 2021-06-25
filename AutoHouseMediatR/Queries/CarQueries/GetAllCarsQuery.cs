using System.Collections.Generic;
using AutoHouseMediatR.Responses;
using MediatR;

namespace AutoHouseMediatR.Queries.CarQueries
{
    public class GetAllCarsQuery: IRequest<IEnumerable<CarResponse>>
    {
    }
}