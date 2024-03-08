using Platender.Application.DTO;
using Platender.Application.Messages;
using Platender.Application.Messages.Queries;
using Platender.Core.Enums;
using Platender.Core.Extensions.EnumExtensions;
using Platender.Core.Helpers;
using Platender.Core.Models;
using Platender.Core.Services;
using System.Net;

namespace Platender.Application.Providers
{
    public class PlateProvider : IPlateProvider
    {
        private readonly IPlateService _plateService;

        public PlateProvider(IPlateService plateService)
        {
            _plateService = plateService;
        }

		public async Task<Guid> AddPlateAsync(AddPlate addPlate)
            => await _plateService
                .AddPlateAsync(
                    addPlate.Numbers, 
                    addPlate.CultureCode
                            .MapStringToEnumOrNull<CultureCode>());

        public async Task<PagedData<PlateDto>> GetPlatesAsync(GetAllPlates getAllPlates)
        {
             var (plates, amount) = await _plateService.GetAllPlates(
                getAllPlates.Numbers,
                getAllPlates.CultureCode.TryToParseToEnum<CultureCode>(),
                getAllPlates.Page);

            return new PagedData<PlateDto>(
                plates.Select(x => MapToPlateDto(x)),
                amount);
        }

		public async Task<PlateDto> GetPlateByIdAsync(Guid plateId)
		{
			var plate = await _plateService.GetPlateAsync(plateId);

            return MapToPlateDto(plate);
		}

        private PlateDto MapToPlateDto(Plate plate)
        {
            if (plate is null)
            {
                return default;
            }
          
            return new PlateDto(
                plate.Id,
                plate.Number,
                plate.Culture.ToString());
        }

        public async Task AddSpotAsync(AddComment plate, string spotterUserName)
        {
            await _plateService.AddSpotToPlateAsync(
                plate.PlateId,
                plate.Image,
                plate.Description,
                spotterUserName);
        }

        public async Task<PagedData<CommentDto>> GetPlateSpottsAsync(Guid plateId, int? page)
        {
            var (spotts, amount) = await _plateService.GetPlateSpottsAsync(plateId, page);

            return new PagedData<CommentDto>(
                spotts.Select(x => MapToSpottDto(x)),
                amount );
        }

        private CommentDto MapToSpottDto(Comment spott)
            => new CommentDto(
                spott.Id,
                spott.Description,
                spott.Image,
                spott.User.Username,
                spott.CreatedAt);

        public async Task AddOrRemoveReactionToPlateAsync(AddReaction plateLike, IPAddress userIpAddress)
            => await _plateService.AddOrRemoveReactionToPlateAsync(
                plateLike.PlateId,
                userIpAddress,
                plateLike.LikeType);

        public async Task AddOrRemoveReactionToSpottAsync(AddReaction spottLike, IPAddress userIpAddress)
            => await _plateService.AddOrRemoveReactionToSpottAsync(
                spottLike.PlateId,
                spottLike.SpottId,
                userIpAddress, 
                spottLike.LikeType);
    }
}
