namespace Races.Db
{
    public partial class User
    {
        #region Properties
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CallSign { get; set; }
        public DateTime? BirthDate { get; set; }
        public int UserTypeId { get; set; }
        public string? Password { get; set; }
        public byte IsDeleted { get; set; }
        #endregion

        #region Ctor
        public User()
        {
        }
        #endregion
    }
}
