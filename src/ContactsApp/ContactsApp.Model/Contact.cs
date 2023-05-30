using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ContactsApp.Model
{
    /// <summary>
    /// Описывает контакт
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// Полное имя контакта
        /// </summary>
        private string _fullName;

        /// <summary>
        /// Электронная почта контакта
        /// </summary>
        private string _email;

        /// <summary>
        /// Номер телефона контакта
        /// </summary>
        private string _phoneNumber;

        /// <summary>
        /// Дата рождения контакта
        /// </summary>
        private DateTime _dateOfBirth;

        /// <summary>
        /// ID Вконтакте контакта
        /// </summary>
        private string _vkId;

        /// <summary>
        /// Возвращает или задает полное имя контакта
        /// </summary>
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (value.Length > 100)
                    throw new ArgumentOutOfRangeException("Full name" +
                        " can't be longer than 100 characters");
                _fullName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }

        /// <summary>
        /// Возвращает или задает электронную почту контакта
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value.Length >= 100)
                {
                    throw new ArgumentException($"Contact's email must be less" +
                    $" than {_email.Length}");
                }
                _email = value;
            }
        }

        /// <summary>
        /// Постоянная шаблона телефонного номера
        /// Пример: 8(999)999-99-99
        /// </summary>
        private const string phoneNumberPattren = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

        /// <summary>
        /// Возвращает или задает номер телефона контакта
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (!Regex.IsMatch(value, phoneNumberPattren))
                    throw new ArgumentOutOfRangeException("Invalid phone format. " +
                        "For example: +7 926 123 45 67");
                _phoneNumber = value;
            }
        }

        /// <summary>
        /// Возвращает или задает дату рождения контакта
        /// </summary>
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (value.Year < 1900 || value > DateTime.Now)
                {
                    throw new ArgumentException($"Incorrect year");
                }
                _dateOfBirth = value;
            }
        }

        /// <summary>
        /// Возвращает или задает ID Вконтакте контакта
        /// </summary>
        public string VkId
        {
            get
            {
                return _vkId;
            }
            set
            {
                if (value.Length >= 50)
                {
                    throw new ArgumentException($"Contact's Vk ID must be less " +
                    $"than {_vkId.Length}?");
                }
                _vkId = value;
            }
        }

        /// <summary>
        /// Создает экземпляр <see cref="Contact">
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="vkId"></param>
        public Contact(string fullName, string email, string phoneNumber,
        DateTime dateOfBirth, string vkId)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            VkId = vkId;
        }
        public Contact()
        {

        }

        ///  <summary>
        /// Клонирует экзмепляр класса
        /// </summary>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
