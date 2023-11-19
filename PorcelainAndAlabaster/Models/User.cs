using Microsoft.AspNetCore.Identity;

namespace PorcelainAndAlabaster.Models
{
    public class User : Patron
    {
        protected int? UserId { get; set; }
        protected string? Username { get; set; }
        protected string? Password { get; set; }
        protected string? Email { get; set; }
        public User() { }
        public User(int? userId, string? username, string? password, string? email)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Email = email;
        }
    }
}
