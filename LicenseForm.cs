using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace SIPSample
{
    public partial class LicenseForm : Form
    {
        public bool IsActivated { get; private set; } = false; // Public property to track if the license is activated
        public bool IsTrialStarted { get; private set; } = false; // Public property to track if the trial is started

        private string generatedKey; // Field to store the generated key

        public LicenseForm()
        {
            InitializeComponent();
        }

        private void btnTrial_Click(object sender, EventArgs e)
        {
            // Start or continue a 30-day trial
            StartTrial();
            IsTrialStarted = true; // Set the trial started flag
            this.Close();
        }

        private void StartTrial()
        {
            // Save the trial start date in the registry
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SIPSample");
            key.SetValue("TrialStartDate", DateTime.Now.ToString());
            key.Close();
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            // Check the license key
            string inputKey = txtLicenseKey.Text;
            string decryptedKey = inputKey; // Assume the input is already decrypted

            Console.WriteLine($"Generated Key: {generatedKey}");
            Console.WriteLine($"Decrypted Key: {decryptedKey}");

            if (ValidateLicense(decryptedKey))
            {
                MessageBox.Show("Activation Successful");
                IsActivated = true; // Set the activation flag
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid License Key");
            }
        }

        private bool ValidateLicense(string key)
        {
            // Validate the license key against the stored generated key
            return key == generatedKey;
        }

        private string DecryptKey(string encryptedKey)
        {
            // Assuming the key was encrypted using Base64; replace with your actual decryption logic
            byte[] bytes = Convert.FromBase64String(encryptedKey);
            return Encoding.UTF8.GetString(bytes);
        }

        private bool IsBase64String(string s)
        {
            s = s.Trim();
            return (s.Length % 4 == 0) && System.Text.RegularExpressions.Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", System.Text.RegularExpressions.RegexOptions.None);
        }

        private void btnGetKey_Click(object sender, EventArgs e)
        {
            string encryptedKey = GenerateEncryptedKey();
            Clipboard.SetText(encryptedKey);
            MessageBox.Show("Key copied to clipboard");
            Console.WriteLine($"Generated Key: {generatedKey}");
        }

        private string GenerateEncryptedKey()
        {
            // Generate a random key
            generatedKey = GenerateRandomKey(); // Store the generated key
            // Encrypt the key
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(generatedKey));
        }

        private string GenerateRandomKey()
        {
            // Generate a random string as the key
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 16)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
