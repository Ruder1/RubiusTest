using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class UserDivision
    {
        public int UserDivisionID { get; init; }
        public int UserID { get; init; }
        public int DivisionID { get; init; }

        public User User { get; init; }
        public Division Division { get; init; }
    }
}
