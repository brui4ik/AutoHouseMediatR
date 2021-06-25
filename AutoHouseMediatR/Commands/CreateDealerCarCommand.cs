using System;
using AutoHouseMediatR.Responses;
using MediatR;

namespace AutoHouseMediatR.Commands
{
    public class CreateDealerCarCommand: IRequest<CarResponse>
    {
        public Guid FactoryId { get; set; }

        public Guid DealerId { get; set; }
    }
}
