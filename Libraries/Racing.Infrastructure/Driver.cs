namespace Races.Db
{
    public partial class Driver
    {
        #region Properties
        public int DriverId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CallSign { get; set; }
        public byte IsDeleted { get; set; }
        #endregion

        #region Ctor
        public Driver()
        {
        }
        #endregion
    }
}
