// 代码生成时间: 2025-08-09 12:36:09
    public partial class MainWindow : Window\r
    {\r
        public MainWindow()\r
        {\r
            InitializeComponent();\r
        }\r
\r
        private void SelectFilesButton_Click(object sender, RoutedEventArgs e)\r
        {\r
            OpenFileDialog openFileDialog = new OpenFileDialog();\r
            openFileDialog.Multiselect = true;\r
            openFileDialog.Title = "Select Files";\r
            openFileDialog.Filter = "All files (*.*)|*.*";\r
            if (openFileDialog.ShowDialog() == DialogResult.OK)\r
            {\r
                foreach (var file in openFileDialog.FileNames)\r
                {\r
                    TryRenameFile(file, TextBoxNewNamePattern.Text);\r
                }\r
            }\r
        }\r
\r
        private void TryRenameFile(string filePath, string newNamePattern)\r
        {\r
            if (string.IsNullOrWhiteSpace(newNamePattern))\r
            {\r
                MessageBox.Show("Please enter a new name pattern.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);\r
                return;\r
            }\r
\r
            try\r
            {\r
                string directory = Path.GetDirectoryName(filePath);\r
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);\r
                string fileExtension = Path.GetExtension(filePath);\r
\r
                // Generate the new file name based on the pattern provided by the user.\r
                string newFileName = $