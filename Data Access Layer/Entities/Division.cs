using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Division
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Подразделение
        /// </summary>
        public string Subdivision { get; init; }

        /// <summary>
        /// Название отдела
        /// </summary>
        public string Name { get; init; }

        public ICollection<User> Users { get; init; }

        public List<UserDivision> User { get; init; }
    }
}
