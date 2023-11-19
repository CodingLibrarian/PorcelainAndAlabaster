namespace PorcelainAndAlabaster.Models
{
    public class CirculationRecord
    {
        protected DateTime? CheckoutDate { get; set;}
        protected int? CirculationId { get; set;}
        protected int? ItemId { get; set;}
        protected int? PatronId { get; set;}

        public CirculationRecord() { }
        
        public CirculationRecord(DateTime? checoutDate, int? circualtionId, int? itemId, int? patronId)
        {
            CheckoutDate = checoutDate;
            CirculationId = circualtionId;
            ItemId = itemId;
            PatronId = patronId;
        }
    }
}
