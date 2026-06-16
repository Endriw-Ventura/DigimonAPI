using DigimonAPI.Application.DTOs.DigimonDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonAPI.Application.Interfaces
{
    public interface IDigimonService
    {
        public Task<List<DigimonDTO>> GetAllDigimons();
        public Task<DigimonDTO?> GetDigimonByName(string name);
        public Task<List<DigimonDTO>> GetDigimonsByLevel(string level);
        public Task<List<DigimonDTO>> GetDigimonsBySeachBar(string search);
    }
}
