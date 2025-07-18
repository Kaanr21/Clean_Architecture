﻿using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public AppUser()
        {

            Id = Guid.NewGuid().ToString();
        }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpire { get; set; }
    }
}
