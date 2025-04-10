namespace ProjectCinema.Entities
{
    public struct Capacity
    {
        public int Rows { get; set; }
        public int SeatsPerRow { get; set; }

        public Capacity(int rows, int seatsPerRow)
        {
            Rows = rows;
            SeatsPerRow = seatsPerRow;
        }

        public int TotalSeats => Rows * SeatsPerRow;

        public override string ToString()
        {
            return $"{Rows} rows x {SeatsPerRow} seats = {TotalSeats} total seats";
        }
    }
}
