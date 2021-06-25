using System;

namespace AutoHouseMediatR.Responses
{
    public class CarResponse
    {
        public Guid Id { get; set; }

        public FactoryResponse Factory { get; set; }

        public DealerResponse Dealer { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsNew { get; set; }

        public string Name { get; set; }
    }
}
