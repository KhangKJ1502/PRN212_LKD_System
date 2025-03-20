using Microsoft.Win32;
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
using LorKingDom_Management_System.ViewModels;

namespace LorKingDom_Management_System.Views.Admin
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : Page
    {
        public ProductView()
        {
            InitializeComponent();
            this.DataContext = new ProductViewModels();

        }

        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp",
                Title = "Chọn một ảnh"
            };

            if (openFileDialog.ShowDialog() == true) {
                // Hiển thị ảnh đã chọn trong Image control
                imgPreview.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
            // Gán đường dẫn ảnh vào TextBoxItem.Image
            if (DataContext is ProductViewModels viewModel && viewModel.TextBoxItem != null) {
                viewModel.TextBoxItem.Image = openFileDialog.FileName;
            }
        }
    }
}
