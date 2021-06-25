using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoHouseMediatR.Dtos;

namespace AutoHouseMediatR.Repositories
{
    public interface ICarRepository
    {
        Task<CarDto> AddCarAsync(Guid dealerId, Guid factoryId);
        Task<CarDto> GetCarAsync(Guid carId);
        Task<List<CarDto>> GetCarsAsync();
    }
}