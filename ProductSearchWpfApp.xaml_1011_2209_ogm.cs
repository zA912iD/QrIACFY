// 代码生成时间: 2025-10-11 22:09:45
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

// 定义商品类
public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}

// 商品搜索引擎的ViewModel
public class ProductSearchViewModel
{
    private List<Product> _products;
    public List<Product> Products
    {
        get { return _products; }
        set { _products = value; }
    }

    public ProductSearchViewModel()
    {
        // 初始化商品列表
        InitializeProducts();
    }

    private void InitializeProducts()
    {
        // 这里可以替换为从数据库或外部服务获取商品数据
        Products = new List<Product>()
        {
            new Product() { Id = "1", Name = "Apple", Description = "Fresh apple", Price = 1.50 },
            new Product() { Id = "2", Name = "Banana", Description = "Sweet banana", Price = 0.50 },
            // 其他商品数据...
        };
    }

    // 根据关键词搜索商品
    public List<Product> SearchProducts(string keyword)
    {
        if (string.IsNullOrEmpty(keyword))
        {
            return Products;
        }
        return Products.Where(p => p.Name.ToLower().Contains(keyword.ToLower())).ToList();
    }
}

// 主窗口的Code-Behind
public partial class MainWindow : Window
{
    private ProductSearchViewModel viewModel;

    public MainWindow()
    {
        InitializeComponent();
        viewModel = new ProductSearchViewModel();
        DataContext = viewModel;
    }

    private void SearchButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // 获取用户输入的搜索关键词
            string keyword = SearchTextBox.Text;
            // 调用ViewModel的搜索方法
            viewModel.Products = viewModel.SearchProducts(keyword);
            // 刷新界面上的ListView显示结果
            ProductListView.ItemsSource = viewModel.Products;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
