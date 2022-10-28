﻿using System;

namespace JobsForAll.Library.Models.Authentication
{
    public class LoginResponse
    {
        public string Email { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string JwtToken { get; set; }

    }
}