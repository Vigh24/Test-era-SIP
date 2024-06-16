namespace SIPSample
{
    partial class ContactsForm
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
            this.ListBoxContacts = new System.Windows.Forms.ListBox();
            this.ButtonAddContact = new System.Windows.Forms.Button();
            this.ButtonDeleteContact = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListBoxContacts
            // 
            this.ListBoxContacts.Location = new System.Drawing.Point(10, 10);
            this.ListBoxContacts.Name = "ListBoxContacts";
            this.ListBoxContacts.Size = new System.Drawing.Size(200, 290);
            this.ListBoxContacts.TabIndex = 0;
            this.ListBoxContacts.DoubleClick += new System.EventHandler(this.ListBoxContacts_DoubleClick);
            // 
            // ButtonAddContact
            // 
            this.ButtonAddContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonAddContact.Location = new System.Drawing.Point(220, 10);
            this.ButtonAddContact.Name = "ButtonAddContact";
            this.ButtonAddContact.Size = new System.Drawing.Size(75, 23);
            this.ButtonAddContact.TabIndex = 1;
            this.ButtonAddContact.Text = "Add";
            this.ButtonAddContact.UseVisualStyleBackColor = true;
            this.ButtonAddContact.Click += new System.EventHandler(this.ButtonAddContact_Click);
            // 
            // ButtonDeleteContact
            // 
            this.ButtonDeleteContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDeleteContact.Location = new System.Drawing.Point(220, 40);
            this.ButtonDeleteContact.Name = "ButtonDeleteContact";
            this.ButtonDeleteContact.Size = new System.Drawing.Size(75, 23);
            this.ButtonDeleteContact.TabIndex = 2;
            this.ButtonDeleteContact.Text = "Delete";
            this.ButtonDeleteContact.UseVisualStyleBackColor = true;
            this.ButtonDeleteContact.Click += new System.EventHandler(this.ButtonDeleteContact_Click);
            // 
            // ContactsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 320);
            this.Controls.Add(this.ButtonDeleteContact);
            this.Controls.Add(this.ButtonAddContact);
            this.Controls.Add(this.ListBoxContacts);
            this.Name = "ContactsForm";
            this.Text = "ContactsForm";
            this.ResumeLayout(false);

        }

        #endregion
    }
}