using Platender.Core.Enums;
using System.Net;

namespace Platender.Core.Models.Abstract
{
    public abstract class Like
    {
        public Guid Id { get; protected set; }
        public IPAddress UserIPAddress { get; protected set; }
        public LikeType LikeType { get; protected set; }
    }
}
