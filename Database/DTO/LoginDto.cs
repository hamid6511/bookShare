﻿namespace bookShare.Database.DTO
{
    public class LoginDTO
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

