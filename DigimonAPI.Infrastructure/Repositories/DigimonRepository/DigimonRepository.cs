using DigimonAPI.Application.Interfaces;
using DigimonAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonAPI.Infrastructure.Repositories.DigimonRepository
{
    public class DigimonRepository : IDigimonRepository
    {
        private readonly IDigimonIntegration _digimonIntegration;

        public DigimonRepository(IDigimonIntegration digimonIntegration)
        {
            _digimonIntegration = digimonIntegration;
        }

        public async Task<List<Digimon>> GetAllDigimons()
        {
            var digimons = await _digimonIntegration.GetAllDigimonsFromAPI();
            return digimons ?? [];
        }

        public async Task<Digimon?> GetDigimonByName(string name)
        {
            var digimon = await _digimonIntegration.GetDigimonByNameFromAPI(name);
            if (digimon is null)
            {
                return null;
            }

            return digimon;
        }

        public async Task<List<Digimon>> GetDigimonsByLevel(string level)
        {

            var digimons = await _digimonIntegration.GetDigimonsByLevelFromAPI(level);
            return digimons ?? [];
        }

        public async Task<List<Digimon>> GetDigimonsBySeachBar(string search)
        {
            var digimons = await _digimonIntegration.GetAllDigimonsFromAPI();
            if (digimons is null)
                return [];

           var filtered = digimons.Where(d => d.Name.ToLower().Contains(search.ToLower())).ToList();
           return filtered;
        }
    }
}
