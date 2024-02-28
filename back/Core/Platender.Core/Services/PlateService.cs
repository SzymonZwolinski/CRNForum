﻿using Platender.Core.Enums;
using Platender.Core.Models;
using Platender.Core.Repositories;
using System.Net;

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

        public async Task AddSpotToPlateAsync(
			Guid plateId,
			byte[] image, 
			string content,
			string userName)
        {
			var user = await _authRepository.GetUserAsync(userName);
			var plate = await _plateRepository.GetPlateAsync(plateId);
			var spot = CreateSpot(
				user,
				image, 
				content);

			plate.AddSpott(spot);

			await _plateRepository.UpdatePlateAsync(plate);
        }

		private Spotts CreateSpot(
			User user, 
			byte[] image,
			string description)
		{
			return new Spotts(user, image, description);
		}

        public async Task<(IEnumerable<Comment>, int)> GetPlateCommentsAsync(Guid plateId, int? page)
			=> await _plateRepository.GetPlateCommentsAsync(plateId, page);

		public async Task<(IEnumerable<Spotts>, int)> GetPlateSpottsAsync(Guid plateId, int? page)
			=> await _plateRepository.GetPlateSpottsAsync(plateId, page);

        public async Task AddOrRemoveReactionToPlateAsync(
			Guid plateId, 
			IPAddress userIP,
			LikeType likeType)
        {
			var plate = await _plateRepository.GetPlateWithLikesAsync(plateId);

			if(plate.PlateLikes.Any(x => x.UserIPAddress == userIP))
			{
				plate.RemoveLike(
					plate.PlateLikes
					.First(x => x.UserIPAddress == userIP));

                await _plateRepository.UpdatePlateAsync(plate);

                return;
			}

			plate.AddLike(new PlateLike(plate, userIP, likeType));

			await _plateRepository.UpdatePlateAsync(plate);
        }

        public async Task AddOrRemoveReactionToSpottAsync(
			Guid plateId,
			Guid spottId,
			IPAddress userIP,
			LikeType likeType)
        {
			var plate = await _plateRepository.GetPlateWithSpottLikesAsync(plateId);

			if(!plate.Spotts.Any(x => x.Id == spottId))
			{
				return;
			}

			var spott = plate.Spotts.FirstOrDefault(x => x.Id == spottId);

			if(spott.SpottLikes.Any(x => x.UserIPAddress == userIP))
			{
				spott.RemoveLike(spott.SpottLikes
					.First(x => x.UserIPAddress == userIP));

                await _plateRepository.UpdatePlateAsync(plate);

                return;
			}

			spott.AddLike(new SpottLike(spott, userIP, likeType));

			await _plateRepository.UpdatePlateAsync(plate);
        }
    }
}
