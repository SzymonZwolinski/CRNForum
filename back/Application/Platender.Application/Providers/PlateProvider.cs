using Platender.Application.DTO;
using Platender.Core.Models;
using Platender.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platender.Application.Providers
{
    public class PlateProvider : IPlateProvider
    {
        private readonly IPlateService _plateService;

        public PlateProvider(IPlateService plateService)
        {
            _plateService = plateService;
        }

        public async Task<PlateDTO> GetPlateAsync(Guid plateId)
        {
            var plate = await _plateService.GetPlateAsync(plateId);

            return MapToPlateDto(plate);
        }
        
        private PlateDTO MapToPlateDto(Plate plate)
        {
            var commentDto = plate.Comments
                .Select(x => 
                new CommentDTO(
                    x.Id,
                    x.Content,
                    x.AddingUserName,
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
