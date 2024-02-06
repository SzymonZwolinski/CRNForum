using Microsoft.EntityFrameworkCore;
using Platender.Application.EF;
using Platender.Core.Enums;
using Platender.Core.Models;
using Platender.Core.Repositories;


namespace Platender.Application.Repositories
{
	public class PlateRepository : IPlateRepository
	{
		private readonly PlatenderDbContext _platenderDbContext;

        public PlateRepository(PlatenderDbContext platenderDbContext)
        {
			_platenderDbContext = platenderDbContext;
        }

        public async Task AddPlateAsync(Plate plate)
		{
			await _platenderDbContext.AddAsync(plate);
			await _platenderDbContext.SaveChangesAsync();
		}

		public async Task<bool> CheckIfPlateExistsAsync(string number)
			=> await _platenderDbContext.plates.AnyAsync(x => x.Number == number);

        public async Task<(IEnumerable<Plate>, int)> GetAllPlatesAsync(
			string number, 
			CultureCode? cultureCode, 
			int? Page)
		{
			var query = _platenderDbContext
				.plates
				.AsQueryable();

            if (!string.IsNullOrWhiteSpace(number))
            {
                query = query.Where(x => x.Number.StartsWith(number));
            }

            if (cultureCode != null) 
			{
				query = query.Where(x => x.Culture == cultureCode);
			}

			return (await query
					.Skip((Page - 1) * 10 ?? 0)
					.Take(Page * 10 ?? 10)
					.ToListAsync(),
				query
					.Count());
		}      

        public async Task<Plate> GetPlateAsync(Guid plateId)
			=> await _platenderDbContext.plates
				.Include(x => x.Comments)
					.ThenInclude(x => x.User)
				.FirstOrDefaultAsync(x => x.Id == plateId);
		
		public async Task UpdatePlateAsync(Plate plate)
		{
			_platenderDbContext.Update(plate);
			await _platenderDbContext.SaveChangesAsync();
		}
	}
}
