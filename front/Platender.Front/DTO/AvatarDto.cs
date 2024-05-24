namespace Platender.Front.DTO
{
    public class AvatarDto
    {
        public byte[] Avatar { get; set; }

        public AvatarDto(byte[] avatar)
        {
            Avatar = avatar;
        }
    }
}
