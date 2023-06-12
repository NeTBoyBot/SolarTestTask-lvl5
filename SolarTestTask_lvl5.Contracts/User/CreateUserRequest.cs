using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarTestTask_lvl5.Contracts.User
{
    /// <summary>
    /// Модель для создания пользователя
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// ФИО пользователя
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Адрес электронной почты пользователя 
        /// </summary>
        [EmailAddress]
        public string email { get; set; }

        /// <summary>
        /// Дата рождения пользователя
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}
