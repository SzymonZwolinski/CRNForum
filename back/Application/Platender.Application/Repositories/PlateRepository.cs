using Platender.Core.Models;
using Platender.Core.Repositories;


namespace Platender.Application.Repositories
{
	public class PlateRepository : IPlateRepository
	{
		private List<Plate> plates = new List<Plate>();
        public PlateRepository()
        {
			plates.Add(new Plate("test12", Core.Enums.CultureCode.PL));
			plates.First().AddComment(new Comment("nice car men", "Dominik", 1));
        }
        public Task AddPlateAsync(Plate plate)
		{
			plates.Add(plate);
			return Task.CompletedTask;
		}

		public Task<bool> CheckIfPlateExistsAsync(string number)
		=> Task.Run(() => plates.Any(x => x.Number == number));


		public Task<Plate> GetPlateAsync(Guid plateId)
		=> Task.Run(() => plates.FirstOrDefault(x => x.Id == plateId));

		public Task<Plate> GetPlateByNumbersAsync(string number)
		=> Task.Run(() => plates.FirstOrDefault(x => x.Number.Equals(number, StringComparison.OrdinalIgnoreCase)));
		

		public Task UpdatePlateAsync(Plate plate)
		{
			throw new NotImplementedException();
		}
	}
}
