using DigimonAPI.Application.DTOs.DigimonDTOs;
using DigimonAPI.Application.Interfaces;
using DigimonAPI.Application.Mappers.DigimonMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonAPI.Application.Services
{
    public class DigimonService : IDigimonService
    {
        private readonly IDigimonRepository _digimonRepository;

        public DigimonService(IDigimonRepository digimonRepository)
        {
            _digimonRepository = digimonRepository;
        }

        public async Task<List<DigimonDTO>> GetAllDigimons()
        {
            var digimons = await _digimonRepository.GetAllDigimons();
            return digimons.Select(d => d.ToDigimonDTO()).ToList();
        }

        public async Task<DigimonDTO?> GetDigimonByName(string name)
        {
            var digimon = await _digimonRepository.GetDigimonByName(name);
            if (digimon is null)
                return null;

            return digimon.ToDigimonDTO();
        }

        public async Task<List<DigimonDTO>> GetDigimonsByLevel(string level)
        {
            var digimons = await _digimonRepository.GetDigimonsByLevel(level);
            return digimons.Select(d => d.ToDigimonDTO()).ToList();
        }

        public async Task<List<DigimonDTO>> GetDigimonsBySeachBar(string search)
        {
            var digimons = await _digimonRepository.GetDigimonsBySeachBar(search);
            return digimons.Select(d => d.ToDigimonDTO()).ToList();
        }
    }
}
