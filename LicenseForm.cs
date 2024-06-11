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
using System.IO;

namespace SIPSample
{
    public partial class LicenseForm : Form
    {
        public bool IsActivated { get; private set; } = false; // Public property to track if the license is activated
        public bool IsTrialStarted { get; private set; } = false; // Public property to track if the trial is started

        private string generatedKey; // Field to store the generated key
        private static readonly byte[] aesKey = Encoding.UTF8.GetBytes("12345678901234567890123456789012"); // 32 bytes key
        private static readonly byte[] aesIV = Encoding.UTF8.GetBytes("1234567890123456"); // 16 bytes IV

        public LicenseForm()
        {
            InitializeComponent();
            // Add a button for resetting the license status for demonstration purposes
            Button resetButton = new Button();
            resetButton.Text = "Reset License";
            resetButton.Location = new Point(10, 200); // Adjust the location as needed
            resetButton.Click += ResetButton_Click;
            this.Controls.Add(resetButton);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ResetLicenseStatus();
            MessageBox.Show("License status has been reset.");
        }

        private void ResetLicenseStatus()
        {
            // Delete the registry key that stores the activation status
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SIPSample", true);
            if (key != null)
            {
                key.DeleteValue("IsActivated", false);
                key.Close();
            }
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
            // The inputKey should be the decrypted key entered by the user
            string inputKey = txtLicenseKey.Text;

            // Now compare the input key with the generated key
            if (ValidateLicense(inputKey))
            {
                MessageBox.Show("Activation Successful");
                IsActivated = true; // Set the activation flag
                SaveActivationStatus(true); // Save the activation status
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

        private string EncryptKey(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = aesKey;
                aesAlg.IV = aesIV;
                aesAlg.Padding = PaddingMode.PKCS7;  // Ensure padding is set to PKCS7

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }

        private string DecryptKey(string cipherText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = aesKey;
                aesAlg.IV = aesIV;
                aesAlg.Padding = PaddingMode.PKCS7;  // Ensure padding is set to PKCS7

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        private void btnGetKey_Click(object sender, EventArgs e)
        {
            string randomKey = GenerateRandomKey();
            string encryptedKey = EncryptKey(randomKey);
            Clipboard.SetText(encryptedKey);
            MessageBox.Show("Key copied to clipboard");
            Console.WriteLine($"Generated Key: {generatedKey}");
        }

        private string GenerateRandomKey()
        {
            // Generate a random string as the key
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            generatedKey = new string(Enumerable.Repeat(chars, 16)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return generatedKey;
        }

        private void SaveActivationStatus(bool status)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SIPSample");
            key.SetValue("IsActivated", status);
            key.Close();
        }
    }
}
