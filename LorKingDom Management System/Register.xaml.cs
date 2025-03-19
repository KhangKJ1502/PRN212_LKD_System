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
using LorKingDom_Management_System.Models;
using LorKingDom_Management_System.ViewModels;
using LorKingDom_Management_System.ViewModels;
namespace LorKingDom_Management_System
{
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            this.DataContext = new SignUpViewModels();
            CheckDatabaseConnection();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Nút Close
            Application.Current.Shutdown();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Kéo cửa sổ
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void TextName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtName.Focus();
        }

        private void TextPhone_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPhone.Focus();
        }

        private void TextEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void TextPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password))
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as SignUpViewModels;
            if (viewModel != null)
            {
                viewModel.TextBoxItem.AccountName = txtName.Text;
                viewModel.TextBoxItem.PhoneNumber = txtPhone.Text;
                viewModel.TextBoxItem.Email = txtEmail.Text;
                viewModel.TextBoxItem.Password = txtPassword.Password;

                if (viewModel.RegisterCommand.CanExecute(null))
                    viewModel.RegisterCommand.Execute(null);
            }
        }


        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow registerWin = new MainWindow();

            // Hiển thị cửa sổ đó
            registerWin.Show();
            this.Close();

        }
        private void CheckDatabaseConnection()
        {
            try
            {
                using (var context = new LorKingDomManagementContext())
                {
                    if (context.Database.CanConnect())
                    {
                        MessageBox.Show("Kết nối cơ sở dữ liệu thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            }
        }
    } // Đóng class Register
} // Đóng namespace LorKingDom_Management_System
