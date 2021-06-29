using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectApp.ViewModels.Authenticatoin
{
    public class LoginResponse
    {
        public string Email { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string JwtcToken { get; set; }

    }
}
