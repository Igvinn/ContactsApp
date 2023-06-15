using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
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
        /// <summary>
        /// Cписок с актуальными контактами после поиска
        /// </summary>
        private List<Contact> ContactsAfterSearch = new List<Contact>();

        /// <summary>
        /// Инициализация поля класса Project
        /// </summary>
        private Project _project = new Project();

        /// <summary>
        /// Список для хранения людей с днями рождения
        /// </summary>
        private List<Contact> ContactsBirthday = new List<Contact>();

        /// <summary>
        /// Метод по обновлению списка контактов
        /// </summary>
        private void UpdateListBox()
        {
            ContactsListBox.Items.Clear();
            _project.SortFullNameContacts();
            ContactsAfterSearch = _project.Сontacts;
            foreach (Contact i in _project.Сontacts)
            {
                ContactsListBox.Items.Add(i.FullName);
            }
            ContactsBirthday = _project.FindBirthdays();
            if (ContactsBirthday.Count >= 3)
            {
                BirthdaySurnamesLabel.Text = ContactsBirthday[0].FullName + ", "
                    + ContactsBirthday[1].FullName + ", "
                    + ContactsBirthday[2].FullName + " и др.";
            }
        }

        /// <summary>
        /// Редактирования профайла контакта через второе окно
        /// </summary>
        /// <param name="index"></param>
        private void EditContact(int index)
        {
            var editContact = (Contact)_project.Сontacts[index].Clone();
            var form = new ContactForm();
            form.contact = editContact;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                var updatedContact = form.contact;
                _project.Сontacts[index] = form.contact;
                _project.Сontacts.RemoveAt(index);
                _project.Сontacts.Insert(index, updatedContact);
            }
        }

        /// <summary>
        /// Генерация случайных чисел
        /// </summary>
        private void AddContact()
        {
            var form = new ContactForm();
            form.ShowDialog();
            var updatedContact = form.contact;
            if (form.DialogResult == DialogResult.OK)
            {
                _project.Сontacts.Add(updatedContact);
            }    
        }

        /// <summary>
        /// Удаление контакта
        /// </summary>
        /// <param name="index"></param>
        private void RemoveContact(int index)
        {
            if (index == -1) return;

            DialogResult result = MessageBox.Show(
            $"Do you really want to remove contact number: {ContactsListBox.SelectedIndex + 1}",
            "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                _project.Сontacts.RemoveAt(index);
            }
        }

        /// <summary>
        /// Отображение данных на форме
        /// </summary>
        /// <param name="index"></param>
        private void UpdateSelectedContact(int index)
        {
            Contact ContactValue = _project.Сontacts[index];
            FullNameTextBox.Text = ContactValue.FullName;
            EmailTextBox.Text = ContactValue.Email;
            PhoneNumberTextBox.Text = ContactValue.PhoneNumber;
            DateOfBirthTextBox.Text = ContactValue.DateOfBirth.ToString();
            VKTextBox.Text = ContactValue.VkId;
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
            _project = ProjectSerializer.LoadFromFile();
            UpdateListBox();
        }

        private void AddContactButton_Click(object sender, EventArgs e)
        {
            AddContact();
            ProjectSerializer.SaveToFile(_project);
            UpdateListBox();
        }

        private void RemoveContactButton_Click(object sender, EventArgs e)
        {
            RemoveContact(ContactsListBox.SelectedIndex);
            ProjectSerializer.SaveToFile(_project);
            UpdateListBox();
        }

        private void EditContactButton_Click(object sender, EventArgs e)
        {
           var index = ContactsListBox.SelectedIndex;
            if (index != -1)
            {
                EditContact(index);
                ProjectSerializer.SaveToFile(_project);
                UpdateSelectedContact(index);
                UpdateListBox();
            }
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

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            string Text = FindTextBox.Text;
            ContactsAfterSearch = _project.FindContacts(_project.Сontacts, Text);
            ContactsListBox.Items.Clear();
            foreach (Contact contact in ContactsAfterSearch)
            {
                ContactsListBox.Items.Add(contact.FullName);
                
            }
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
    }
}
