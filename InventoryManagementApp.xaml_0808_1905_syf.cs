// 代码生成时间: 2025-08-08 19:05:58
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

// ViewModel for Inventory Management
public class InventoryViewModel : ViewModelBase
{
    private List<Item> _items;
    public List<Item> Items
    {
        get { return _items; }
        set { _items = value; OnPropertyChanged(); }
    }

    public InventoryViewModel()
    {
        // Load initial items
        LoadItems();
    }

    private void LoadItems()
    {
        // This method should be replaced with actual data loading logic
        Items = new List<Item>()
        {
            new Item { Id = 1, Name = "Item1", Quantity = 10 },
            new Item { Id = 2, Name = "Item2", Quantity = 20 }
        };
    }

    public void AddItem(Item item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        Items.Add(item);
    }

    public void UpdateItem(Item item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        var existingItem = Items.FirstOrDefault(i => i.Id == item.Id);
        if (existingItem != null)
        {
            existingItem.Name = item.Name;
            existingItem.Quantity = item.Quantity;
        }
        else
        {
            throw new InvalidOperationException("Item not found.");
        }
    }

    public void RemoveItem(int id)
    {
        var item = Items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            Items.Remove(item);
        }
        else
        {
            throw new InvalidOperationException("Item not found.");
        }
    }
}

// Model for Inventory Item
public class Item : ViewModelBase
{
    private int _id;
    private string _name;
    private int _quantity;

    public int Id
    {
        get { return _id; }
        set { _id = value; OnPropertyChanged(); }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; OnPropertyChanged(); }
    }

    public int Quantity
    {
        get { return _quantity; }
        set { _quantity = value; OnPropertyChanged(); }
    }
}

// Base class for View Models
public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

// XAML Code for the User Interface
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new InventoryViewModel();
    }

    private void AddItemButton_Click(object sender, RoutedEventArgs e)
    {
        // Logic to add an item
    }

    private void UpdateItemButton_Click(object sender, RoutedEventArgs e)
    {
        // Logic to update an item
    }

    private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
    {
        // Logic to remove an item
    }
}
