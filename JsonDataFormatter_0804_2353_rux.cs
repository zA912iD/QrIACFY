// 代码生成时间: 2025-08-04 23:53:54
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

// 定义一个简单的数据类
public class SampleData
{
    public string Name { get; set; }
    public int Age { get; set; }
}

// Json数据格式转换器
public class JsonDataFormatter
{
    private const string DateFormat = "yyyy-MM-dd\