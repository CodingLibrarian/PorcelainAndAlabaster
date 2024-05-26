namespace PorcelainAndAlabaster.Models
{
    public class Contact
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Question { get; set; }

        public Contact() { }

        public Contact(string? firstName, string? lastName, string? email, string? question)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Question = question;
        }
    }
}
