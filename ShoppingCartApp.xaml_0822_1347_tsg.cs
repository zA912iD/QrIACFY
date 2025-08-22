// 代码生成时间: 2025-08-22 13:47:48
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ShoppingCartApp
{
    // MainWindow is the main window of the application.
    public partial class MainWindow : Window
    {
        private readonly List<CartItem> _cartItems;

        public MainWindow()
        {
            InitializeComponent();
            _cartItems = new List<CartItem>();
        }

        // Adds an item to the shopping cart.
        public void AddToCart(CartItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var existingItem = _cartItems.FirstOrDefault(c => c.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                _cartItems.Add(item);
            }
            UpdateCartUI();
        }

        // Removes an item from the shopping cart.
        public void RemoveFromCart(CartItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            _cartItems.RemoveAll(c => c.Id == item.Id);
            UpdateCartUI();
        }

        // Updates the UI with the current cart items.
        private void UpdateCartUI()
        {
            // Assuming there is a ListView control named cartListView
            // with a DataTemplate that binds to CartItem properties.
            cartListView.ItemsSource = null;
            cartListView.ItemsSource = _cartItems;
        }

        // Handles the click event of the 'Add to Cart' button.
        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming the clicked item is passed to this event.
            var item = (CartItem)sender;
            AddToCart(item);
        }

        // Handles the click event of the 'Remove from Cart' button.
        private void RemoveFromCartButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming the clicked item is passed to this event.
            var item = (CartItem)sender;
            RemoveFromCart(item);
        }
    }

    // CartItem represents an item in the shopping cart.
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
