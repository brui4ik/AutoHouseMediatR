using System;
using AutoHouseMediatR.Responses;
using MediatR;

namespace AutoHouseMediatR.Queries.DealerQueries
{
    public class GetDealerByIdQuery: IRequest<DealerResponse>
    {
        public Guid Id { get; }

        public GetDealerByIdQuery(Guid dealerId)
        {
            Id = dealerId;
        }
    }
}