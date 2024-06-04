namespace PorcelainAndAlabaster.Models
{
    public class ItemRecord
    {
        public int ItemId { get; set; }
        public string? Barcode { get; set; }
        public DateTime? DueDate { get; set; }
        // Enum This
        public string? ItemType { get; set; }
        public int[]? CirculationStatsIds { get; set; }
        public int? PatronId{  get; set; }
        public int? BibRecordId { get; set; }
        public int? HoldId { get; set; }
        public ItemRecord() { }
        public ItemRecord(int itemId, string? barcode, DateTime? dueDate, string? type, int[]? circulationStatsIds, int? patronId, int? bibRecordId, int? holdId)
        {
            ItemId = itemId;
            Barcode = barcode;
            DueDate = dueDate;
            ItemType = type;
            CirculationStatsIds = circulationStatsIds;
            PatronId = patronId;
            BibRecordId = bibRecordId;
            HoldId = holdId;
        }
    }
}
