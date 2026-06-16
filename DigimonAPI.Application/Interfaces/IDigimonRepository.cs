using DigimonAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonAPI.Application.Interfaces
{
    public interface IDigimonRepository
    {
        public Task<List<Digimon>> GetAllDigimons();
        public Task<Digimon?> GetDigimonByName(string name);
        public Task<List<Digimon>> GetDigimonsByLevel(string level);
        public Task<List<Digimon>> GetDigimonsBySeachBar(string search);
    }
}
