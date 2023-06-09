using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ContactsApp.Model;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;

namespace ContactApp.UnitTests
{
    [TestFixture]
    class ProjectsTest
    {
        /// <summary>
        /// Тест сортировки списка контактов без значений
        /// </summary>
        /// <param name="message"></param>
        [TestCase("Список контактов не отсортирован, так как список пустой",
            TestName = "Тест сортировки списка контактов без значений")]
        public void Project_SortContactsListWithoutContacts_ReturnsValue(string message)
        {
            // Arrange
            var expected = new Project();
            expected.Сontacts = new List<Contact>();
            var project = new Project();
            project.Сontacts = new List<Contact>();

            // Act
            var actual = new Project();
            project.SortFullNameContacts();
            actual = project;

            // Assert
            Assert.That(actual.Сontacts, Is.EqualTo(expected.Сontacts), message);
        }

        /// <summary>
        /// Тест сортировки списка имеющего контакты
        /// </summary>
        /// <param name="message"></param>
        [TestCase("Список контактов не отсортирован",
            TestName = "Тест сортировки списка имеющего контакты")]
        public void Project_SortContactsList_ReturnsValue(string message)
        {
            // Arrange  
            var expected = new Project();
            expected.Сontacts = new List<Contact>()
            {
                new Contact(
                    "Виктор Иванович","Vick@mail.ru","+5(555)5555555",DateTime.Today,"@Виктор Иванович"),
                new Contact(
                    "Иван Викторович","Ivan@mail.ru","+7(777)7777777",DateTime.Today,"@Иван Викторович"),
                new Contact(
                    "Петр Максимович","Petr@mail.ru","+6(666)6666666",DateTime.Today,"@Петр Максимович")

            };
            var project = new Project();
            project.Сontacts = new List<Contact>()
            {
                new Contact(
                    "Иван Викторович","Ivan@mail.ru","+7(777)7777777",DateTime.Today,"@Иван Викторович"),
                new Contact(
                    "Виктор Иванович","Vick@mail.ru","+5(555)5555555",DateTime.Today,"@Виктор Иванович"),
                new Contact(
                    "Петр Максимович","Petr@mail.ru","+6(666)6666666",DateTime.Today,"@Петр Максимович")
            };

            // Act
            var actual = new Project();
            project.SortFullNameContacts();
            actual = project;

            // Assert
            Assert.That(actual.Сontacts[1].FullName, Is.EqualTo(expected.Сontacts[1].FullName), message);
        }

        /// <summary>
        /// Тест сортировки отсортированного списка контактов
        /// </summary>
        /// <param name="message"></param>
        [TestCase("Отсортированный список контактов не отсортирован",
            TestName = "Тест сортировки отсортированного списка контактов")]
        public void Project_SortSortedContactsList_ReturnsValue(string message)
        {
            // Arrange
            var expected = new Project();
            expected.Сontacts = new List<Contact>()
            {
                new Contact(
                   "Иван Викторович","Ivan@mail.ru","+7(777)7777777",DateTime.Today,"@Иван"),
                new Contact(
                    "Петр Максимович","Petr@mail.ru","+6(666)6666666",DateTime.Today,"@Петр"),
                new Contact(
                    "Виктор Иванович","Vick@mail.ru","+55555555555",DateTime.Today,"@Виктор")
            };
            var project = new Project();
            project.Сontacts = new List<Contact>()
            {
                new Contact(
                    "Петр Максимович","Petr@mail.ru","+6(666)6666666",DateTime.Today,"@Петр"),
                new Contact(
                    "Иван Викторович","Ivan@mail.ru","+7(777)7777777",DateTime.Today,"@Иван"),
                new Contact(
                    "Виктор Иванович","Vick@mail.ru","+55555555555",DateTime.Today,"@Виктор")
            };

            // Act
            var actual = new Project();
            project.SortFullNameContacts();
            actual = project;

            // Assert
            Assert.That(actual.Сontacts[1].FullName, Is.EqualTo(expected.Сontacts[0].FullName), message);
        }

        [TestCase("", "Контакты не найдены",
           TestName = "Тест поиска контактов в пустом списке с пустым искомым контактом")]
        public void Project_SearchContactsInEmptyListWithoutSubstringValue_ReturnsValue
           (string searchedValue, string message)
        {
            // Arrange
            var expected = new Project();
            expected.Сontacts = new List<Contact>();
            var project = new Project();
            project.Сontacts = new List<Contact>();

            // Act
            var actual = new Project();
            actual.Сontacts = project.FindContacts(project.Сontacts, searchedValue);

            // Assert
            Assert.That(actual.Сontacts, Is.EqualTo(expected.Сontacts), message);
        }

        [TestCase("Саят", "Контакты не найдены",
           TestName = "Тест поиска контактов в пустом списке с искомым значением")]
        public void Project_SearchContactsInEmptyListWithSubstingValue_ReturnsValue
           (string searchedValue, string message)
        {
            // Arrange
            var expected = new Project();
            expected.Сontacts = new List<Contact>();
            var project = new Project();
            project.Сontacts = new List<Contact>();

            // Act
            var actual = new Project();
            actual.Сontacts = project.FindContacts(project.Сontacts, searchedValue);

            // Assert
            Assert.That(actual.Сontacts, Is.EqualTo(expected.Сontacts), message);
        }

        [TestCase("", "Контакты не найдены",
        TestName = "Тест поиска контактов в полном списке с пустым искомым значением")]
        public void Project_SearchContactsWithoutSubstringValue_ReturnsValue
            (string searchedValue, string message)
        {
            // Arrange
            var expected = new Project();
            expected.Сontacts = new List<Contact>()
            {
                new Contact(
                    "Иван Викторович","Ivan@mail.ru","+7(777)7777777",DateTime.Today,"@Иван"),
                new Contact(
                    "Петр Максимович","Petr@mail.ru","+6(666)6666666",DateTime.Today,"@Петр"),
                new Contact(
                    "Виктор Иванович","Vick@mail.ru","+55555555555",DateTime.Today,"@Виктор")         
            };
            var project = new Project();
            project.Сontacts = new List<Contact>()
            {
                  new Contact(
                    "Иван Викторович","Ivan@mail.ru","+7(777)7777777",DateTime.Today,"@Иван"),
                new Contact(
                    "Петр Максимович","Petr@mail.ru","+6(666)6666666",DateTime.Today,"@Петр"),
                new Contact(
                    "Виктор Иванович","Vick@mail.ru","+55555555555",DateTime.Today,"@Виктор")
            };

            // Act
            var actual = new Project();
            actual.Сontacts = project.FindContacts(project.Сontacts, searchedValue);

            // Assert
            Assert.That(actual.Сontacts[0].FullName, Is.EqualTo(expected.Сontacts[0].FullName), message);
        }

        [TestCase("Кто-то", "Контакты не найдены",
           TestName = "Тест поиска контактов на отсутсвие контакта в полном списке")]
        public void Project_SearchContactsWithoutNeededContact_ReturnsValue
           (string searchedValue, string message)
        {
            // Arrange
            var expected = new Project();
            expected.Сontacts = new List<Contact>();
            var project = new Project();
            project.Сontacts = new List<Contact>()
            {
                new Contact(
                    "Иван Викторович","Ivan@mail.ru","+7(777)7777777",DateTime.Today,"@Иван"),
                new Contact(
                    "Петр Максимович","Petr@mail.ru","+6(666)6666666",DateTime.Today,"@Петр"),
                new Contact(
                    "Виктор Иванович","Vick@mail.ru","+55555555555",DateTime.Today,"@Виктор")
            };

            // Act
            var actual = new Project();
            actual.Сontacts = project.FindContacts(project.Сontacts, searchedValue);

            // Assert
            Assert.That(actual.Сontacts, Is.EqualTo(expected.Сontacts), message);
        }
    }
}