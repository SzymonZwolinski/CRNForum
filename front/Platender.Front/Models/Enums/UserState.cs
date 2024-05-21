namespace Platender.Front.Models.Enums
{
    public enum UserState
    {
        /// <summary>
        /// User contains Username && JWT TOKEN
        /// </summary>
        BasicAuth,

        /// <summary>
        /// User does not contain Username && JWT TOKEN
        /// </summary>
        NotAuth,
    }
}