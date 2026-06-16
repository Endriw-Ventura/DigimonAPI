using DigimonAPI.Application.Interfaces;
using DigimonAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DigimonAPI.Infrastructure.Integrations.DigimonIntegration
{
    public class DigimonIntegration : IDigimonIntegration
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseDigimonUrl = "api/digimon/";
        private readonly string _baseLevelUrl = "api/digimon/level/";
        public DigimonIntegration(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Digimon>?> GetAllDigimonsFromAPI()
        {
            var baseUrl = _httpClient.BaseAddress;
            var response = await _httpClient.GetAsync($"{baseUrl}{_baseDigimonUrl}");
            if (response.IsSuccessStatusCode)
            {
                var digimons = await response.Content.ReadFromJsonAsync<List<Digimon>?>();
                return digimons;
            }

            return new List<Digimon>();
        }

        public async Task<Digimon?> GetDigimonByNameFromAPI(string name)
        {
            var baseUrl = _httpClient.BaseAddress;
            var response = await _httpClient.GetAsync($"{baseUrl}{_baseDigimonUrl}/name/{name}");
            if (response.IsSuccessStatusCode) {
                var list = await response.Content.ReadFromJsonAsync<List<Digimon>>();
                return list?.FirstOrDefault();
            }

            return null;
        }

        public async Task<List<Digimon>?> GetDigimonsByLevelFromAPI(string level)
        {
            var baseUrl = _httpClient.BaseAddress;
            var response = await _httpClient.GetAsync($"{baseUrl}{_baseLevelUrl}{level}");
            if (response.IsSuccessStatusCode)
            {
                var digimons = await response.Content.ReadFromJsonAsync<List<Digimon>>();
                return digimons ?? [];
            }
            return [];
        }
    }
}
