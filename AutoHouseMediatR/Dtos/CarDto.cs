using System;

namespace AutoHouseMediatR.Dtos
{
    public class CarDto
    {
        public Guid Id { get; set; }

        public Guid DealerId { get; set; }

        public Guid FactoryId { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsNew { get; set; }

        public string Name { get; set; }


    }
}
