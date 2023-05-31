﻿using System;
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
        private List<Contact> listContact = new List<Contact>();

        /// <summary>
        /// Инициализация поля класса Project
        /// </summary>
        private Project _project = new Project();

        /// <summary>
        /// Создание объекта случайной генерации
        /// </summary>
        Random random = new Random();

        /// <summary>
        /// Метод по обновлению списка контактов
        /// </summary>
        private void UpdateListBox()
        {
            ContactsListBox.Items.Clear();
            foreach (Contact i in _project._contactsList)
            {
                ContactsListBox.Items.Add(i.FullName);
            }

        }

        /// <summary>
        /// Редактирования профайла контакта через второе окно
        /// </summary>
        /// <param name="index"></param>
        private void EditContact(int index)
        {
            var noteToEdit = (Contact)_project._contactsList[index].Clone();
            var editWindow = new ContactForm();
            editWindow.contact = noteToEdit;
            editWindow.ShowDialog();
            if (editWindow.DialogResult == DialogResult.OK)
            {
                var updatedContact = editWindow.contact;
                _project._contactsList[index] = editWindow.contact;
                _project._contactsList.RemoveAt(index);
                _project._contactsList.Insert(index, updatedContact);
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
                _project._contactsList.Add(updatedContact);
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
                _project._contactsList.RemoveAt(index);
            }
        }

        /// <summary>
        /// Отображение данных на форме
        /// </summary>
        /// <param name="index"></param>
        private void UpdateSelectedContact(int index)
        {
            Contact ContactValue = _project._contactsList[index];
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
        }
        private void AddContactButton_Click(object sender, EventArgs e)
        {
            AddContact();
            UpdateListBox();
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
            EditContact(ContactsListBox.SelectedIndex);
            UpdateListBox();
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
            UpdateListBox();
        }
    }
}
