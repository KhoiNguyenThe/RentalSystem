using RentalSystem.Admindisplay;
using RentalSystem.Customerdisplay;
using RentalSystem.Homepage;
using RentalSystem.Staffdisplay;
using Services.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RentalSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AuthService _sv;
        public MainWindow()
        {
            InitializeComponent();
            _sv = new AuthService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Password.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password!!!");
                return;
            }

            var user = _sv.Login(email, password);

            if (user != null)
            {
                if (!user.IsActive)
                {
                    MessageBox.Show("Your account is inactive.");
                    return;
                }
  
                switch (user.Role.ToLower())
                {
                    case "admin":
                        var adminWindow = new AdminWindow();
                        adminWindow.Show();
                        this.Close();
                        break;

                    case "staff":
                        var staffWindow = new StaffWindow();
                        staffWindow.Show();
                        this.Close();
                        break;

                    case "customer":
                        var customerWindow = new CustomerWindow(user.Id);
                        customerWindow.Show();
                        this.Close();
                        break;


                    default:
                        MessageBox.Show("Role not recognized. Please contact support.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid email or password!");

            }
           }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }
    }
}