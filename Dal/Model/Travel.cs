namespace Dal.Model
{
    public class Travel : IComparable<Travel>, IEquatable<Travel>
    {
        private int travelID;
        private string departure;
        private DateTime departureDate;
        private string arrival;
        private DateTime arrivalDate;
        private int numberOfPassengers;

        public int TravelID { get => travelID; set => travelID = value; }
        public string Departure { get => departure; set => departure = value; }
        public DateTime DepartureDate { get => departureDate; set => departureDate = value; }
        public string Arrival { get => arrival; set => arrival = value; }
        public DateTime ArrivalDate { get => arrivalDate; set => arrivalDate = value; }
        public int NumberOfPassengers { get => numberOfPassengers; set => numberOfPassengers = value; }

        public int CompareTo(Travel? obj)
        {
            if (obj == null) return 1;
            else if ((obj.Departure == this.Departure) & (obj.Arrival == this.Arrival) & (obj.DepartureDate == this.DepartureDate) & (obj.ArrivalDate == this.ArrivalDate)) return 0;
            else if ((this.DepartureDate > obj.DepartureDate) | (this.ArrivalDate > obj.ArrivalDate) | (String.Compare(this.Departure, obj.Departure) > 0) | (String.Compare(this.Arrival, obj.Arrival) > 0)) return 1;
            else if ((this.DepartureDate < obj.DepartureDate) | (this.ArrivalDate < obj.ArrivalDate) | (String.Compare(this.Departure, obj.Departure) < 0) | (String.Compare(this.Arrival, obj.Arrival) < 0)) return -1;
            return 0;


        }

        public bool Equals(Travel? obj)
        {
            if ((String.Compare(this.Departure, obj.Departure) == 0) & (String.Compare(this.Arrival, obj.Arrival) == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
