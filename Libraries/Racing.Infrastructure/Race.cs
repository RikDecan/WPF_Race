namespace Races.Db
{
    public partial class Race
    {
        #region Properties
        public int RaceId { get; set; }
        public string? Name { get; set; }
        public DateTime? StartTime { get; set; }
        public Nullable<DateTime> StopTime { get; set; }
        public Nullable<int> DriverId { get; set; }
        #endregion

        #region Ctor
        public Race()
        {

        }
        #endregion
    }
}
