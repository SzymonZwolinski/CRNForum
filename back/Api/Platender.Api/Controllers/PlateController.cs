﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platender.Application.Messages;
using Platender.Application.Messages.Queries;
using Platender.Application.Providers;

namespace Platender.Api.Controllers
{
    [Route("[Controller]")]
	public partial class PlateController : BaseController
	{
		private readonly IPlateProvider _plateProvider;
		private readonly ILikesProvider _likesProvider;

		public PlateController(IPlateProvider plateProvider, ILikesProvider likesProvider)
		{
			_plateProvider = plateProvider;
			_likesProvider = likesProvider;
		}

		[HttpGet]
		public async Task<IActionResult> GetPlate([FromQuery] GetAllPlates query)
		{
			InitializeHttpContextIP();
            var plates = await _plateProvider.GetPlatesAsync(query, UserIP);

            return new JsonResult(plates);
        }

		[HttpGet("{plateId}")]
		public async Task<IActionResult> GetPlateById([FromRoute] Guid plateId)
		{
			InitializeHttpContextIP();
            var plate = await _plateProvider.GetPlateByIdAsync(plateId, UserIP);

			return new JsonResult(plate);
		}

        [HttpGet("{plateId}/comments")]
        public async Task<IActionResult> GetPlateComments([FromRoute] Guid plateId, [FromQuery] int page)
        {
			InitializeHttpContextIP();
            var plateComments = await _plateProvider.GetPlateCommentsAsync(plateId, page, UserIP);

            return new JsonResult(plateComments);
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
		public async Task<IResult> AddCommentToPlate([FromRoute] Guid plateId, [FromBody] AddComment spot)
		{
			InitalizeHttpContextClaims();
			spot.PlateId = plateId;

			await _plateProvider.AddSpotAsync(spot, UserName);
			return Results.Ok();
		}
	}
}
