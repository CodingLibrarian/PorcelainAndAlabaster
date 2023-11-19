namespace PorcelainAndAlabaster.Models
{
    public class Fine
    {
        protected int? FineId { get; set; }
        protected int? ItemId { get; set; }
        protected int? PatronId { get; set; }
        protected decimal? Cost { get; set; }
        //Enum this field
        protected string? FineStatus { get; set; }
        public Fine() { }
        public Fine(int? fineId, int? itemId, int? patronId, decimal? cost, string? fineStatus)
        {
            FineId = fineId;
            ItemId = itemId;
            PatronId = patronId;
            Cost = cost;
            FineStatus = fineStatus;
        }
    }
}
