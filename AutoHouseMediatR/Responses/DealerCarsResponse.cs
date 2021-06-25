using System;
using System.Collections.Generic;

namespace AutoHouseMediatR.Responses
{
    public class DealerCarsResponse
    {
        public Guid DealerId { get; set; }

        public IEnumerable<CarResponse> Cars { get; set; }
    }
}
