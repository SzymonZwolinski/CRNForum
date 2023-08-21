using Platender.Application.DTO;

namespace Platender.Application.Providers
{
    public interface IPlateProvider
    {
        Task<PlateDTO> GetPlateAsync(Guid plateId);

    }
}
