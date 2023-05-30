using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp.Model;
namespace ContactsApp.View
{
    public partial class ContactForm : Form
    {
        private static readonly Color ErrorColor = Color.LightPink;
        private static readonly Color AnErrorColor = Color.White;
        /// <summary>
        /// Поле класса Contact
        /// </summary>
        private Contact _contact;

        /// <summary>
        /// Конструктор класса контакт
        /// </summary>
        public Contact contact
        {
            get { return _contact; }

            set
            {
                _contact = value;
                UpdateForm();
            }
        }

        /// <summary>
        /// Поле ошибки полного имени
        /// </summary>
        private string _fullNameError;

        /// <summary>
        /// Поле ошибки Email
        /// </summary>
        private string _emailError;

        /// <summary>
        /// Поле ошибки телефонного номера
        /// </summary>
        private string _phoneNumberError;

        /// <summary>
        /// Поле ошибки VK 
        /// </summary>
        private string _vkIdError;

        /// <summary>
        /// Поле ошибки дня рождения
        /// </summary>
        private string _dateOfBirthError;

        /// <summary>
        /// Инициализация данных
        /// </summary>
        public ContactForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод обновления данных в форме
        /// </summary>
        private void UpdateForm()
        {
            FullNameTextBox.Text = _contact.FullName;
            PhoneNumberTextBox.Text = _contact.PhoneNumber;
            EmailTextBox.Text = _contact.Email;
            DateOfBirthDateTimePicker.Value = _contact.DateOfBirth;
            VKTextBox.Text = _contact.VkId;
        }

        /// <summary>
        /// Метод проверки заполнения полей
        /// </summary>
        /// <returns></returns>
        private bool CheckFormOnErrors()
        {
            string[] fullError = { _fullNameError, _emailError, _phoneNumberError, _dateOfBirthError, _vkIdError };
            string errorText = null;
            foreach (string error in fullError)
                if (error != null)
                {
                    errorText += error + "\n";
                }
            if (errorText == null || errorText == "")
            {
                return true;
            }
            else
            {
                MessageBox.Show(errorText, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Метод по получению данных из заполненых полей
        /// </summary>
        private void UpdateContact()
        {
            _contact.FullName = FullNameTextBox.Text;
            _contact.PhoneNumber = PhoneNumberTextBox.Text;
            _contact.Email = EmailTextBox.Text;
            _contact.DateOfBirth = DateOfBirthDateTimePicker.Value;
            _contact.VkId = VKTextBox.Text;
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
            bool isSomeErrorsInForm = CheckFormOnErrors();
            if (isSomeErrorsInForm)
            {
                UpdateContact();
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _fullNameError = null;
                _contact.FullName = FullNameTextBox.Text;
                FullNameTextBox.BackColor = AnErrorColor;
            }
            catch (Exception exception)
            {
                _fullNameError = exception.Message;
                FullNameTextBox.BackColor = ErrorColor;

            }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _emailError = null;
                _contact.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = AnErrorColor;
            }
            catch (Exception exception)
            {
                _emailError = exception.Message;
                EmailTextBox.BackColor = ErrorColor;

            }
        }

        private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _phoneNumberError = null;
                _contact.PhoneNumber = PhoneNumberTextBox.Text;
                PhoneNumberTextBox.BackColor = AnErrorColor;
            }
            catch (Exception exception)
            {
                _phoneNumberError = exception.Message;
                PhoneNumberTextBox.BackColor = ErrorColor;

            }
        }

        private void VKTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _vkIdError = null;
                _contact.VkId = VKTextBox.Text;
                VKTextBox.BackColor = AnErrorColor;
            }
            catch (Exception exception)
            {
                _vkIdError = exception.Message;
                VKTextBox.BackColor = ErrorColor;
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
                throw new ArgumentException(_dateOfBirthError);
            }
        }
    }
}
