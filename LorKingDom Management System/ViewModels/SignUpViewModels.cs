using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LorKingDom_Management_System.Models;
using Newtonsoft.Json;
using System.Windows.Input;
using System.Windows;
using System.Security.Cryptography;
namespace LorKingDom_Management_System.ViewModels
{
    public class SignUpViewModels : BaseViewModel
    {
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
                    // Copy dữ liệu từ selected item sang TextBoxItem
                    TextBoxItem = JsonConvert.DeserializeObject<Account>(
                        JsonConvert.SerializeObject(_selectedItem));
                }
            }
        }

        public ICommand RegisterCommand { get; }

        public SignUpViewModels()
        {
            TextBoxItem = new Account();
            RegisterCommand = new RelayCommand(ExecuteRegister, CanExecuteRegister);
        }

        private bool CanExecuteRegister(object parameter)
        {
            return TextBoxItem != null &&
                   !string.IsNullOrWhiteSpace(TextBoxItem.AccountName) &&
                   !string.IsNullOrWhiteSpace(TextBoxItem.PhoneNumber) &&
                   !string.IsNullOrWhiteSpace(TextBoxItem.Email) &&
                   !string.IsNullOrWhiteSpace(TextBoxItem.Password);
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

            // Tính toán MD5 hash cho mật khẩu
            string hashedPassword = ComputeMd5Hash(TextBoxItem.Password);

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

            try
            {
                using (var context = new LorKingDomManagementContext())
                {
                    context.Accounts.Add(newAccount);
                    context.SaveChanges();
                }
                MessageBox.Show("Đăng ký thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi đăng ký: " + ex.Message);
            }
        }

        private string ComputeMd5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}