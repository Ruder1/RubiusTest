using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        /// Название отдела
        /// </summary>
        public string Name { get; init; }

        public int? ParentId { get; init; }

        public Division? Parent { get; init; }

        public List<Division> Children { get; init; } = new List<Division>();

        public ICollection<User> Users { get; init; } = new List<User>();

        public ICollection<Enrollment> Enrollments { get; init; } = new List<Enrollment>();
    }
}
