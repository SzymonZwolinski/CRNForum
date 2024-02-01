using Platender.Core.Enums;

namespace Platender.Application.Messages.Queries
{
    public class GetAllPlates
    {
        public int Page { get; set; }
        public string CultureCode { get; set; }
        public string Numbers { get; set; }
    }
}
