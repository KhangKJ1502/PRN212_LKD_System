using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LorKingDom_Management_System.Models;
using System.Windows.Input;
using Newtonsoft.Json;


namespace LorKingDom_Management_System.ViewModels
{
    public class ProductViewModels : BaseViewModel
    {
        private ObservableCollection<Product> allProducts {  get; set; }
        public ObservableCollection<Product> products {  get; set; }

        public ICommand AddCommand;
        public ICommand DeleteCommand;
        public ICommand SearchCommand;
        public ICommand UpdateCommand;
 
        public ProductViewModels()
        {
            LoadProducts();
            AddCommand = new RelayCommand(Add);
            UpdateCommand = new RelayCommand(Update);
            SearchCommand = new RelayCommand(Search);
            DeleteCommand = new RelayCommand(Delete);
        }

        private void Delete(object obj)
        {
            throw new NotImplementedException();
        }

        private void Search(object obj)
        {
            throw new NotImplementedException();
        }

        private void Add(object obj)
        {
            throw new NotImplementedException();
        }

        private void Update(object obj)
        {
            throw new NotImplementedException();
        }

        private void LoadProducts()
        {
            throw new NotImplementedException();
        }


        private Product _textBoxItem;
        public Product TextBoxItem
        {
            get { return _textBoxItem; }
            set
            {
                _textBoxItem = value;
                OnPropertyChanged(nameof(TextBoxItem));
            }
        }

        private Product _selectedItem;
        public Product SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                if (_selectedItem != null) {
                    TextBoxItem = JsonConvert.DeserializeObject<Product>(JsonConvert.SerializeObject(_selectedItem));
                }
            }
        }

    }
}
