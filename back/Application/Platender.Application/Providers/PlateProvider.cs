using Platender.Application.DTO;
using Platender.Application.Messages;
using Platender.Core.Enums;
using Platender.Core.Extensions.EnumExtensions;
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
            await _plateService.AddCommentToPlateAsync(comment.PlateId, comment.Comment, commentingUserName);
		}

		public async Task<Guid> AddPlateAsync(AddPlate addPlate)
        {

            return await _plateService
                .AddPlateAsync(
                    addPlate.Numbers, 
                    addPlate.CultureCode
                            .MapStringToEnumOrNull<CultureCode>());
        }

        public async Task<IEnumerable<PlateDTO>> GetPlatesAsync(string numbers, CultureCode? cultureCode)
        {
            var plate = await _plateService.GetPlatesByNumbers(numbers, cultureCode);

            return plate.Select(x => MapToPlateDto(x));
        }

		public async Task<PlateDTO> GetPlateByIdAsync(Guid plateId)
		{
			var plate = await _plateService.GetPlateAsync(plateId);

            return MapToPlateDto(plate);
		}

		private PlateDTO MapToPlateDto(Plate plate)
        {
            if(plate is null)
            {
                return default;
            }
            var commentDto = plate.Comments
                .Select(x => 
                new CommentDTO(
                    x.Id,
                    x.Content,
                    x.User.Username,
                    x.Sequence,
                    x.LikeCount,
                    x.DislikeCount));

            return
                new PlateDTO(
                    plate.Id,
                    plate.Number,
                    plate.LikeRatio,
                    plate.Culture.ToString(),
                    commentDto);
        }
    }
}
