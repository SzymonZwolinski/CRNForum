using Platender.Application.DTO;
using Platender.Application.Mapper;
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

        public async Task<PagedData<PlateDto>> GetPlatesAsync(GetAllPlates getAllPlates, IPAddress userIp)
        {
             var (plates, amount) = await _plateService.GetAllPlates(
                getAllPlates.Numbers,
                getAllPlates.CultureCode.TryToParseToEnum<CultureCode>(),
                getAllPlates.Page);

            return new PagedData<PlateDto>(
                plates.Select(x => x.MapToPlateDto(userIp)),
                amount);
        }

		public async Task<PlateDto> GetPlateByIdAsync(Guid plateId, IPAddress userIp)
		{
			var plate = await _plateService.GetPlateAsync(plateId);

            return plate.MapToPlateDto(userIp):
		}

        public async Task AddSpotAsync(AddComment plate, string spotterUserName)
        {
            await _plateService.AddSpotToPlateAsync(
                plate.PlateId,
                plate.Image,
                plate.Description,
                spotterUserName);
        }

        public async Task<PagedData<CommentDto>> GetPlateCommentsAsync(Guid plateId, int? page, IPAddress userIpAddress)
        {
            var (spotts, amount) = await _plateService.GetPlateCommentsAsync(plateId, page);

            return new PagedData<CommentDto>(
                spotts.Select(x => MapToSpottDto(x, userIpAddress)),
                amount );
        }

        private CommentDto MapToSpottDto(Comment spott, IPAddress userIp)
           => new CommentDto(
                spott.Id,
                spott.Description,
                spott.Image,
                spott.User.Username,
                spott.CreatedAt,
                spott.CommentLike.Count(x => x.LikeType == LikeType.Lik),
                spott.CommentLike.Count(x => x.LikeType == LikeType.Dis),
                spott.CommentLike.FirstOrDefault(x => x.UserIPAddress.Equals(userIp))?.LikeType);

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
