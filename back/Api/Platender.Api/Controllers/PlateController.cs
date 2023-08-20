using Microsoft.AspNetCore.Mvc;
using Platender.Core.Services;

namespace Platender.Api.Controllers
{
	[Route("[Controller]")]
	public class PlateController
	{
		private readonly IPlateService _plateService;

		public PlateController(IPlateService plateService)
		{
			_plateService = plateService;
		}

		[HttpGet]
		public async Task<IActionResult> GetPlate([FromQuery] Guid plateId)
		{
			var plate = await _plateService.GetPlateAsync(plateId);
			return new JsonResult(plate);
		}
	}
}
