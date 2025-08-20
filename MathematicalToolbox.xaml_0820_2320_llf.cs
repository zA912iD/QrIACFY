// 代码生成时间: 2025-08-20 23:20:47
using System;
using System.Windows;
using System.Windows.Controls;

namespace MathematicalToolboxApp
{
    /// <summary>
# NOTE: 重要实现细节
    /// Interaction logic for MathematicalToolbox.xaml
    /// </summary>
    public partial class MathematicalToolbox : UserControl
    {
        public MathematicalToolbox()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            PerformCalculation("+");
# 增强安全性
        }

        private void Subtract_Click(object sender, RoutedEventArgs e)
# TODO: 优化性能
        {
            PerformCalculation("-");
        }
# 扩展功能模块

        private void Multiply_Click(object sender, RoutedEventArgs e)
# TODO: 优化性能
        {
# 改进用户体验
            PerformCalculation("*");
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            PerformCalculation("/");
        }

        private void PerformCalculation(string operation)
        {
            try
            {
                double result;
                double number1 = Convert.ToDouble(TextBoxNumber1.Text);
                double number2 = Convert.ToDouble(TextBoxNumber2.Text);
# 改进用户体验

                switch (operation)
                {
                    case "+":
                        result = number1 + number2;
                        break;
                    case "-":
                        result = number1 - number2;
                        break;
# 增强安全性
                    case "*":
                        result = number1 * number2;
                        break;
                    case "/":
                        if (number2 == 0)
                        {
                            MessageBox.Show("Division by zero is not allowed.");
                            return;
                        }
                        result = number1 / number2;
# NOTE: 重要实现细节
                        break;
                    default:
                        throw new ArgumentException("Invalid operation");
# 添加错误处理
                }
# 改进用户体验

                TextBoxResult.Text = result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}