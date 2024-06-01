using Microsoft.AspNetCore.Identity;

namespace PorcelainAndAlabaster.Models
{
    public class User : Patron
    {
        public int? UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public User() { }
        public User(int? userId, string? username, string? password, int? patronId)
        {
            UserId = userId;
            Username = username;
            Password = password;
            PatronId = patronId;
        }
    }
}
