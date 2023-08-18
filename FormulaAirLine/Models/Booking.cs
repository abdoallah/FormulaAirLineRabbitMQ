namespace FormulaAirLine.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string PassengerName { get; set; }
        public string PassengerNo { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Status { get; set; }
    }
}
