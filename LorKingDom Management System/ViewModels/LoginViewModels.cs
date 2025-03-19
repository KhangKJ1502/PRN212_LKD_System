using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LorKingDom_Management_System.Models;
using Newtonsoft.Json;
using BCrypt.Net;
using System.Windows;
namespace LorKingDom_Management_System.ViewModels
{
    public class LoginViewModels : BaseViewModel
    {

        private string _userName;

        private string _password;

        private string _email;

        private string _phoneNumber;


        public string Name { get { return _userName; } set { _userName = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string Email { get { return _email; } set { _email = value; } }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }

        }

        public ICommand RegisterCommand { get; }

        private bool CanExecuteRegister(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(PhoneNumber) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   !string.IsNullOrWhiteSpace(Password);
        }


        private void ExecuteRegister(object parameter)
        {
            if (TextBoxItem == null ||
                string.IsNullOrWhiteSpace(TextBoxItem.AccountName) ||
                string.IsNullOrWhiteSpace(TextBoxItem.PhoneNumber) ||
                string.IsNullOrWhiteSpace(TextBoxItem.Email) ||
                string.IsNullOrWhiteSpace(TextBoxItem.Password))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin đăng ký!");
                return;
            }

         
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(TextBoxItem.Password);

          
            var newAccount = new Account
            {
                AccountName = TextBoxItem.AccountName,
                PhoneNumber = TextBoxItem.PhoneNumber,
                Email = TextBoxItem.Email,
                Password = hashedPassword,
                CreatedAt = DateTime.Now,
                Status = "Active",
                RoleId = 1 
            };

       
            using (var context = new LorKingDomManagementContext())
            {
                context.Accounts.Add(newAccount);
                context.SaveChanges();
            }

            MessageBox.Show("Đăng ký thành công!");
        }

        private Account _textBoxItem;
        public Account TextBoxItem
        {
            get { return _textBoxItem; }
            set
            {
                _textBoxItem = value;
                OnPropertyChanged(nameof(TextBoxItem));
            }
        }

        private Account _selectedItem;
        public Account SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));

                if (_selectedItem != null)
                {
                    TextBoxItem = JsonConvert.DeserializeObject<Account>(JsonConvert.SerializeObject(_selectedItem));
                }
            }
        }
    }
}
