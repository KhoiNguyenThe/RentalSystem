using Microsoft.Win32;
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
using static Repositories.Repositories.UserRepository;

namespace RentalSystem.Homepage
{

    public partial class RegisterWindow : Window
    {
        private readonly AuthService _sv;
        private string? _citizenImagePath;

        public RegisterWindow()
        {
            InitializeComponent();
            _sv = new AuthService();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var name = txtName.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Password.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all required fields!",
                    "Blank", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = _sv.Register(name, email, password, _citizenImagePath);

            switch (result)
            {
                case RegisterResult.Success:
                    MessageBox.Show("Registration successful! Please log in to continue.",
                        "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    new MainWindow().Show();
                    this.Close();
                    break;
                case RegisterResult.EmailExists:
                    MessageBox.Show("This email already exists! Please use another one.",
                        "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case RegisterResult.UsernameExists:
                    MessageBox.Show("User already exists!",
                        "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                default:
                    MessageBox.Show("Registration failed! Please try again.",
                        "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFile = openFileDialog.FileName;
                imgPreview.Source = new BitmapImage(new Uri(selectedFile));
                _citizenImagePath = selectedFile;
            }
        }

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Camera capture feature not implemented yet.",
                "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
