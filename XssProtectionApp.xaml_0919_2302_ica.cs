// 代码生成时间: 2025-09-19 23:02:51
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;

namespace XssProtectionApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // This method sanitizes the input to prevent XSS attacks
        private string SanitizeInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            // Remove HTML tags
            input = Regex.Replace(input, "<[^>]*>