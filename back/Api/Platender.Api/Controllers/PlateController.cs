using Microsoft.AspNetCore.Mvc;
using Platender.Application.Messages;
using Platender.Application.Providers;

namespace Platender.Api.Controllers
{
	[Route("[Controller]")]
	public class PlateController
	{
		private readonly IPlateProvider _plateProvider;

		public PlateController(IPlateProvider plateProvider)
		{
			_plateProvider = plateProvider;
		}

		[HttpGet]
		public async Task<IActionResult> GetPlate([FromQuery] string numbers)
		{
			var plate = await _plateProvider.GetPlateAsync(numbers);
			return new JsonResult(plate);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetPlateById([FromRoute] Guid plateId)
		{
			var plate = await _plateProvider.GetPlateByIdAsync(plateId);

			return new JsonResult(plate);
		}

		[HttpPost]
		public async Task<IActionResult> AddPlate([FromBody] AddPlate plate)
		{
			var plateId = await _plateProvider.AddPlateAsync(plate);
			return new JsonResult($"Plate {plateId}");//Should be casted to class, but leave it for now
		}

		[HttpPost("{id}/comment")]
		public async Task<IResult> AddCommentToPlate([FromRoute] Guid plateId, [FromBody] string content)
		{
			var comment = new AddComment(plateId, content);

			await _plateProvider.AddCommentAsync(comment);
			return Results.Ok();
		}
	}
}
