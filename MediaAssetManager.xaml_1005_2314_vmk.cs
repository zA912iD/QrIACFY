// 代码生成时间: 2025-10-05 23:14:55
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaAssetManagerApp
{
    /// <summary>
    /// Interaction logic for MediaAssetManager.xaml
    /// </summary>
    public partial class MediaAssetManager : UserControl
    {
        private const string MediaDirectory = @"C:\MediaAssets";
        private List<MediaAsset> mediaAssets;

        public MediaAssetManager()
        {
            InitializeComponent();
            InitializeMediaAssets();
        }

        private void InitializeMediaAssets()
        {
            try
            {
                mediaAssets = Directory.GetFiles(MediaDirectory, "*", SearchOption.AllDirectories)
                    .Where(file => IsMediaFile(file))
                    .Select(file => new MediaAsset(file))
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading media assets: {ex.Message}");
            }
        }

        private bool IsMediaFile(string file)
        {
            // Define media file extensions
            var mediaExtensions = new HashSet<string> { ".mp3", ".wav", ".mp4", ".avi", ".jpg", ".png", ".gif" };
            return mediaExtensions.Contains(Path.GetExtension(file).ToLower());
        }

        private void DisplayMediaAssets()
        {
            // Assuming 'mediaListView' is the name of the ListView control in XAML
            mediaListView.ItemsSource = mediaAssets;
            mediaListView.DisplayMemberPath = "FileName";
        }
    }

    public class MediaAsset
    {
        public string FileName { get; }
        public string FilePath { get; }
        public string FileSize { get; }
        public DateTime LastModified { get; }

        public MediaAsset(string filePath)
        {
            FilePath = filePath;
            FileName = Path.GetFileName(filePath);
            FileSize = new FileInfo(filePath).Length.ToString();
            LastModified = new FileInfo(filePath).LastWriteTime;
        }
    }
}