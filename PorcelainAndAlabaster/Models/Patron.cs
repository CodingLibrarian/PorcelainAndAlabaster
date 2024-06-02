using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace PorcelainAndAlabaster.Models
{
    public class Patron
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? PrimaryMailingAddress { get; set; }
        public string? SecondaryMailingAddress { get; set; }
        public string? EmailAddress { get; set;}
        public string? HomePhoneNumber { get; set; }
        public string? MobilePhoneNumber { get; set; }
        public string? AccessCode { get; set; }
        public int? PatronId { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? Created { get; set; }
        public bool? IsDeleted { get; set; }
        // Make this an enum
        public string? Status { get; set; }
        public string? Settings { get; set; }

        public Patron() { }

        public Patron(string? firstName, string? middleName, string? lastName, string? primaryMailingAddress, string? secondaryMailingAddress, string? emailAddress, string? homePhoneNumber, string? mobilePhoneNumber, string? accessCode, int? patronId, DateTime? lastModified, DateTime? created, bool? isDeleted, string? status, string? settings)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            PrimaryMailingAddress = primaryMailingAddress;
            SecondaryMailingAddress = secondaryMailingAddress;
            EmailAddress = emailAddress;
            HomePhoneNumber = homePhoneNumber;
            MobilePhoneNumber = mobilePhoneNumber;
            AccessCode = accessCode;
            PatronId = patronId;
            LastModified = lastModified;
            Created = created;
            IsDeleted = isDeleted;
            this.Status = status;
            this.Settings = settings;
        }
    }

}
