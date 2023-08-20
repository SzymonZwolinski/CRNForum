using Platender.Core.Models;
using Platender.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platender.Application.Repositories
{
	public class PlateRepository : IPlateRepository
	{
		private List<Plate> plates = new List<Plate>();
        public PlateRepository()
        {
			plates.Add(new Plate("test12"));
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

		public Task UpdatePlateAsync(Plate plate)
		{
			throw new NotImplementedException();
		}
	}
}
