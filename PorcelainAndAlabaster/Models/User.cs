using Microsoft.AspNetCore.Identity;

namespace PorcelainAndAlabaster.Models
{
    public class User : Patron
    {
        public int? UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Setting { get; set; }
        public User() { }
        public User(int? userId, string? username, string? password, int? patronId, string? setting)
        {
            UserId = userId;
            Username = username;
            Password = password;
            PatronId = patronId;
            Setting = setting;
        }
    }
}
