using Domain.Entities;
using Service.DTOs.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();
        Task<CountryDto> GetByIdAsync(int id);
        Task Create(CountryCreateDto model);
        Task<IEnumerable<CountryByCitiesDto>> GetAllWithCities();
        Task DeleteAsync(int id);
        Task EditAsync(int id, CountryEditDto model);
        Task<CountryByCitiesDto> GetCountryByNameWithCities(string name);

    }
}
