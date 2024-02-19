using Platender.Application.DTO;
using Platender.Application.Messages;
using Platender.Application.Messages.Queries;
using Platender.Core.Enums;
using Platender.Core.Extensions.EnumExtensions;
using Platender.Core.Helpers;
using Platender.Core.Models;
using Platender.Core.Services;

namespace Platender.Application.Providers
{
    public class PlateProvider : IPlateProvider
    {
        private readonly IPlateService _plateService;

        public PlateProvider(IPlateService plateService)
        {
            _plateService = plateService;
        }

		public async Task AddCommentAsync(AddComment comment, string commentingUserName)
		{
            await _plateService.AddCommentToPlateAsync(comment.PlateId, comment.Content, commentingUserName);
		}

		public async Task<Guid> AddPlateAsync(AddPlate addPlate)
        {

            return await _plateService
                .AddPlateAsync(
                    addPlate.Numbers, 
                    addPlate.CultureCode
                            .MapStringToEnumOrNull<CultureCode>());
        }

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
                plate.LikeRatio,
                plate.Culture.ToString());
        }

        public async Task AddSpotAsync(AddSpot plate, string spotterUserName)
        {
            await _plateService.AddSpotToPlateAsync(
                plate.PlateId,
                plate.Image,
                plate.Description,
                spotterUserName);
        }

        public async Task<PagedData<CommentDto>> GetPlateCommentsAsync(Guid plateId, int? page)
        {
            var (comments, amount) = await _plateService.GetPlateCommentsAsync(plateId, page);

            return new PagedData<CommentDto>(
                comments.Select(x => MapToCommentDto(x)),
                amount);
        }

        private CommentDto MapToCommentDto(Comment comment) 
            => new CommentDto(
                comment.Id, 
                comment.Content,
                comment.User.Username,
                comment.Sequence,
                comment.LikeCount,
                comment.DislikeCount,
                comment.CreatedAt);

        public async Task<PagedData<SpottDto>> GetPlateSpottsAsync(Guid plateId, int? page)
        {
            var (spotts, amount) = await _plateService.GetPlateSpottsAsync(plateId, page);

            return new PagedData<SpottDto>(
                spotts.Select(x => MapToSpottDto(x)),
                amount );
        }

        private SpottDto MapToSpottDto(Spotts spott)
            => new SpottDto(
                spott.Id,
                spott.Description,
                spott.Image,
                spott.User.Username,
                spott.CreatedAt);
    }
}
