using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{

    public class Project
    {
        /// <summary>
        /// Список контактов в проекте
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
        /// Сортирует список по полному имени
        /// </summary>
        public List<Contact> SortByFullName(List<Contact> contacts)
        {
            var orderByContact = contacts.OrderBy(contact => contact.FullName).ToList();
            return orderByContact;
        }

        /// <summary>
        /// Возвращает список объектов <see cref="Contact">, одно из полей которых 
        /// содержит подаваемый паттерн.
        /// </summary>
        public List<Contact> SearchContactsByPattern(List<Contact> contacts, string pattern)
        {
            if (pattern != "")
            {
                var selectedContact = contacts.Where(contact => contact.FullName.Contains(pattern)).ToList();
                return selectedContact;
            }
            else return contacts;
        }

        /// <summary>
        /// Возвращает список объектов <see cref="Contact">, чей сегодня день рождения.
        /// </summary>
        public List<Contact> FindContactByDayOfBirth(List<Contact> contacts)
        {
            var birthdayContacts = contacts.Where(contact => contact.DateOfBirth.Day == DateTime.Today.Day
            && contact.DateOfBirth.Month == DateTime.Today.Month).ToList();
            return birthdayContacts;
        }
    }
}

