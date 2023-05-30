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
    public partial class MainForm : Form
    {
        //Random randomValue;
        /// <summary>
        /// Инициализация поля класса Project
        /// </summary>
        private Project _project = new Project();

        /// <summary>
        /// Метод по обновлению списка контактов
        /// </summary>
        private void UpdateListBox()
        {
            ContactsListBox.Items.Clear();
            foreach (Contact contact in _project.Contacts)
            {
                ContactsListBox.Items.Add(contact.FullName);
            }
        }

        /// <summary>
        /// Создание объекта для генерации чисел 
        /// </summary>
        private Random _rand = new Random();

        /// <summary>
        /// Генерация случайных чисел
        /// </summary>
        private void AddContact()
        {
            _project.Contacts.AddRange(RandomContacts.GenerateRandomContactsName());
            Contact contact = new Contact("", "", "8 900 000 00 00", DateTime.Now.AddYears(-20), "");
            var contactForm = new ContactForm();
            contactForm.contact = contact;
            contactForm.ShowDialog();
            var updatedContact = contactForm.contact;
            _project.Contacts.Add(updatedContact);
        }

        /// <summary>
        /// Удаление контакта
        /// </summary>
        private void RemoveContact(int index)
        {
            if (index == -1)
            {
                return;
            }
            DialogResult result = MessageBox.Show(
               $"Do you really want to remove {_project.Contacts[index].FullName}?",
               "Delete contact",
               MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question);
            if (result == DialogResult.OK)

            {
                _project.Contacts.RemoveAt(index);
            }
        }

        /// <summary>
        /// Отображение данных на форме
        /// </summary>
        /// <param name="index"></param>
        private void UpdateSelectedContact(int index)
        {
            FullNameTextBox.Text = _project.Contacts[index].FullName;
            EmailTextBox.Text = _project.Contacts[index].Email;
            PhoneNumberTextBox.Text = _project.Contacts[index].PhoneNumber;
            DateOfBirthTextBox.Text = _project.Contacts[index].DateOfBirth.ToString();
            VKTextBox.Text = _project.Contacts[index].VkId;
        }

        /// <summary>
        /// Очистка данных на форме
        /// </summary>
        private void ClearSelectedContact()
        {
            FullNameTextBox.Text = null;
            EmailTextBox.Text = null;
            PhoneNumberTextBox.Text = null;
            DateOfBirthTextBox.Text = null;
            VKTextBox.Text = null;
        }

        public MainForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void AddContactButton_Click(object sender, EventArgs e)
        {
            AddContact();
            UpdateListBox();
            var form = new ContactForm();
            form.ShowDialog();
        }

        private void AddContactButton_MouseEnter(object sender, EventArgs e)
        {
            AddContactButton.Image = Properties.Resources.add_contact_32x32;
            AddContactButton.BackColor = ColorTranslator.FromHtml("#F5F5FF");
        }

        private void AddContactButton_MouseLeave(object sender, EventArgs e)
        {
            AddContactButton.Image = Properties.Resources.add_contact_32x32_gray;
            AddContactButton.BackColor = Color.White;
        }

        private void RemoveContactButton_MouseEnter(object sender, EventArgs e)
        {
            RemoveContactButton.Image = Properties.Resources.remove_contact_32x32;
            RemoveContactButton.BackColor = ColorTranslator.FromHtml("#FAF5F5");
        }

        private void RemoveContactButton_MouseLeave(object sender, EventArgs e)
        {
            RemoveContactButton.Image = Properties.Resources.remove_contact_32x32_gray;
            RemoveContactButton.BackColor = Color.White;
        }

        private void EditContactButton_MouseEnter(object sender, EventArgs e)
        {
            EditContactButton.Image = Properties.Resources.edit_contact_32x32;
            EditContactButton.BackColor = ColorTranslator.FromHtml("#F5F5FF");
        }

        private void EditContactButton_MouseLeave(object sender, EventArgs e)
        {
            EditContactButton.Image = Properties.Resources.edit_contact_32x32_gray;
            EditContactButton.BackColor = Color.White;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Click(object sender, EventArgs e)
        {

        }

        private void FullNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BirthdayPanelCloseButton_Click(object sender, EventArgs e)
        {
            BirthdayPanel.Visible = false;
        }


        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {

                var form = new AboutForm();
                form.ShowDialog();


            }
        }

        private void RemoveContactButton_Click(object sender, EventArgs e)
        {
            RemoveContact(ContactsListBox.SelectedIndex);
            UpdateListBox();
        }

        private void EditContactButton_Click(object sender, EventArgs e)
        {
            var form = new ContactForm();
            form.ShowDialog();
        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactsListBox.SelectedIndex == -1)
            {
                ClearSelectedContact();
            }
            else UpdateSelectedContact(ContactsListBox.SelectedIndex);
        }

        private void MainForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                          "Do you really want to exit?",
                          "Exit",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
