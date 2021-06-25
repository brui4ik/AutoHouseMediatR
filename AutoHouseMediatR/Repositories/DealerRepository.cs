using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoHouseMediatR.Dtos;

namespace AutoHouseMediatR.Repositories
{
    public class DealerRepository : IDealerRepository
    {
        private readonly List<DealerDto> _dealres = new List<DealerDto>
        {
            new DealerDto{ Id = Guid.Parse("64fa643f-2d35-46e7-b3f8-31fa673d719b"), Name = "Dealer1" },
            new DealerDto{ Id = Guid.Parse("fc7cdfc4-f407-4955-acbe-98c666ee51a2"), Name = "Dealer2"},
            new DealerDto{ Id = Guid.Parse("a46ac8f4-2ecd-43bf-a9e6-e557b9af1d6e"), Name = "Dealer3"},
            new DealerDto{ Id = Guid.Parse("9f8dd03e-1298-4070-adc0-c21bbd5e179f"), Name = "Dealer4"}
        };

        public Task<DealerDto> GetDealerAsync(Guid dealerId)
        {
            return Task.FromResult(_dealres.SingleOrDefault(_ => _.Id == dealerId));
        }

        public Task<List<DealerDto>> GetDealersAsync()
        {
            return Task.FromResult(_dealres);
        }
    }
}
