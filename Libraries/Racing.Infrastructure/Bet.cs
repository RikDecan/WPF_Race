using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Races.Db
{
    public partial class Bet
    {
        #region Properties
        public int BetId { get; set; }
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public int UserId { get; set; }
        public int Amount { get; set; }
        #endregion

        #region Ctor
        public Bet()
        {
        }
        #endregion
    }
}
