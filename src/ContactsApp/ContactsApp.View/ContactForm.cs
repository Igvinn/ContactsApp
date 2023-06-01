using ContactsApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsApp.View
{
    public partial class ContactForm : Form
    {
        /// <summary>
        /// Поле класса Contact
        /// </summary>
        private Contact _contact = new Contact();

        /// <summary>
        /// Поле строковой ошибки при введении полного имени
        /// </summary>
        private string _fullNameError;

        /// <summary>
        /// Поле строковой ошибки при введении почты
        /// </summary>
        private string _emailError;

        /// <summary>
        /// Поле строковой ошибки при введении мобильного телефона
        /// </summary>
        private string _phoneNumberError;

        /// <summary>
        /// Поле строковой ошибки при введении даты рождения
        /// </summary>
        private string _dateOfBirthError;

        /// <summary>
        /// Поле ошибок формы
        /// </summary>
        private string _validationError;

        /// <summary>
        /// Поле строковой ошибки при введении ссылки на вк
        /// </summary>
        private string _vKError;

        /// <summary>
        /// Светлорозовый цвет
        /// </summary>
        private Color _errorColor = Color.LightPink;

        /// <summary>
        /// Белый цвет
        /// </summary>
        private Color _correctColor = Color.White;

        /// <summary>
        /// Заполнение данных экземпляра
        /// </summary>
        public Contact contact
        {
            get { return _contact; }

            set { _contact = value; }
        }



        public ContactForm()
        {
            _contact = new Contact();
            InitializeComponent();
            _contact.PhoneNumber = "8 800 000 00 00";
            _contact.DateOfBirth = DateTime.Now;
            UpdateForm();


        }

        /// <summary>
        /// Заполнение элементов данными контакта
        /// </summary>
        private void UpdateForm()
        {
            FullNameTextBox.Text = _contact.FullName;
            EmailTextBox.Text = _contact.Email;
            PhoneNumberTextBox.Text = _contact.PhoneNumber;
            DateOfBirthDateTimePicker.Value = _contact.DateOfBirth;
            VKTextBox.Text = _contact.VkId;
        }

        /// <summary>
        /// Проверка на валидацию
        /// </summary>
        /// <returns></returns>
        private bool CheckFormOnErrors()
        {
            _validationError += _fullNameError;
            _validationError += _emailError;
            _validationError += _phoneNumberError;
            _validationError += _dateOfBirthError;
            _validationError += _vKError;

            if (_validationError != "")
            {
                MessageBox.Show($"{_fullNameError}\n{_emailError}\n{_phoneNumberError}" +
                    $"\n{_dateOfBirthError}\n{_vKError}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;

        }
        /// <summary>
        /// Заполнение данных в экземпляр 
        /// </summary>
        private void UpdateContact()
        {
            DialogResult = DialogResult.OK;
            contact.FullName = FullNameTextBox.Text;
            contact.PhoneNumber = PhoneNumberTextBox.Text;
            contact.Email = EmailTextBox.Text;
            contact.DateOfBirth = DateOfBirthDateTimePicker.Value;
            contact.VkId = VKTextBox.Text;

        }


        private void AddPhotoButton_MouseEnter(object sender, EventArgs e)
        {
            AddPhotoButton.Image = Properties.Resources.add_photo_32x32;
            AddPhotoButton.BackColor = ColorTranslator.FromHtml("#F5F5FF");
        }

        private void AddPhotoButton_MouseLeave(object sender, EventArgs e)
        {
            AddPhotoButton.Image = Properties.Resources.add_photo_32x32_gray;
            AddPhotoButton.BackColor = Color.White;
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            CheckFormOnErrors();
            UpdateContact();
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _fullNameError = null;
                _contact.FullName = FullNameTextBox.Text;
                FullNameTextBox.BackColor = Color.White;
            }
            catch (Exception exception)
            {
                _fullNameError = exception.Message;
                FullNameTextBox.BackColor = Color.LightPink;
            }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _emailError = null;
                _contact.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = Color.White;
            }
            catch (Exception exception)
            {
                _emailError = exception.Message;
                EmailTextBox.BackColor = Color.LightPink;
            }
        }

        private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _phoneNumberError = null;
                _contact.PhoneNumber = PhoneNumberTextBox.Text;
                PhoneNumberTextBox.BackColor = Color.White;
            }
            catch (Exception exception)
            {
                _phoneNumberError = exception.Message;
                PhoneNumberTextBox.BackColor = Color.LightPink;
            }
        }

        private void VKTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _vKError = null;
                _contact.VkId = VKTextBox.Text;
                VKTextBox.BackColor = Color.White;
            }
            catch (Exception exception)
            {
                _vKError = exception.Message;
                VKTextBox.BackColor = Color.LightPink;
            }
        }

        private void DateOfBirthDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _dateOfBirthError = null;
                _contact.DateOfBirth = DateOfBirthDateTimePicker.Value;
            }
            catch (Exception exception)
            {
                _dateOfBirthError = exception.Message;
            }
        }
    }
}
