using Platender.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platender.Core.Services
{
	public interface IPlateService
	{
		Task<bool> CheckIfPlateExistsAsync(string number);
		Task<Plate> GetPlateAsync(Guid plateId);
        Task<Plate> GetPlateByNumbers(string numbers);
        Task AddPlateAsync(string number);
		Task AddCommentToPlateAsync(Guid plateId, string content, string userName);
		void AddLikeToPlate(Guid plateId);
		void RemoveLikeFromPlate(Guid plateId);
		void AddLikeToCommentInPlate(Guid plateId, Guid commentId);
		void RemoveLikeFromCommentInPlate(Guid plateId, Guid commentId);
		void AddDislikeToCommentInPlate(Guid plateId, Guid commentId);
		void RemoveDislikeToCommentInPlate(Guid plateId, Guid commentId);

	}
}
