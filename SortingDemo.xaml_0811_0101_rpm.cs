// 代码生成时间: 2025-08-11 01:01:28
using System;
using System.Collections.Generic;
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

// MainWindow.xaml.cs 的部分实现
namespace SortingDemo
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

        // 按钮点击事件，用于调用排序算法
        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 获取输入列表
                List<int> numbers = GetNumbersFromInput();

                // 检查列表是否为空
                if (numbers == null || numbers.Count == 0)
                {
                    MessageBox.Show("请输入数字列表。");
                    return;
                }

                // 调用冒泡排序算法
                List<int> sortedNumbers = BubbleSort(numbers);

                // 显示排序后的结果
                DisplaySortedNumbers(sortedNumbers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误：{ex.Message}");
            }
        }

        // 从输入框获取数字列表
        private List<int> GetNumbersFromInput()
        {
            // 这里假设有一个名为 "InputTextBox" 的 TextBox 控件
            string input = InputTextBox.Text;
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            string[] parts = input.Split(',');
            List<int> numbers = new List<int>();
            foreach (var part in parts)
            {
                if (int.TryParse(part.Trim(), out int number))
                {
                    numbers.Add(number);
                }
            }
            return numbers;
        }

        // 冒泡排序算法实现
        private List<int> BubbleSort(List<int> numbers)
        {
            if (numbers == null || numbers.Count < 2)
            {
                return numbers;
            }

            int n = numbers.Count;
            bool swapped;
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                        swapped = true;
                    }
                }

                // 如果没有发生交换，则数组已经排序好
                if (!swapped)
                {
                    break;
                }
            }
            return numbers;
        }

        // 显示排序后的数字列表
        private void DisplaySortedNumbers(List<int> sortedNumbers)
        {
            // 这里假设有一个名为 "ResultTextBox" 的 TextBox 控件
            ResultTextBox.Text = string.Join(", ", sortedNumbers);
        }
    }
}