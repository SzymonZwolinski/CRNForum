using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platender.Application.Messages;
using Platender.Application.Messages.Queries;
using Platender.Application.Providers;
using Platender.Core.Enums;
using Platender.Core.Helpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
			
			await _plateProvider.AddCommentAsync(comment, UserName);
			return Results.Ok();
		}
	}
}
