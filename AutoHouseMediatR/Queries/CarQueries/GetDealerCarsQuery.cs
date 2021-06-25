using System;
using AutoHouseMediatR.Responses;
using MediatR;

namespace AutoHouseMediatR.Queries.CarQueries
{
    public class GetDealerCarsQuery: IRequest<DealerCarsResponse>
    {
        public Guid DealerId;

        public GetDealerCarsQuery(Guid dealerId)
        {
            DealerId = dealerId;
        }
    }
}