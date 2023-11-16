using CityInfo.API.DbContexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }

        public async Task AddPointOfInterestForCityAsync(int cityId, PointOfInterst pointOfInterest)
        {
            var city = await GetCityAsync(cityId, false);
            if (city != null)
            {
                city.PointsOfInterest.Add(pointOfInterest);
            }
        }

        public async Task<bool> CityExistAsync(int cityId)
        {
            return await _context.Cities.AnyAsync(x => x.Id == cityId);
        }

        public async Task<bool> CityNameMatchesCityId(string? cityName, int cityId)
        {
            return await _context.Cities.AnyAsync(c => c.Id == cityId && c.Name==cityName);
        }

        public void DeletePointOfInterest(PointOfInterst pointOfInterst)
        {
            _context.PointsOfInterest.Remove(pointOfInterst);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.OrderBy(x=>x.Name).ToListAsync();
        }

        public async Task<(IEnumerable<City>, PaginationMetadata)> GetCitiesAsync(string? name, string? searchQuery, int pageNumber, int pageSize)
        { 
            var collection = _context.Cities as IQueryable<City>;
            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(x=>x.Name==name);
            }
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(a => a.Name.Contains(searchQuery) || (a.Description != null && a.Description.Contains(searchQuery)));
            }

            var totalItemCount = await collection.CountAsync();
            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.OrderBy(c=>c.Name)
                .Skip(pageSize * (pageNumber -1))
                .Take(pageSize)
                .ToListAsync();
            return (collectionToReturn, paginationMetadata);
        }

        public async Task<City?> GetCityAsync(int cityId, bool includePointOfInterst)
        {
            if (includePointOfInterst)
            {
                return await _context.Cities.Include(x=>x.PointsOfInterest).FirstOrDefaultAsync(x => x.Id == cityId);
            }
            return await _context.Cities.FirstOrDefaultAsync(x => x.Id == cityId);
        }

        public async Task<IEnumerable<PointOfInterst>> GetPointOfInterestForCityAsync(int cityId)
        {
            return await _context.PointsOfInterest.Where(x=>x.CityId==cityId).ToListAsync();
        }

        public async Task<PointOfInterst?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId)
        {
            return await _context.PointsOfInterest.FirstOrDefaultAsync(x => x.Id == pointOfInterestId && x.CityId == cityId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
