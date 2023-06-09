using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ContactsApp.Model;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactsTest
    {
        /// <summary>
        /// Тест на присвоение полному имени боле 100 симвлов
        /// </summary>
        /// <param name="wrongFullName"></param>
        /// <param name="message"></param>
        [TestCase("больше100символовбольше100символобольше100символов" +
            "больше100символовбольше100символовбольше100символовбольше100символовбольше100символов",
         "Исключение в случае присвоения более 100 символов в строку FullName",
         TestName = "Тест на присвоение полному имени боле 100 симвлов")]
        public void FullNameSet_ArgumentException(string wrongFullName, string message)
        {
            // Arrange
            var contact = new Contact();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                // Act
                contact.FullName = wrongFullName;
            },
                message);
        }

        /// <summary>
        /// Тесты на запись в поле имя разнозрегистровых символов 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expected"></param>
        [TestCase("носоченко игорь", "Носоченко Игорь",
            TestName = "Тест на присвоение корректного имени начинающегося с нижнего регистра")]
        [TestCase("НОСОЧЕНКО ИГОРЬ", "Носоченко Игорь",
            TestName = "Тест на присвоение корректного имени записанного верхним регистром")]
        [TestCase("НоСоЧеНкО иГоРь", "Носоченко Игорь",
            TestName = "Тест на присвоение корректного имени записанного разнорегистровыми символами")]
        public void FullNameSet_CorrectValue(string input, string expected)
        {
            // Arrange
            var contact = new Contact();

            // Act
            contact.FullName = input;

            // Assert
            var actual = contact.FullName;
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Тесты на запись в поле Email корректных данных
        /// </summary>
        /// <param name="expected"></param>
        [TestCase("igvin26rus@mail.ru",
            TestName = "Тест на присвоение корректно записанного email")]
        [TestCase("igvin.26.rus@mail.ru",
            TestName = "Тест на присвоение другого корректно записанного email")]
        public void EmailSet_CorrectValue(string expected)
        {
            // Arrange
            var contact = new Contact();

            // Assert
            contact.Email = expected;

            // Act
            var actual = contact.Email;
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Тест на присвоение Email боле 100 симвлов
        /// </summary>
        /// <param name="wrongEmail"></param>
        /// <param name="message"></param>
        [TestCase("igvin.26.rus@mail.ruigvin.26.rus@mail.ruigvin.26.rus@mail.ruigvin.26.rus@mail.ru" +
            "igvin.26.rus@mail.ruigvin.26.rus@mail.ruigvin.26.rus@mail.ruigvin.26.rus@mail.ru",
         "Исключение в случае присвоения более 100 символов в строку Email",
         TestName = "Тест на присвоение Email боле 100 симвлов")]
        public void EmailSet_ThrowsArgumentException(string wrongEmail, string message)
        {
            // Arrange
            var contact = new Contact();

            //Asser
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                //Assert
                contact.Email = wrongEmail;
            },
                message);
        }

        /// <summary>
        /// Тесты на присвоение корректного номера телефона
        /// </summary>
        /// <param name="expected"></param>
        [TestCase("8(800)0000000",
            TestName = "Тест на присвоение корректного номера телефона")]
        [TestCase("+7(700)0000000",
            TestName = "Тест на присвоение корректного номера телефона")]
        public void PhoneSet_CorrectValue(string expected)
        {
            // Arrange
            var contact = new Contact();

            //Act
            contact.PhoneNumber = expected;

            //Assert
            var actual = contact.PhoneNumber;
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Тесты на присвоение корректных данных в поле дата рождения
        /// </summary>
        /// <param name="expectedDateString"></param>
        [TestCase("2001/12/02", TestName = "Тест на присвоение правильной даты рождения")]
        [TestCase("1995/05/19", TestName = "Тест на присвоение другой правильной даты рождения")]
        public void DateOfBirthSet_CorrectValue(string expectedDateString)
        {
            //Arrange
            DateTime expected = DateTime.Parse(expectedDateString);

            //Act
            var contact = new Contact();
            contact.DateOfBirth = expected;

            //Assert
            var actual = contact.DateOfBirth;
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Тесты на рисвоение некорректных данных в поле дата рождения
        /// </summary>
        /// <param name="wrongDateString"></param>
        [TestCase("1899/05/01", TestName = "Тест на присвоение некорректной даты рождения, <1900")]
        [TestCase("2525/06/05", TestName = "Тест на присвоение некорректной даты рождения, больше текущей")]
        public void DateOfBirthSet_ThrowsArgumentException(string wrongDateString)
        {
            //Arrange
            DateTime wrongDate = DateTime.Parse(wrongDateString);

            //Assert
            var contact = new Contact();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                //Act
                contact.DateOfBirth = wrongDate;
            });
        }

        /// <summary>
        /// Тест на присвоение корректного VkID 
        /// </summary>
        /// <param name="expected"></param>
        [TestCase("testIdVk", TestName = "Тест на присвоение корректного VkID")]
        public void IdVkSet_CorrectValue(string expected)
        {
            //Arrange
            var contact = new Contact();

            //Act
            contact.VkId = expected;

            //Asserrt
            var actual = contact.VkId;
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Тест на присвоение некорректного VkID в поле
        /// </summary>
        /// <param name="wrongIdVk"></param>
        [TestCase("WrongVKIDWrongVKIDWrongVKIDWrongVKIDWrongVKIDWrongVKIDWrongVKIDWrongVKID" +
            "WrongVKIDWrongVKIDWrongVKIDWrongVKIDWrongVKIDWrongVKIDWrongVKIDWrongVKID",
            TestName = "Тест на присвоение некорректного значения VkID, более 50 символов")]
        public void IdVkSet_ThrowsArgumentException(string wrongIdVk)
        {
            //Arrange
            var contact = new Contact();

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                //Act
                contact.VkId = wrongIdVk;
            });
        }
    }
}