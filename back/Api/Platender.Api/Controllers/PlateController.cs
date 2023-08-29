using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Platender.Application.DTO;
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

		[HttpPost]
		public async Task<IResult> AddPlate([FromBody] AddPlate plate)
		{
			await _plateProvider.AddPlateAsync(plate);
			return Results.Ok();
		}
	}
}
