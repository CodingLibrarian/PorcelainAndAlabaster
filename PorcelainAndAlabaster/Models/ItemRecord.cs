namespace PorcelainAndAlabaster.Models
{
    public class ItemRecord
    {
        protected int ItemId { get; set; }
        protected string? Barcode { get; set; }
        protected DateTime? DueDate { get; set; }
        // Enum This
        protected string? Type { get; set; }
        protected int[]? CirculationStatsIds { get; set; }
        protected int? PatronId{  get; set; }
        protected int? BibRecordId { get; set; }
        protected int? HoldId { get; set; }
        public ItemRecord() { }
        public ItemRecord(int itemId, string? barcode, DateTime? dueDate, string? type, int[]? circulationStatsIds, int? patronId, int? bibRecordId, int? holdId)
        {
            ItemId = itemId;
            Barcode = barcode;
            DueDate = dueDate;
            Type = type;
            CirculationStatsIds = circulationStatsIds;
            PatronId = patronId;
            BibRecordId = bibRecordId;
            HoldId = holdId;
        }
    }
}
