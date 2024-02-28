using Microsoft.AspNetCore.Mvc;
using Platender.Application.Messages;
using Platender.Core.Enums;

namespace Platender.Api.Controllers
{
    public partial class PlateController
    {
        [HttpPut("{plateId}/like")]
        public async Task<IResult> AddLikeToPlate([FromRoute] Guid plateId)
        {
            InitializeHttpContextIP();

            var addLike = new AddReaction(plateId, LikeType.Lik);
            await _plateProvider.AddOrRemoveReactionToPlateAsync(addLike, UserIP);

            return Results.Ok();
        }

        [HttpPut("{plateId}/dislike")]
        public async Task<IResult> AddDislikeToPlate([FromRoute] Guid plateId)
        {
            InitializeHttpContextIP();

            var addDislike = new AddReaction(plateId, LikeType.Dis);
            await _plateProvider.AddOrRemoveReactionToPlateAsync(addDislike, UserIP);

            return Results.Ok();
        }

        [HttpPut("{plateId}/{spottId}/like")]
        public async Task<IResult> AddLikeToSpott([FromRoute] Guid plateId, [FromRoute] Guid spottId)
        {
            InitializeHttpContextIP();

            var addLike = new AddReaction(plateId, spottId, LikeType.Lik);
            await _plateProvider.AddOrRemoveReactionToSpottAsync(addLike, UserIP);

            return Results.Ok();
        }

        [HttpPut("{plateId}/{spottId}/dislike")]
        public async Task<IResult> AddDislikeToSpott([FromRoute] Guid plateId, [FromRoute] Guid spottId)
        {
            InitializeHttpContextIP();

            var addDislike = new AddReaction(plateId, spottId, LikeType.Lik);
            await _plateProvider.AddOrRemoveReactionToSpottAsync(addDislike, UserIP);

            return Results.Ok();
        }
    }
}
