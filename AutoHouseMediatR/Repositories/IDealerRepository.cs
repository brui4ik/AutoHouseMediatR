using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoHouseMediatR.Dtos;

namespace AutoHouseMediatR.Repositories
{
    public interface IDealerRepository
    {
        Task<DealerDto> GetDealerAsync(Guid dealerId);
        Task<List<DealerDto>> GetDealersAsync();
    }
}