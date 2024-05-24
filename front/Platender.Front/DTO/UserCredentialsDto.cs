namespace Platender.Front.DTO
{
    public class UserCredentialsDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public UserCredentialsDto(string oldPassword, string newPassword)
        {
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }
    }
}
