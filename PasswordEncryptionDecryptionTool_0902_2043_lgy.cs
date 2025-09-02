// 代码生成时间: 2025-09-02 20:43:02
using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;

namespace PasswordEncryptionDecryptionTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string password = PasswordTextBox.Text;
                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter a password to encrypt.");
                    return;
                }

                string encryptedPassword = EncryptPassword(password);
                EncryptedPasswordTextBox.Text = encryptedPassword;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string encryptedPassword = EncryptedPasswordTextBox.Text;
                if (string.IsNullOrEmpty(encryptedPassword))
                {
                    MessageBox.Show("Please enter a password to decrypt.");
                    return;
                }

                string decryptedPassword = DecryptPassword(encryptedPassword);
                PasswordTextBox.Text = decryptedPassword;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private string EncryptPassword(string password)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = new byte[16] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                aes.IV = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15 };

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(password);
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        private string DecryptPassword(string encryptedPassword)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = new byte[16] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                aes.IV = new byte[16] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15 };

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(encryptedPassword)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
