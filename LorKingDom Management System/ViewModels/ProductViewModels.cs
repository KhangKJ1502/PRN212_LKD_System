﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using LorKingDom_Management_System.Models;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Windows;

namespace LorKingDom_Management_System.ViewModels
{
    public class ProductViewModels : BaseViewModel
    {
        private ObservableCollection<Product> allProducts { get; set; }
        public ObservableCollection<Product> products { get; set; }
        public ObservableCollection<Category> categories { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public ProductViewModels()
        {

            LoadCategory();
            LoadProducts();
            AddCommand = new RelayCommand(Add);
            UpdateCommand = new RelayCommand(Update);
            SearchCommand = new RelayCommand(Search);
            DeleteCommand = new RelayCommand(Delete);
        }

        private void Delete(object obj)
        {
            if (SelectedItem == null) {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa!");
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes) {
                using (var context = new LorKingDomManagementContext()) {
                    var product = context.Products.FirstOrDefault(p => p.ProductId == SelectedItem.ProductId);
                    if (product != null) {
                        context.Products.Remove(product);
                        context.SaveChanges();
                        MessageBox.Show("Xóa sản phẩm thành công!");
                        LoadProducts();
                    }
                }
            }
        }

        private void Search(object obj)
        {
            if (string.IsNullOrWhiteSpace(SearchText)) {
                LoadProducts(); // Nếu không có từ khóa, hiển thị toàn bộ danh sách
                return;
            }

            using (var context = new LorKingDomManagementContext()) {
                var filteredProducts = context.Products
    .Where(p => p.Name.ToLower().Contains(SearchText.ToLower()))
    .ToList();
                products = new ObservableCollection<Product>(filteredProducts);
                OnPropertyChanged(nameof(products));
            }
        }

        private void Add(object obj)
        {
            if (TextBoxItem == null) {
                TextBoxItem = new Product(); // Khởi tạo TextBoxItem nếu nó null
            }


            using (var context = new LorKingDomManagementContext()) {
                if (TextBoxItem.CategoryId == 0 || !context.Categories.Any(c => c.CategoryId == TextBoxItem.CategoryId)) {
                    MessageBox.Show("Vui lòng chọn danh mục hợp lệ!");
                    return;
                }
                Product newProduct = new Product
                {
                    Name = TextBoxItem.Name ?? "",
                    Material = TextBoxItem.Material ?? "",
                    MinAge = TextBoxItem.MinAge,
                    Price = TextBoxItem.Price,
                    Quantity = TextBoxItem.Quantity,
                    Status = TextBoxItem.Status,
                    Description = TextBoxItem.Description ?? "",
                    Image = TextBoxItem.Image ?? "",
                    CategoryId = TextBoxItem.CategoryId
                };


                context.Products.Add(newProduct);
                context.SaveChanges();
                MessageBox.Show("Thêm sản phẩm thành công!");
                LoadProducts();
            }
        }

        private void Update(object obj)
        {
            if (SelectedItem == null) {
                MessageBox.Show("Vui lòng chọn sản phẩm để cập nhật!");
                return;
            }

            if (TextBoxItem == null) {
                MessageBox.Show("Lỗi: TextBoxItem chưa được khởi tạo!");
                return;
            }

            using (var context = new LorKingDomManagementContext()) {
                var existingProduct = context.Products.FirstOrDefault(p => p.ProductId == SelectedItem.ProductId);
                if (existingProduct != null) {
                    // Cập nhật thông tin sản phẩm
                    existingProduct.Name = TextBoxItem.Name ?? "";
                    existingProduct.Material = TextBoxItem.Material ?? "";
                    existingProduct.MinAge = TextBoxItem.MinAge;
                    existingProduct.Price = TextBoxItem.Price;
                    existingProduct.Quantity = TextBoxItem.Quantity;
                    existingProduct.Status = TextBoxItem.Status;
                    existingProduct.Description = TextBoxItem.Description ?? "";
                    existingProduct.Image = TextBoxItem.Image ?? "";
                    existingProduct.CategoryId = TextBoxItem.CategoryId;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    try {
                        context.SaveChanges();
                        MessageBox.Show("Cập nhật sản phẩm thành công!");
                    } catch (Exception ex) {
                        MessageBox.Show($"Lỗi khi cập nhật sản phẩm: {ex.Message}");
                    }

                    // Cập nhật ObservableCollection để phản ánh thay đổi trên giao diện
                    var index = products.IndexOf(SelectedItem);
                    if (index != -1) {
                        products[index] = JsonConvert.DeserializeObject<Product>(JsonConvert.SerializeObject(existingProduct));
                    }
                    MessageBox.Show("Cập nhật sản phẩm thành công!");
                }
                else {
                    MessageBox.Show("Không tìm thấy sản phẩm để cập nhật!");
                }
            }
        }
        private void LoadProducts()
        {
            using (var context = new LorKingDomManagementContext()) {
                var productList = context.Products.ToList(); // Tối ưu truy vấn
                products = new ObservableCollection<Product>(productList);
                OnPropertyChanged(nameof(products));
            }
        }

        private void LoadCategory()
        {
            using (var context = new LorKingDomManagementContext()) {
                categories = new ObservableCollection<Category>(context.Categories.ToList());
                OnPropertyChanged(nameof(categories));
            }
        }
        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
                if (_selectedCategory != null && TextBoxItem != null) {
                    // Chuyển đổi kiểu dữ liệu nếu cần
                    TextBoxItem.CategoryId = _selectedCategory.CategoryId; // Đảm bảo kiểu dữ liệu khớp
                }
            }
        }

        private Product _textBoxItem;
        public Product TextBoxItem
        {
            get { return _textBoxItem; }
            set
            {
                _textBoxItem = value;
                if (_textBoxItem != null && categories != null) {
                    SelectedCategory = categories.FirstOrDefault(c => c.CategoryId == _textBoxItem.CategoryId);
                }
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
                    //MessageBox.Show(TextBoxItem.CategoryId.ToString());
                }
                else {
                    categories = null;
                }
            }
        }

        // Thêm thuộc tính SearchText để hỗ trợ tìm kiếm
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }
    }
}