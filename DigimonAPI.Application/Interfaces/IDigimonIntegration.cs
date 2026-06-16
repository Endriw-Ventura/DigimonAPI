using DigimonAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonAPI.Application.Interfaces
{
    public interface IDigimonIntegration
    {
        public Task<List<Digimon>?> GetAllDigimonsFromAPI();
        public Task<Digimon?> GetDigimonByNameFromAPI(string name);
        public Task<List<Digimon>?> GetDigimonsByLevelFromAPI(string level);
    }
}
