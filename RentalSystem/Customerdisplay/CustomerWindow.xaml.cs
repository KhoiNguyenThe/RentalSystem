using Repositories.Entities;
using Services.Services;
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
using System.Windows.Shapes;

namespace RentalSystem.Customerdisplay
{

    public partial class CustomerWindow : Window
    {
        private readonly CustomerService _customerService;
        private readonly int _customerId;

        public CustomerWindow(int customerId)
        {
            InitializeComponent();
            _customerService = new CustomerService();
            _customerId = customerId;

            LoadCustomerInfo();
        }

        private void LoadCustomerInfo()
        {
            string customerName = _customerService.GetCustomerName(_customerId);
            txtWelcome.Text = $"Welcome, {customerName}";
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have been logged out.");
            this.Close();
        }
    }
}
