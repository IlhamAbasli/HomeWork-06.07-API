using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.DTOs.Countries;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepo;
        private readonly IMapper _mapper;
        public CountryService(ICountryRepository countryRepo,IMapper mapper)
        {
            _countryRepo = countryRepo;
            _mapper = mapper;
        }

        public async Task Create(CountryCreateDto model)
        {
            await _countryRepo.Create(_mapper.Map<Country>(model));
        }

        public async Task DeleteAsync(int id)
        {
            var existData = await _countryRepo.GetById(id);
            await _countryRepo.Delete(existData);  
        }

        public async Task EditAsync(int id, CountryEditDto model)
        {
            var existData = await _countryRepo.GetById(id);

            _mapper.Map(model,existData);

            await _countryRepo.Update(existData);
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CountryDto>>(await _countryRepo.GetAll());
        }

        public async Task<IEnumerable<CountryByCitiesDto>> GetAllWithCities()
        {
            return _mapper.Map<IEnumerable<CountryByCitiesDto>>(await _countryRepo.GetAllWithCities());
        }

        public async Task<CountryDto> GetByIdAsync(int id)
        {
            return _mapper.Map<CountryDto>(await _countryRepo.GetById(id));
        }

        public async Task<CountryByCitiesDto> GetCountryByNameWithCities(string name)
        {
            var existCountry = await _countryRepo.FindBy(m => m.Name == name, m => m.Cities).FirstOrDefaultAsync();
            return _mapper.Map<CountryByCitiesDto>(existCountry);
        }
    }
}
