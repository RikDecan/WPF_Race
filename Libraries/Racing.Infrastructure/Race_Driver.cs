namespace Races.Db
{
    public partial class Race_Driver
    {
        #region Properties
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public byte IsDeleted { get; set; }
        #endregion

        #region Ctor
        public Race_Driver()
        {
        }
        #endregion
    }
}
