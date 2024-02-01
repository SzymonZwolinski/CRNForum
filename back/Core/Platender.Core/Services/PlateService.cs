using Platender.Core.Enums;
using Platender.Core.Models;
using Platender.Core.Repositories;

namespace Platender.Core.Services
{
	public class PlateService : IPlateService
	{
		private readonly IPlateRepository _plateRepository;
		private readonly IAuthRepository _authRepository;

		public PlateService(IPlateRepository plateRepository, IAuthRepository authRepository)
		{
			_plateRepository = plateRepository;
			_authRepository = authRepository;	
		}

		public async Task AddCommentToPlateAsync(
			Guid plateId, 
			string content,
			string userName)
		{
			var user = await _authRepository.GetUserAsync(userName);
			var plate = await _plateRepository.GetPlateAsync(plateId);
			var comment = CreateComment(
				plate,
				content,
				user);

			plate.AddComment(comment);

			await _plateRepository.UpdatePlateAsync(plate);
		}

		private Comment CreateComment(
			Plate plate,
			string content,
			User user)
		{
			return new Comment(
				content,
				user,
				plate.Comments
				.OrderBy(x => x.Sequence)
				.FirstOrDefault()?
				.Sequence + 1 ?? 1);
		}

		public async Task<Guid> AddPlateAsync(string number, CultureCode? cultureCode)
		{
			var plate = new Plate(number, cultureCode);
			await _plateRepository.AddPlateAsync(plate);

			return plate.Id;
		}

		public async Task<bool> CheckIfPlateExistsAsync(string number)
			=> await _plateRepository.CheckIfPlateExistsAsync(number);

		public async Task<Plate> GetPlateAsync(Guid plateId)
			=> await _plateRepository.GetPlateAsync(plateId); 
		
        public async Task<(IEnumerable<Plate>, int)> GetAllPlates(
			string numbers,
			CultureCode? cultureCode,
			int? page)
			=> await _plateRepository.GetAllPlatesAsync(
				numbers,
				cultureCode, 
				page);
    }
}
