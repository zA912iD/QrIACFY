// 代码生成时间: 2025-09-18 15:12:32
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

// 定义数据模型
public class DataModel : INotifyPropertyChanged
{
    // 声明属性
    private string _name;
    private int _age;

    // 构造函数
    public DataModel()
    {
    }

    // Name属性
    public string Name
    {
        get { return _name; }
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    }

    // Age属性
    public int Age
    {
        get { return _age; }
        set
        {
            if (_age != value)
            {
                _age = value;
                OnPropertyChanged();
            }
        }
    }

    // 实现INotifyPropertyChanged接口
    public event PropertyChangedEventHandler PropertyChanged;

    // 属性更改通知方法
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

// 定义ViewModel
public class ViewModel : INotifyPropertyChanged
{
    private DataModel _dataModel;

    // 构造函数
    public ViewModel()
    {
        _dataModel = new DataModel();
    }

    // Name属性
    public string Name
    {
        get { return _dataModel.Name; }
        set
        {
            if (_dataModel.Name != value)
            {
                _dataModel.Name = value;
                OnPropertyChanged();
            }
        }
    }

    // Age属性
    public int Age
    {
        get { return _dataModel.Age; }
        set
        {
            if (_dataModel.Age != value)
            {
                _dataModel.Age = value;
                OnPropertyChanged();
            }
        }
    }

    // 实现INotifyPropertyChanged接口
    public event PropertyChangedEventHandler PropertyChanged;

    // 属性更改通知方法
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

// ViewModel的扩展，用于错误处理
public static class ViewModelExtensions
{
    public static void SetProperty<T>(this ViewModel viewModel, ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return;
        field = value;
        viewModel.OnPropertyChanged(propertyName);
    }
}
