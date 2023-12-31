﻿namespace DataAccessLayer.Entities
{
    public class User
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; init; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string LastName { get; init; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; init; }

        /// <summary>
        /// Оклад
        /// </summary>
        public int Salary { get; init; }

        /// <summary>
        /// Подразделения
        /// </summary>
        /// 

        public List<Division> Divisions { get; init; } = new List<Division>();

        public ICollection<Enrollment> Enrollments { get; init; } = new List<Enrollment>();
    }
}