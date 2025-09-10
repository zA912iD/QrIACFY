// 代码生成时间: 2025-09-11 05:56:25
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace InventoryManagementApp
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<InventoryItem> _inventoryList = new ObservableCollection<InventoryItem>();

        public MainWindow()
        {
            InitializeComponent();
            InitializeInventoryList();
        }

        private void InitializeInventoryList()
        {
            // Initialize the inventory list with sample data
            _inventoryList.Add(new InventoryItem { Id = 1, Name = "Widget", Quantity = 100 });
            _inventoryList.Add(new InventoryItem { Id = 2, Name = "Gadget", Quantity = 50 });
            // Bind the inventory list to the UI
            InventoryListView.ItemsSource = _inventoryList;
        }

        // Add a new inventory item
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newItem = new InventoryItem
                {
                    Id = GetNextItemId(),
                    Name = NameTextBox.Text,
                    Quantity = int.Parse(QuantityTextBox.Text)
                };
                _inventoryList.Add(newItem);
                // Clear the input fields
                NameTextBox.Clear();
                QuantityTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding item: {ex.Message}");
            }
        }

        // Update an existing inventory item
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedId = SelectedItemId;
                var itemToUpdate = _inventoryList.FirstOrDefault(i => i.Id == selectedId);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Name = NameTextBox.Text;
                    itemToUpdate.Quantity = int.Parse(QuantityTextBox.Text);
                }
                else
                {
                    MessageBox.Show("Item not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating item: {ex.Message}");
            }
        }

        // Remove an existing inventory item
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedId = SelectedItemId;
                var itemToRemove = _inventoryList.FirstOrDefault(i => i.Id == selectedId);
                if (itemToRemove != null)
                {
                    _inventoryList.Remove(itemToRemove);
                }
                else
                {
                    MessageBox.Show("Item not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing item: {ex.Message}");
            }
        }

        private int GetNextItemId()
        {
            // This method would typically query the database to find the next available ID
            // For simplicity, it just increments the last ID used
            if (_inventoryList.Count == 0) return 1;
            return _inventoryList[_inventoryList.Count - 1].Id + 1;
        }

        private int SelectedItemId
        {
            get
            {
                var selectedItem = InventoryListView.SelectedItem as InventoryItem;
                return selectedItem != null ? selectedItem.Id : 0;
            }
        }
    }

    // Data model for inventory items
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
