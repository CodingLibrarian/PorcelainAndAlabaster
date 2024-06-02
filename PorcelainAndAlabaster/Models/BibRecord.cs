namespace PorcelainAndAlabaster.Models
{
    public class BibRecord
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public string? PublisherLocation { get; set; }
        public int? PublicationYear { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
        public string? Description { get; set; }
        public int[]? Items { get; set; }
        //This is a JSON String due to the problem that different libraries will use different systems and number values for subnumbers the there is a need to keep this generic
        public string? MARCRecord { get; set; }
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
