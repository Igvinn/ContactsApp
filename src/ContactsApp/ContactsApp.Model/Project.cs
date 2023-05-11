using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    /// <summary>
    /// Описывает проект
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список контактов в проекте
        /// </summary>
        public List<Contact> Contacts = new List<Contact>();

        /// <summary>
        /// Сортирует список по полному имени
        /// </summary>
        /// <returns>Отсортированный список</returns>
        public List<Contact> SortContactsByFullName()
        {
            return Contacts.OrderBy(c => c.FullName).ToList();
        }

        /// <summary>
        /// Находит контакты у которых сегодня день рождения
        /// </summary>
        /// <returns>Список именинников</returns>
        public List<Contact> FindBirthdaysContacts()
        {
            DateTime today = DateTime.Now;
            List<Contact> result = new List<Contact>();
            foreach (Contact contact in Contacts)
            {
                if ((contact.DateOfBirth.Month == today.Month) &&
                (contact.DateOfBirth.Day == today.Day))
                {
                    result.Add(contact);
                }
            }
            return result;
        }

        /// <summary>
        /// Выполняет поиск по подстроке имени
        /// </summary>
        /// <param name="substring">Подстрока имени</param>
        /// <returns>Список найденных контактов</returns>
        public List<Contact> FindContacts(string substring)
        {
            List<Contact> result = new List<Contact>();
            foreach (Contact contact in Contacts)
            {
                if (contact.FullName.Contains(substring))
                {
                    result.Add(contact);
                }
            }
            return result;
        }
    }
}

