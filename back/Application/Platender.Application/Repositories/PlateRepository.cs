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

		public async Task<Plate> GetPlateAsync(Guid plateId)
		=> await _platenderDbContext.plates
			.Include(x => x.Comments)
				.ThenInclude(x => x.User)
			.FirstOrDefaultAsync(x => x.Id == plateId);

		public async Task<IEnumerable<Plate>> GetPlatesByNumbersAsync(string number, CultureCode? cultureCode)
		{
			if (cultureCode == null)
			{
				return await _platenderDbContext.plates
					.Where(x => x.Number.Contains(number))
					.ToListAsync();
			}
            return await _platenderDbContext.plates
                    .Where(x => x.Number.Contains(number)
						&& x.Culture == cultureCode)
					.ToListAsync();
        }
		
		public async Task UpdatePlateAsync(Plate plate)
		{
			_platenderDbContext.Update(plate);
			await _platenderDbContext.SaveChangesAsync();
		}
	}
}
