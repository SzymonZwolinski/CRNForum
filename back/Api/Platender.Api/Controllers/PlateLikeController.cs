using Microsoft.AspNetCore.Mvc;
using Platender.Application.Messages;
using Platender.Core.Enums;

namespace Platender.Api.Controllers
{
    public partial class PlateController
    {
        [HttpPatch("{plateId}/like")]
        public async Task<IResult> AddLikeToPlate([FromRoute] Guid plateId)
        {
            InitializeHttpContextIP();

            var addLike = new AddReaction(plateId, LikeType.Lik);
            await _plateProvider.AddOrRemoveReactionToPlateAsync(addLike, UserIP);

            return Results.Ok();
        }

        [HttpPatch("{plateId}/dislike")]
        public async Task<IResult> AddDislikeToPlate([FromRoute] Guid plateId)
        {
            InitializeHttpContextIP();

            var addDislike = new AddReaction(plateId, LikeType.Dis);
            await _plateProvider.AddOrRemoveReactionToPlateAsync(addDislike, UserIP);

            return Results.Ok();
        }

        [HttpPatch("{plateId}/{spottId}/like")]
        public async Task<IResult> AddLikeToSpott([FromRoute] Guid plateId, [FromRoute] Guid spottId)
        {
            InitializeHttpContextIP();

            var addLike = new AddReaction(plateId, spottId, LikeType.Lik);
            await _plateProvider.AddOrRemoveReactionToSpottAsync(addLike, UserIP);

            return Results.Ok();
        }

        [HttpPatch("{plateId}/{spottId}/dislike")]
        public async Task<IResult> AddDislikeToSpott([FromRoute] Guid plateId, [FromRoute] Guid spottId)
        {
            InitializeHttpContextIP();

            var addDislike = new AddReaction(plateId, spottId, LikeType.Lik);
            await _plateProvider.AddOrRemoveReactionToSpottAsync(addDislike, UserIP);

            return Results.Ok();
        }

        [HttpGet("top")]
        public async Task<IActionResult> GetTopLikedPlates()
        {
            var plates = await _likesProvider.GetPlateLikeAsync();

            return new JsonResult(plates);
        }

        [HttpGet("spotts/top")]
        public async Task<IActionResult> GetTopLikedSpotts()
        {
            var spotts = await _likesProvider.GetSpottLikeAsync();

            return new JsonResult(spotts);
        }

        [HttpGet("top/liked")]
        public async Task<IActionResult> GetPagedTopLikedPlates([FromQuery] int page, [FromQuery] string cultureCode)
        {
            var plates = await _likesProvider.GetTopLikedPlatesAsync(page, cultureCode);

            return new JsonResult(plates);
        }

        [HttpGet("top/disliked")]
        public async Task<IActionResult> GetPagedTopDislikedPlates([FromQuery] int page, [FromQuery] string cultureCode)
        {
            var plates = await _likesProvider.GetTopDislikedPlatesAsync(page, cultureCode);

            return new JsonResult(plates);
        }
    }
}
