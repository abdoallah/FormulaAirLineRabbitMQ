﻿namespace formulaAirLine.API.Models
{
    public class Bookings
    {
        public int Id { get; set; }
        public string PassengerName { get; set; }
        public string PassportNo { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Status { get; set; }
    }
}
