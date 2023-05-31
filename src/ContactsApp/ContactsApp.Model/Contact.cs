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
        private string _phone;

        /// <summary>
        /// Дата рождения контакта
        /// </summary>
        private DateTime _dateOfBirth;

        /// <summary>
        /// ID Вконтакте контакта
        /// </summary>
        private string _vkId;

        /// <summary>
        /// Постоянная шаблона телефонного номера
        /// Пример: 8(999)999-99-99
        /// </summary>
        private const string phoneNumberPattren = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

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
                if (value.Length > 100)
                    throw new ArgumentOutOfRangeException("Email can't be longer than" +
                        " 100 characters");
                _email = value;

            }
        }

        /// <summary>
        /// Возвращает или задает номер телефона контакта
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return _phone;
            }
            set
            {
                {
                    if (!Regex.IsMatch(value, @"[\d\s\+\-\(\)]"))
                        throw new ArgumentOutOfRangeException("Invalid phone format");
                    _phone = value;
                }

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
                    throw new ArgumentOutOfRangeException("Invalid Date of Birth");
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
                if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("VK ID " +
                        "can't be longer than 50 characters");
                _vkId = value;

            }
        }

        /// <summary>
        /// Создает экземпляр <see cref="Contact">
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="vkId"></param>
        public Contact(string fullName, string email, string phone,
        DateTime dateOfBirth, string vkId)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phone;
            DateOfBirth = dateOfBirth;
            VkId = vkId;
        }

        /// <summary>
        ///Метод создаюший пустой экземпляр класса Contact
        /// </summary>
        public Contact()
        {

        }

        ///  <summary>
        /// Клонирует экзмепляр класса
        /// </summary>
        public object Clone()
        {
            return new Contact(this.FullName, this.Email, this.PhoneNumber, this.DateOfBirth, this.VkId);
        }
    }
}