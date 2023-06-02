using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    public class RandomContacts
    {
        /// <summary>
        /// Поле класса <see cref="Project">
        /// </summary>
        private static Project _project = new Project();

        /// <summary>
        /// Переменная для генерации случайного числа
        /// </summary>
        private static Random _randomNumber = new Random();
        /// <summary>
        /// Метод генерации случайных контактов
        /// </summary>
        /// <param name="project"></param>
        /// <param name="count"></param>
        public static void GenerateContacts(Project project, int count)
        {
            string[] surnames = {"Абарников", "Балтабаев", "Бальсунов", "Веденин",
                                 "Виргунов", "Голов", "Добрынин" };
            string[] names = {"Константин", "Егор", "Вячеслав", "Семен",
                              "Михаил", "Станислав" , "Николай"};
            string[] emails = {"abarnikovkon@mail.ru", "baltabaevegor@mail.ru",
                               "balsynovv@mail.ru", "vedenins@mail.ru",
                               "virgmich@mail.ru", "golovstas@mail.ru", "dobrnik@mail.ru"};
            string[] phoneNumbers = {"8(962)662-22-53", "8(906)223-41-77",
                                     "8(967)888-67-15", "8(902)456-78-91",
                                     "8(991)229-71-65", "8(997)654-25-13", "8(966)532-44-22"};
            string[] vkIds = {"@id123456", "@id654321",
                              "@id112233", "@id858367",
                              "@id115490", "@id514263", "@id222222" };

            for (int i = 0; i < count; i++)
            {
                int randIndexName = _randomNumber.Next(names.Length);
                int randIndexSurname = _randomNumber.Next(surnames.Length);
                int randIndexEmail = _randomNumber.Next(emails.Length);
                int randIndexNumber = _randomNumber.Next(phoneNumbers.Length);
                int randIndexVk = _randomNumber.Next(vkIds.Length);
                Contact contact = new Contact(names[randIndexName] + " "
                    + surnames[randIndexSurname],
                    emails[randIndexEmail],
                    phoneNumbers[randIndexNumber],
                    DateTime.Now, vkIds[randIndexVk]);
                project._contactsList.Add(contact);
            }
        }

    }
}