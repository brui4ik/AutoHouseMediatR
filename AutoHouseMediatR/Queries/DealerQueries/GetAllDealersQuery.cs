using System.Collections.Generic;
using AutoHouseMediatR.Responses;
using MediatR;

namespace AutoHouseMediatR.Queries.DealerQueries
{
    public class GetAllDealersQuery: IRequest<IEnumerable<DealerResponse>>
    {
        public GetAllDealersQuery()
        {
        }
    }
}