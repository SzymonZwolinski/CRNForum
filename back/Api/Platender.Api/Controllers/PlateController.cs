using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platender.Application.Messages;
using Platender.Application.Providers;
using Platender.Application.Query;
using Platender.Core.Enums;
using Platender.Core.Helpers;

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
		public async Task<IActionResult> GetPlates([FromQuery] GetPlate getPlate)
		{
			 var plates = await _plateProvider.GetPlatesAsync(
				getPlate.Numbers,
				getPlate.CultureCode.TryToParseToEnum<CultureCode>());
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
			
			return new JsonResult($"Plate {plateId}");//Should be casted to class, but leave it for now
		}

		[Authorize]
		[HttpPost("{id}/comment")]
		public async Task<IResult> AddCommentToPlate([FromRoute] Guid plateId, [FromBody] string content)
		{
			InitalizeHttpContextClaims();
			var comment = new AddComment(plateId, content);

			await _plateProvider.AddCommentAsync(comment, UserName);
			return Results.Ok();
		}
	}
}
