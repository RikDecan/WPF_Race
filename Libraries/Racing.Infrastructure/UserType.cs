namespace Races.Db
{
    public partial class UserType
    {
        #region Properties
        public int UserTypeId { get; set; }
        public string? Name { get; set; }
        public byte IsDeleted { get; set; }
        #endregion

        #region Ctor
        public UserType()
        {
        }
        #endregion
    }
}
