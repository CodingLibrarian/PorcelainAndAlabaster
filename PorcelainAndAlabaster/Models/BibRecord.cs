namespace PorcelainAndAlabaster.Models
{
    public class BibRecord
    {
        protected int? Id { get; set; }
        protected string? Title { get; set; }
        protected string? Author { get; set; }
        protected string? Publisher { get; set; }
        protected string? PublisherLocation { get; set; }
        protected int? PublicationYear { get; set; }
        protected DateTime Created { get; set; }
        protected DateTime? LastUpdated { get; set; }
        protected bool IsDeleted { get; set; }
        protected string? Description { get; set; }
        protected int[]? Items { get; set; }
        //This is a JSON String due to the problem that different libraries will use different systems and number values for subnumbers the there is a need to keep this generic
        protected string? MARCRecord { get; set; }
        public  BibRecord() { }

        public BibRecord(int? id, string? title, string? author, string? publisher, string? location, int? year, DateTime created, DateTime? lastUpdated, bool isDeleted, string? description, int[]? items, string? mARCRecord)
        {
            Id = id;
            Title = title;
            Author = author;
            Publisher = publisher;
            PublisherLocation = location;
            PublicationYear = year;
            Created = created;
            LastUpdated = lastUpdated;
            IsDeleted = isDeleted;
            Description = description;
            Items = items;
            MARCRecord = mARCRecord;
        }
    }
}
