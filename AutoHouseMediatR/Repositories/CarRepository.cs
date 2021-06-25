using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoHouseMediatR.Dtos;

namespace AutoHouseMediatR.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly List<CarDto> _cars = new List<CarDto>
        {
            new CarDto
            {
                Id = Guid.Parse("0bb7daa5-7f27-4b5f-95df-3d8b3b86d7ed"),
                CreatedAt = DateTime.UtcNow,
                DealerId = Guid.Parse("9f8dd03e-1298-4070-adc0-c21bbd5e179f"),
                FactoryId = Guid.Parse("64fa643f-2d35-46e7-b3f8-31fa673d719b"),
                IsNew = true
            }
        };
        public Task<CarDto> AddCarAsync(Guid dealerId, Guid factoryId)
        {
            var order = new CarDto
            {
                Id = Guid.NewGuid(),
                IsNew = false,
                CreatedAt = DateTime.UtcNow,
                DealerId = dealerId,
                FactoryId = factoryId
            };

            _cars.Add(order);

            return Task.FromResult(order);
        }

        public Task<CarDto> GetCarAsync(Guid carId)
        {
            return Task.FromResult(_cars.SingleOrDefault(_ => _.Id == carId));
        }

        public Task<List<CarDto>> GetCarsAsync()
        {
            return Task.FromResult(_cars);
        }
    }
}
