using LorKingDom_Management_System.ViewModels;
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

namespace LorKingDom_Management_System.Views.Admin
{
    /// <summary>
    /// Interaction logic for MainAdmin.xaml
    /// </summary>
    public partial class MainAdmin : Window
    {
        public MainAdmin()
        {
            InitializeComponent();
        }

        private void Click_Product_Mange(object sender, RoutedEventArgs e)
        {
            var productView = new ProductView();
            MainFrame.Navigate(productView);
        }
    }
}
