using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    /// <summary>
    /// Класс генерации случайных контактов
    /// </summary>
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
        /// Поле фамилий
        /// </summary>
        private static string[] _arrSurname = {"Абарников", "Балтабаев", "Бальсунов", "Веденин",
                                               "Виргунов", "Голов", "Добрынин" };

        /// <summary>
        /// Поле имен
        /// </summary>
        private static string[] _arrName = {"Константин", "Егор", "Вячеслав", "Семен",
                                            "Михаил", "Станислав" , "Николай"};

        /// <summary>
        /// Поле отчеств
        /// </summary>
        private static string[] _arrPatronymic = {"Петрович","Иванович","Николаевич","Васильевич",
                                             "Дмитриевич","Уланбекович","Игнатович" };

        /// <summary>
        /// Поле ФИО
        /// </summary>
        private static string[] _fullName = new string[10];

        /// <summary>
        /// Поле Email
        /// </summary>
        private static string[] _email = {"abarnikovkon@mail.ru", "baltabaevegor@mail.ru",
                                          "balsynovv@mail.ru", "vedenins@mail.ru",
                                          "virgmich@mail.ru", "golovstas@mail.ru", "dobrnik@mail.ru"};

        /// <summary>
        /// Поле номеров телефонов
        /// </summary>
        private static string[] _phone = {"8(962)662-22-53", "8(906)223-41-77",
                                          "8(967)888-67-15", "8(902)456-78-91",
                                          "8(991)229-71-65", "8(997)654-25-13", "8(966)532-44-22"};

        /// <summary>
        /// Поле idVK
        /// </summary>
        private static string[] _idVk = {"@id123456", "@id654321",
                                         "@id112233", "@id858367",
                                         "@id115490", "@id514263", "@id222222" };


        /// <summary>
        /// Метод генерации случайного числа
        /// </summary>
        /// <param name="_randomNumber"></param>
        /// <param name="lengthOfArray"></param>
        /// <returns>
        /// Возвращает число
        /// </returns>
        private static int GenerateDigit(int lengthOfArray)
        {
            return _randomNumber.Next(lengthOfArray);
        }

        /// <summary>
        /// Метод генерации случаного контакта
        /// </summary>
        /// <param name="_randomNumber"></param>
        /// <param name="randomContacts"></param>
        public static List<Contact> GenerateRandomContactsName()
        {
            _project.Contacts.Clear();
            for (int i = 0; i < 10; i++)
            {
                _fullName[i] = _arrSurname[GenerateDigit(_arrSurname.Length)] + " " +
                    _arrName[GenerateDigit(_arrName.Length)] + " " +
                    _arrPatronymic[GenerateDigit(_arrPatronymic.Length)];
                    

            }

            for (int i = 0; i < 10; i++)
            {
                Contact contact = new Contact(_fullName[GenerateDigit(_fullName.Length)],
                _email[GenerateDigit(_email.Length)],
                    _phone[GenerateDigit(_phone.Length)], DateTime.Now.AddYears(-20),
                    _idVk[GenerateDigit(_idVk.Length)]);

                _project.Contacts.Add(contact);
            }
            return _project.Contacts;
        }
    }
}
