// 代码生成时间: 2025-08-26 00:35:01
using System;
using System.Windows;
using System.Windows.Controls;

// 定义一个用于数据验证的类
public class FormValidator
{
    // 验证表单控件集合
    public void ValidateForm(IEnumerable<Control> controls)
    {
        foreach (var control in controls)
        {
            // 验证每个控件的值
            ValidateControl(control);
        }
    }

    // 验证单个控件
    private void ValidateControl(Control control)
    {
        // 如果控件是TextBox，则检查文本是否为空
        if (control is TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                throw new ArgumentException($"The field {textBox.Name} cannot be empty.");
            }
        }
        // 如果控件是DatePicker，则检查日期是否有效
        else if (control is DatePicker datePicker)
        {
            if (datePicker.SelectedDate == null)
            {
                throw new ArgumentException($"The date field {datePicker.Name} cannot be empty.");
            }
        }
        // 添加其他控件类型的验证逻辑
    }
}

// 主窗口类
public partial class MainWindow : Window
{
    private FormValidator formValidator = new FormValidator();

    public MainWindow()
    {
        InitializeComponent();
    }

    // 提交按钮点击事件处理器
    private void SubmitButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // 获取要验证的所有控件
            var controlsToValidate = GetAllControls(this);
            // 执行表单验证
            formValidator.ValidateForm(controlsToValidate);
            // 验证通过后的处理逻辑
            ProcessFormSubmission();
        }
        catch (ArgumentException ex)
        {
            // 显示错误消息
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    // 获取当前窗口中所有控件的方法
    private IEnumerable<Control> GetAllControls(DependencyObject depObj)
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        {
            var child = VisualTreeHelper.GetChild(depObj, i);
            if (child != null && child is Control)
            {
                yield return (Control)child;
            }
            else if (child != null)
            {
                foreach (var control in GetAllControls(child))
                {
                    yield return control;
                }
            }
        }
    }

    // 提交表单后的处理逻辑
    private void ProcessFormSubmission()
    {
        // 这里添加提交表单后的处理逻辑
        MessageBox.Show("Form submitted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
