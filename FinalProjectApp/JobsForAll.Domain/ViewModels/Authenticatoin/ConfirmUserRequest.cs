namespace JobsForAll.Domain.ViewModels.Authenticatoin
{
    public class ConfirmUserRequest
    {
        public string Email { get; set; }
        public string ConfirmationToken { get; set; }
    }
}
