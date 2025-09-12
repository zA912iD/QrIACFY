// 代码生成时间: 2025-09-12 22:13:48
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows;

// 配置文件管理器类
public class ConfigFileManager
{
    // 配置文件路径
    private string configFilePath;

    // 构造函数，初始化配置文件路径
    public ConfigFileManager(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentException("配置文件路径不能为空");
        }

        this.configFilePath = path;
    }

    // 加载配置文件内容
    public Dictionary<string, string> LoadConfig()
    {
        if (!File.Exists(configFilePath))
        {
            throw new FileNotFoundException("配置文件不存在");
        }

        var config = new Dictionary<string, string>();
        foreach (var line in File.ReadAllLines(configFilePath))
        {
            var match = Regex.Match(line, @"^\s*(\w+)\s*=\s*(.*)\s*$");
            if (match.Success)
            {
                var key = match.Groups[1].Value;
                var value = match.Groups[2].Value;
                config[key] = value;
            }
        }

        return config;
    }

    // 保存配置文件内容
    public void SaveConfig(Dictionary<string, string> config)
    {
        if (config == null || config.Count == 0)
        {
            throw new ArgumentException("配置内容不能为空");
        }

        var lines = new List<string>();
        foreach (var item in config)
        {
            lines.Add($