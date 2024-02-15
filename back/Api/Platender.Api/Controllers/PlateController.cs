﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platender.Application.Messages;
using Platender.Application.Messages.Queries;
using Platender.Application.Providers;

namespace Platender.Api.Controllers
{
    [Route("[Controller]")]
	public class PlateController : BaseController
	{
		private readonly IPlateProvider _plateProvider;

		public PlateController(IPlateProvider plateProvider)
		{
			_plateProvider = plateProvider;
		}

		[HttpGet]
		public async Task<IActionResult> GetPlate([FromQuery] GetAllPlates query)
		{
            var plates = await _plateProvider.GetPlatesAsync(query);

            return new JsonResult(plates);
        }

		[HttpGet("{plateId}")]
		public async Task<IActionResult> GetPlateById([FromRoute] Guid plateId)
		{
			var plate = await _plateProvider.GetPlateByIdAsync(plateId);

			return new JsonResult(plate);
		}

		[HttpGet("{plateId}/comments")]
		public async Task<IActionResult> GetPlateComments([FromRoute] Guid plateId, [FromQuery] int page)
		{
			var plateComments = await _plateProvider.GetPlateCommentsAsync(plateId, page);

			return new JsonResult(plateComments);
		}

        [HttpGet("{plateId}/spotts")]
        public async Task<IActionResult> GetPlateSpotts([FromRoute] Guid plateId, [FromQuery] int page)
        {
            var plateSpotts = await _plateProvider.GetPlateSpottsAsync(plateId, page);

            return new JsonResult(plateSpotts);
        }

        [Authorize]
		[HttpPost]
		public async Task<IActionResult> AddPlate([FromBody] AddPlate plate)
		{
            InitalizeHttpContextClaims();

			var plateId = await _plateProvider.AddPlateAsync(plate);
			
			return new JsonResult($"{plateId}");
		}

		[Authorize]
		[HttpPut("{plateId}/comment")]
		public async Task<IResult> AddCommentToPlate([FromRoute] Guid plateId, [FromBody] AddComment comment)
		{
			InitalizeHttpContextClaims();
			comment.PlateId = plateId;
			
			await _plateProvider.AddCommentAsync(comment, UserName);
			return Results.Ok();
		}

		[Authorize]
		[HttpPut("{plateId}/spot")]
		public async Task<IResult> AddSpotToPlate([FromRoute] Guid plateId, [FromBody] AddSpot spot)
		{
			InitalizeHttpContextClaims();
			spot.PlateId = plateId;

			await _plateProvider.AddSpotAsync(spot, UserName);
			return Results.Ok();
		}
	}
}
