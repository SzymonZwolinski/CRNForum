using Platender.Application.DTO;
using Platender.Application.Messages;

namespace Platender.Application.Providers
{
    public interface IPlateProvider
    {
        Task<PlateDTO> GetPlateAsync(string numbers);
        Task<Guid> AddPlateAsync(AddPlate plate);
        Task AddCommentAsync(AddComment comment);
    }
}
