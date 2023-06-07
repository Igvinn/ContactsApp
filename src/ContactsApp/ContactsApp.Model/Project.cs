using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;

namespace ContactsApp.Model
{

    public class Project
    {
        /// <summary>
        /// Список контактов в проекте
        /// </summary>
        public List<Contact> _contactsList { get; set; } = new List<Contact>();


        /// <summary>
        /// Сортирует список по полному имени
        /// </summary>
        public void SortFullNameContacts()
        {
            _contactsList = _contactsList.OrderBy(c => c.FullName).ToList();
        }


        /// <summary>
        /// Поиск контакта по подстроке
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<Contact> FindContactsBySubstring(List<Contact> contacts, string substring)
        {
            var NewContacts = contacts.Where(c =>
            c.FullName.Contains(substring) ||
            c.Email.Contains(substring) ||
            c.PhoneNumber.Contains(substring) ||
            c.VkId.Contains(substring)).
            ToList();
            return NewContacts;
        }


        /// <summary>
        /// Поиск дней рождлений
        /// </summary>
        /// <returns></returns>
        public List<Contact> FindBirthdaysToday()
        {
            var now = DateTime.Now;
            return _contactsList.Where(c =>
            c.DateOfBirth.Month == now.Month &&
            c.DateOfBirth.Day == now.Day).
            ToList();
        }

    }
}