using System;

namespace JobsForAll.Domain.ViewModels.Authenticatoin
{
    public class LoginResponse
    {
        public string Email { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string JwtToken { get; set; }

    }
}
