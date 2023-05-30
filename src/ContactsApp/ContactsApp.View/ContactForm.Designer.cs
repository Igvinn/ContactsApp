namespace ContactsApp.View
{
    partial class ContactForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VKTextBox = new System.Windows.Forms.TextBox();
            this.VKLabel = new System.Windows.Forms.Label();
            this.DateOfBirthLabel = new System.Windows.Forms.Label();
            this.PhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.PhoneNumberLabel = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.FullNameTextBox = new System.Windows.Forms.TextBox();
            this.FullNameLabel = new System.Windows.Forms.Label();
            this.PhotoPictureBox = new System.Windows.Forms.PictureBox();
            this.ButtonPanelBackground = new System.Windows.Forms.Panel();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.DateOfBirthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AddPhotoButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoPictureBox)).BeginInit();
            this.ButtonPanelBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddPhotoButton)).BeginInit();
            this.SuspendLayout();
            // 
            // VKTextBox
            // 
            this.VKTextBox.Location = new System.Drawing.Point(118, 239);
            this.VKTextBox.Name = "VKTextBox";
            this.VKTextBox.Size = new System.Drawing.Size(175, 20);
            this.VKTextBox.TabIndex = 21;
            this.VKTextBox.TextChanged += new System.EventHandler(this.VKTextBox_TextChanged);
            // 
            // VKLabel
            // 
            this.VKLabel.AutoSize = true;
            this.VKLabel.Location = new System.Drawing.Point(118, 223);
            this.VKLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.VKLabel.Name = "VKLabel";
            this.VKLabel.Size = new System.Drawing.Size(24, 13);
            this.VKLabel.TabIndex = 20;
            this.VKLabel.Text = "VK:";
            // 
            // DateOfBirthLabel
            // 
            this.DateOfBirthLabel.AutoSize = true;
            this.DateOfBirthLabel.Location = new System.Drawing.Point(118, 174);
            this.DateOfBirthLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.DateOfBirthLabel.Name = "DateOfBirthLabel";
            this.DateOfBirthLabel.Size = new System.Drawing.Size(69, 13);
            this.DateOfBirthLabel.TabIndex = 18;
            this.DateOfBirthLabel.Text = "Date of Birth:";
            // 
            // PhoneNumberTextBox
            // 
            this.PhoneNumberTextBox.Location = new System.Drawing.Point(118, 141);
            this.PhoneNumberTextBox.Name = "PhoneNumberTextBox";
            this.PhoneNumberTextBox.Size = new System.Drawing.Size(175, 20);
            this.PhoneNumberTextBox.TabIndex = 17;
            this.PhoneNumberTextBox.Text = "+7 (999) 111-22-33";
            this.PhoneNumberTextBox.TextChanged += new System.EventHandler(this.PhoneNumberTextBox_TextChanged);
            // 
            // PhoneNumberLabel
            // 
            this.PhoneNumberLabel.AutoSize = true;
            this.PhoneNumberLabel.Location = new System.Drawing.Point(118, 125);
            this.PhoneNumberLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.PhoneNumberLabel.Name = "PhoneNumberLabel";
            this.PhoneNumberLabel.Size = new System.Drawing.Size(78, 13);
            this.PhoneNumberLabel.TabIndex = 16;
            this.PhoneNumberLabel.Text = "PhoneNumber:";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmailTextBox.Location = new System.Drawing.Point(118, 92);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(384, 20);
            this.EmailTextBox.TabIndex = 15;
            this.EmailTextBox.Text = "abakumov@no.mail";
            this.EmailTextBox.TextChanged += new System.EventHandler(this.EmailTextBox_TextChanged);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(118, 76);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(41, 13);
            this.EmailLabel.TabIndex = 14;
            this.EmailLabel.Text = "E- mail:";
            // 
            // FullNameTextBox
            // 
            this.FullNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FullNameTextBox.Location = new System.Drawing.Point(118, 43);
            this.FullNameTextBox.Name = "FullNameTextBox";
            this.FullNameTextBox.Size = new System.Drawing.Size(384, 20);
            this.FullNameTextBox.TabIndex = 13;
            this.FullNameTextBox.Text = "Абакумов Дмитрий Николаевич";
            this.FullNameTextBox.TextChanged += new System.EventHandler(this.FullNameTextBox_TextChanged);
            // 
            // FullNameLabel
            // 
            this.FullNameLabel.AutoSize = true;
            this.FullNameLabel.Location = new System.Drawing.Point(118, 27);
            this.FullNameLabel.Name = "FullNameLabel";
            this.FullNameLabel.Size = new System.Drawing.Size(57, 13);
            this.FullNameLabel.TabIndex = 12;
            this.FullNameLabel.Text = "Full Name:";
            // 
            // PhotoPictureBox
            // 
            this.PhotoPictureBox.Image = global::ContactsApp.View.Properties.Resources.photo_placeholder_100x100;
            this.PhotoPictureBox.Location = new System.Drawing.Point(12, 12);
            this.PhotoPictureBox.Name = "PhotoPictureBox";
            this.PhotoPictureBox.Size = new System.Drawing.Size(100, 100);
            this.PhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PhotoPictureBox.TabIndex = 11;
            this.PhotoPictureBox.TabStop = false;
            // 
            // ButtonPanelBackground
            // 
            this.ButtonPanelBackground.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonPanelBackground.Controls.Add(this.OKButton);
            this.ButtonPanelBackground.Controls.Add(this.CancelButton);
            this.ButtonPanelBackground.Location = new System.Drawing.Point(0, 278);
            this.ButtonPanelBackground.Name = "ButtonPanelBackground";
            this.ButtonPanelBackground.Size = new System.Drawing.Size(516, 33);
            this.ButtonPanelBackground.TabIndex = 22;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(346, 7);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(427, 7);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // DateOfBirthDateTimePicker
            // 
            this.DateOfBirthDateTimePicker.Location = new System.Drawing.Point(118, 190);
            this.DateOfBirthDateTimePicker.Name = "DateOfBirthDateTimePicker";
            this.DateOfBirthDateTimePicker.Size = new System.Drawing.Size(175, 20);
            this.DateOfBirthDateTimePicker.TabIndex = 23;
            this.DateOfBirthDateTimePicker.ValueChanged += new System.EventHandler(this.DateOfBirthDateTimePicker_ValueChanged);
            // 
            // AddPhotoButton
            // 
            this.AddPhotoButton.Image = global::ContactsApp.View.Properties.Resources.add_photo_32x32_gray;
            this.AddPhotoButton.Location = new System.Drawing.Point(45, 118);
            this.AddPhotoButton.Name = "AddPhotoButton";
            this.AddPhotoButton.Size = new System.Drawing.Size(32, 32);
            this.AddPhotoButton.TabIndex = 24;
            this.AddPhotoButton.TabStop = false;
            this.AddPhotoButton.MouseEnter += new System.EventHandler(this.AddPhotoButton_MouseEnter);
            this.AddPhotoButton.MouseLeave += new System.EventHandler(this.AddPhotoButton_MouseLeave);
            // 
            // ContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(514, 311);
            this.Controls.Add(this.AddPhotoButton);
            this.Controls.Add(this.DateOfBirthDateTimePicker);
            this.Controls.Add(this.ButtonPanelBackground);
            this.Controls.Add(this.VKTextBox);
            this.Controls.Add(this.VKLabel);
            this.Controls.Add(this.DateOfBirthLabel);
            this.Controls.Add(this.PhoneNumberTextBox);
            this.Controls.Add(this.PhoneNumberLabel);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.FullNameTextBox);
            this.Controls.Add(this.FullNameLabel);
            this.Controls.Add(this.PhotoPictureBox);
            this.MaximumSize = new System.Drawing.Size(530, 350);
            this.MinimumSize = new System.Drawing.Size(530, 350);
            this.Name = "ContactForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.ContactForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PhotoPictureBox)).EndInit();
            this.ButtonPanelBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddPhotoButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox VKTextBox;
        private System.Windows.Forms.Label VKLabel;
        private System.Windows.Forms.Label DateOfBirthLabel;
        private System.Windows.Forms.TextBox PhoneNumberTextBox;
        private System.Windows.Forms.Label PhoneNumberLabel;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox FullNameTextBox;
        private System.Windows.Forms.Label FullNameLabel;
        private System.Windows.Forms.PictureBox PhotoPictureBox;
        private System.Windows.Forms.Panel ButtonPanelBackground;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.DateTimePicker DateOfBirthDateTimePicker;
        private System.Windows.Forms.PictureBox AddPhotoButton;
    }
}