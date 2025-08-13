// 代码生成时间: 2025-08-13 18:50:45
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SortAlgorithmWpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            // 获取用户输入的数据列表
            List<int> inputList = GetInputList();

            if (inputList == null || inputList.Count == 0)
            {
                MessageBox.Show("Please enter valid numbers.");
                return;
            }

            // 选择排序算法并执行
            List<int> sortedList = SortList(inputList);

            // 显示排序结果
            DisplaySortedList(sortedList);
        }

        private List<int> GetInputList()
        {
            // 从文本框读取输入，转换成整数列表
            string inputText = InputTextBox.Text;
            if (string.IsNullOrWhiteSpace(inputText))
            {
                return null;
            }

            string[] inputNumbers = inputText.Split(',');
            List<int> inputList = new List<int>();
            foreach (var number in inputNumbers)
            {
                if (int.TryParse(number.Trim(), out int num))
                {
                    inputList.Add(num);
                }
                else
                {
                    return null;
                }
            }

            return inputList;
        }

        private List<int> SortList(List<int> inputList)
        {
            // 选择一个排序算法，这里使用冒泡排序作为示例
            for (int i = 0; i < inputList.Count - 1; i++)
            {
                for (int j = 0; j < inputList.Count - i - 1; j++)
                {
                    if (inputList[j] > inputList[j + 1])
                    {
                        // 交换元素位置
                        int temp = inputList[j];
                        inputList[j] = inputList[j + 1];
                        inputList[j + 1] = temp;
                    }
                }
            }

            return inputList;
        }

        private void DisplaySortedList(List<int> sortedList)
        {
            // 显示排序后的列表到输出文本框
            OutputTextBox.Text = string.Join(", ", sortedList);
        }
    }
}
