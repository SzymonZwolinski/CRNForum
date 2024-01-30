
namespace Platender.Application.Messages
{
	public class AddComment
	{		
		public Guid PlateId { get; set; }
		public string Content { get; set; }

        public AddComment(Guid plateId, string content)
        {
            Content = content;
            PlateId = plateId;
        }
    }
}
