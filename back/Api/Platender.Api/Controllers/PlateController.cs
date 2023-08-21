using Microsoft.AspNetCore.Mvc;
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
		public async Task<IActionResult> GetPlate([FromQuery] Guid plateId)
		{
			var plate = await _plateProvider.GetPlateAsync(plateId);
			return new JsonResult(plate);
		}
	}
}
