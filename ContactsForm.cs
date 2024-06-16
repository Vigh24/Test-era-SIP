using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SIPSample
{
    public partial class ContactsForm : Form
    {
        private List<Contact> contacts = new List<Contact>();
        private System.Windows.Forms.ListBox ListBoxContacts;
        private System.Windows.Forms.Button ButtonAddContact;
        private System.Windows.Forms.Button ButtonDeleteContact;

        public string SelectedContactNumber { get; private set; }

        public ContactsForm()
        {
            InitializeComponent();
            LoadContactsFromFile(); // Load contacts from file when initializing
            LoadContacts(); // Load contacts into the ListBox
        }

        private void LoadContacts()
        {
            // Example loading method
            ListBoxContacts.Items.Clear();
            foreach (var contact in contacts)
            {
                ListBoxContacts.Items.Add(contact);
            }
        }

        private void SaveContactsToFile()
        {
            using (var fs = new FileStream("contacts.bin", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, contacts);
            }
        }

        private void LoadContactsFromFile()
        {
            string filePath = "contacts.bin";
            if (File.Exists(filePath))
            {
                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    // Check if the file is not empty
                    if (fs.Length > 0)
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        contacts = (List<Contact>)formatter.Deserialize(fs);
                    }
                    else
                    {
                        // Optionally handle the case where the file is empty
                        // For example, initialize contacts as an empty list or display a message
                        contacts = new List<Contact>();
                    }
                }
            }
            else
            {
                // Handle the case where the file does not exist
                // For example, initialize contacts as an empty list or display a message
                contacts = new List<Contact>();
            }
        }

        private void ButtonAddContact_Click(object sender, EventArgs e)
        {
            string contactName = InputBox.Show("Enter contact name:", "Add Contact");
            if (string.IsNullOrEmpty(contactName)) return;

            string contactNumber = InputBox.Show("Enter contact number:", "Add Contact");
            if (string.IsNullOrEmpty(contactNumber)) return;

            var contact = new Contact { Name = contactName, Number = contactNumber };
            contacts.Add(contact);
            LoadContacts();
            SaveContactsToFile(); // Save contacts to file after adding
        }

        private void ButtonDeleteContact_Click(object sender, EventArgs e)
        {
            if (ListBoxContacts.SelectedItem is Contact selectedContact)
            {
                contacts.Remove(selectedContact);
                LoadContacts();
                SaveContactsToFile(); // Save contacts to file after deleting
            }
        }

        private void ListBoxContacts_DoubleClick(object sender, EventArgs e)
        {
            if (ListBoxContacts.SelectedItem is Contact selectedContact)
            {
                SelectedContactNumber = selectedContact.Number;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}