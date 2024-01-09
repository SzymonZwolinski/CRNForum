using Microsoft.EntityFrameworkCore;
using Platender.Application.EF;
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
		=> await _platenderDbContext.plates.FirstOrDefaultAsync(x => x.Id == plateId);

		public async Task<Plate> GetPlateByNumbersAsync(string number)
		=> await _platenderDbContext.plates.FirstOrDefaultAsync(x => x.Number.Equals(number, StringComparison.OrdinalIgnoreCase));
		
		public async Task UpdatePlateAsync(Plate plate)
		{
			_platenderDbContext.Update(plate);
			await _platenderDbContext.SaveChangesAsync();
		}
	}
}
