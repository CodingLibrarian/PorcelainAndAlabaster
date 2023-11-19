namespace PorcelainAndAlabaster.Models
{
    public class Hold
    {
        public int? HoldId { get; set; }
        public int[]? PatronIds { get; set; }
        public int? ItemId { get; set; }
        public Hold() { }
        public Hold(int? holdId, int[]? patronIds, int? itemId)
        {
            HoldId = holdId;
            PatronIds = patronIds;
            ItemId = itemId;
        }
    }
}
