using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace PorcelainAndAlabaster.Models
{
    public class Patron
    {
        protected string? FirstName { get; set; }
        protected string? MiddleName { get; set; }
        protected string? LastName { get; set; }
        protected string? PrimaryMailingAddress { get; set; }
        protected string? SecondaryMailingAddress { get; set; }
        protected string? EmailAddress { get; set;}
        protected string? HomePhoneNumber { get; set; }
        protected string? MobilePhoneNumber { get; set; }
        protected string? AccessCode { get; set; }
        protected int? PatronId { get; set; }
        protected DateTime? LastModified { get; set; }
        protected DateTime? Created { get; set; }
        protected bool? IsDeleted { get; set; }
        // Make this an enum
        protected string? status { get; set; }

        public Patron() { }

        public Patron(string? firstName, string? middleName, string? lastName, string? primaryMailingAddress, string? secondaryMailingAddress, string? emailAddress, string? homePhoneNumber, string? mobilePhoneNumber, string? accessCode, int? patronId, DateTime? lastModified, DateTime? created, bool? isDeleted, string? status)
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
            this.status = status;
        }
    }

}
