// 代码生成时间: 2025-10-09 01:41:24
using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows;

namespace DigitalSignatureTool
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

        /// <summary>
        /// Signs a file with a digital signature
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void SignFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Select file to sign
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Filter = "All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;

                    // Sign the file
                    byte[] signedBytes = SignFile(filePath);

                    // Save the signed file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = openFileDialog.Filter;
                    saveFileDialog.FileName = Path.GetFileNameWithoutExtension(filePath) + "_signed" + Path.GetExtension(filePath);
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, signedBytes);
                        MessageBox.Show("File signed successfully!");
                    }
                }
            }
            catch (CryptographicException cryptographicException)
            {
                MessageBox.Show("Cryptographic error: " + cryptographicException.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Signs the provided file
        /// </summary>
        /// <param name="filePath">Path to the file to sign</param>
        /// <returns>Signed bytes of the file</returns>
        private byte[] SignFile(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // Calculate hash of the file
                    byte[] sourceBytes = sha256Hash.ComputeHash(fileStream);

                    // Sign the hash using a private key (for demonstration, a hardcoded key is used)
                    // NOTE: In a real-world scenario, use a secure method to retrieve the private key
                    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                    {
                        rsa.ImportRSAPrivateKey(/* Your private key here */);
                        byte[] signedBytes = rsa.SignData(sourceBytes, CryptoConfig.MapNameToOID("SHA256"));
                        return signedBytes;
                    }
                }
            }
        }
    }
}
