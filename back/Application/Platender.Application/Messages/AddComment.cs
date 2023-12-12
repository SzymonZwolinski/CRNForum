
namespace Platender.Application.Messages
{
	public class AddComment
	{		
		public Guid PlateId { get; set; }
		public string Comment { get; set; }

        public AddComment(Guid plateId, string comment)
        {
            Comment = comment;
            PlateId = plateId;
        }
    }
}
