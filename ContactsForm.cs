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
using ComponentFactory.Krypton.Toolkit;
using System.Runtime.Serialization;

namespace EratronicsPhone
{
    public partial class ContactsForm : KryptonForm
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
                formatter.Serialize(fs, contacts); // Ensure contacts is a List<Contact>
            }
        }

        private void LoadContactsFromFile()
        {
            string filePath = "contacts.bin";
            if (File.Exists(filePath))
            {
                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Binder = new NamespaceChangeBinder(); // Use the custom binder
                    try
                    {
                        contacts = (List<Contact>)formatter.Deserialize(fs); // Ensure this is a List<Contact>
                    }
                    catch (InvalidCastException e)
                    {
                        MessageBox.Show("The data format is incorrect: " + e.Message);
                        contacts = new List<Contact>(); // Default to an empty list if there's an error
                    }
                }
            }
            else
            {
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

        private void kryptonPalette1_PalettePaint(object sender, ComponentFactory.Krypton.Toolkit.PaletteLayoutEventArgs e)
        {

        }
    }

    // Custom serialization binder
    public class NamespaceChangeBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            // Check if the type is an array
            if (typeName.Contains("[]"))
            {
                // Handle array types specifically
                typeName = typeName.Replace("[]", "");
                Type elementType = BindToBaseType(typeName, assemblyName);
                return elementType != null ? elementType.MakeArrayType() : null;
            }
            else
            {
                return BindToBaseType(typeName, assemblyName);
            }
        }

        private Type BindToBaseType(string typeName, string assemblyName)
        {
            if (typeName.Contains("SIPSample.Contact"))
            {
                return typeof(EratronicsPhone.Contact); // Redirect to the current Contact class
            }
            return Type.GetType($"{typeName}, {assemblyName}");
        }
    }
}