using System;
using AutoHouseMediatR.Responses;
using MediatR;

namespace AutoHouseMediatR.Queries.CarQueries
{
    public class GetCarByIdQuery: IRequest<CarResponse>
    {
        public Guid Id { get; }

        public GetCarByIdQuery(Guid carId)
        {
            Id = carId;
        }
    }
}