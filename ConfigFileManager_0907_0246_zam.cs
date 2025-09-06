// 代码生成时间: 2025-09-07 02:46:48
// ConfigFileManager.cs
// This class provides functionality to manage configuration files in a WPF application.

using System;
using System.IO;
using System.Windows;
using System.Xml.Linq;

namespace ConfigFileManagerApp
{
    // Define the ConfigFileManager class responsible for operations related to configuration files.
    public class ConfigFileManager
    {
        private const string ConfigFileName = "appSettings.xml"; // Name of the configuration file.
        private readonly string configFilePath;

        public ConfigFileManager(string path)
        {
            // Initialize the configuration file path.
            configFilePath = path;
        }

        // Load the configuration file and return its content as an XDocument.
        public XDocument LoadConfigFile()
        {
            try
            {
                if (!File.Exists(configFilePath))
                {
                    throw new FileNotFoundException("Configuration file not found.", ConfigFileName);
                }

                return XDocument.Load(configFilePath);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the file loading process.
                MessageBox.Show($"Error loading configuration file: {ex.Message}");
                return null;
            }
        }

        // Update the configuration file with new content.
        public bool UpdateConfigFile(XDocument newConfig)
        {
            try
            {
                if (newConfig == null)
                {
                    throw new ArgumentNullException(nameof(newConfig), "New configuration document cannot be null.");
                }

                newConfig.Save(configFilePath);
                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the file updating process.
                MessageBox.Show($"Error updating configuration file: {ex.Message}");
                return false;
            }
        }

        // Get a value from the configuration file by key.
        public string GetValue(string key)
        {
            try
            {
                var config = LoadConfigFile();
                if (config == null) return null;

                var value = config.Element("AppSettings")?.Element(key)?.Value;
                return value;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving value from configuration: {ex.Message}");
                return null;
            }
        }

        // Set a value in the configuration file by key.
        public bool SetValue(string key, string value)
        {
            try
            {
                var config = LoadConfigFile();
                if (config == null) return false;

                var element = config.Element("AppSettings")?.Element(key);
                if (element == null)
                {
                    element = new XElement(key);
                    config.Element("AppSettings").Add(element);
                }

                element.Value = value;
                return UpdateConfigFile(config);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error setting value in configuration: {ex.Message}");
                return false;
            }
        }
    }
}
