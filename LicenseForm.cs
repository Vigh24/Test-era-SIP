using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Management; // Add reference to System.Management

namespace EratronicsPhone
{
    public partial class LicenseForm : Form
    {
        public bool IsActivated { get; private set; } = false; // Public property to track if the license is activated
        public bool IsTrialStarted { get; private set; } = false; // Public property to track if the trial is started
        public bool IsClosedWithoutAction { get; private set; } = true; // Public property to track if the form is closed without action

        private string generatedKey; // Field to store the generated key

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
                key.DeleteValue("TrialStartDate", false);
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
            ActivateLicense();
        }

        private void ActivateLicense()
        {
            string inputKey = txtLicenseKey.Text;
            if (ValidateLicense(inputKey))
            {
                SaveActivationStatus(true);
                MessageBox.Show("License activated successfully.");
                this.IsActivated = true;
                this.IsClosedWithoutAction = false; // Set to false as action is taken
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid license key.");
            }
        }

        private bool ValidateLicense(string inputKey)
        {
            string systemInfo = GetSystemInfo(); // Retrieve system-specific information
            string encodedKey = EncodeKey(systemInfo); // Encode the system information
            string decodedKey = DecodeKey(encodedKey); // Decode the encoded key to match the decryptor's logic
            string modifiedKey = decodedKey + "Era"; // Modify the decoded key
            string encodedModifiedKey = EncodeKey(modifiedKey); // Encode the modified key
            string finalKey = EncodeKey(encodedModifiedKey + "tro"); // Apply further transformations
            finalKey = EncodeKey(finalKey + "nics"); // Apply final transformation

            // Debugging statements
            Console.WriteLine("System Info: " + systemInfo);
            Console.WriteLine("Encoded Key: " + encodedKey);
            Console.WriteLine("Decoded Key: " + decodedKey);
            Console.WriteLine("Modified Key: " + modifiedKey);
            Console.WriteLine("Encoded Modified Key: " + encodedModifiedKey);
            Console.WriteLine("Final Key: " + finalKey);
            Console.WriteLine("Input Key: " + inputKey);

            return inputKey == finalKey; // Compare the input key with the dynamically generated final key
        }

        private string EncodeKey(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private string DecodeKey(string encodedText)
        {
            var base64EncodedBytes = Convert.FromBase64String(encodedText);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private void btnGetKey_Click(object sender, EventArgs e)
        {
            string systemInfo = GetSystemInfo();
            string encodedKey = EncodeKey(systemInfo);
            Clipboard.SetText(encodedKey);
            MessageBox.Show("Generated License Key: " + systemInfo);
            MessageBox.Show("Encrypted License Key: " + encodedKey);
            MessageBox.Show("Encrypted License Key copied to clipboard");
            Console.WriteLine("System Info: " + systemInfo);
            Console.WriteLine("Encoded Key: " + encodedKey);
        }

        private string GetSystemInfo()
        {
            // Get the serial number of the system
            string serialNumber = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS");
            foreach (ManagementObject obj in searcher.Get())
            {
                serialNumber = obj["SerialNumber"].ToString();
            }

            // Get the MAC address
            string macAddress = "";
            searcher = new ManagementObjectSearcher("SELECT MACAddress FROM Win32_NetworkAdapter WHERE MACAddress IS NOT NULL AND NOT (MACAddress LIKE '00:00:00:00:00:00')");
            foreach (ManagementObject obj in searcher.Get())
            {
                macAddress = obj["MACAddress"].ToString();
                break; // Get the first MAC address
            }

            return serialNumber + macAddress; // Concatenate serial number and MAC address
        }

        private void SaveActivationStatus(bool status)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SIPSample");
            key.SetValue("IsActivated", status);
            key.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!IsActivated && !IsTrialStarted)
            {
                IsClosedWithoutAction = true;
            }
            base.OnFormClosing(e);
        }
    }
}