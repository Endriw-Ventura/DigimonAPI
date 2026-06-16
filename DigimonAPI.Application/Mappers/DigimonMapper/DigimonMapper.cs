using DigimonAPI.Application.DTOs.DigimonDTOs;
using DigimonAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonAPI.Application.Mappers.DigimonMapper
{
    public static class DigimonMapper
    {
        public static DigimonDTO ToDigimonDTO(this Digimon digimon)
        {
            return new DigimonDTO
            {
                Name = digimon.Name,
                Level = digimon.Level,
                Img = digimon.Img
            };
        }
    }
}
