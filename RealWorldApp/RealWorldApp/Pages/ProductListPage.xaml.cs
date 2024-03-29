﻿using RealWorldApp.Models;
using RealWorldApp.Services;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealWorldApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductListPage : ContentPage
    {
        public ObservableCollection<ProductByCategory> ProductByCategoryCollection;
        public ProductListPage(int categoryId, string name)
        {
            InitializeComponent();
            ProductByCategoryCollection = new ObservableCollection<ProductByCategory>();
            LblCategoryName.Text = name;
            GetProducts(categoryId);
        }

        private async void GetProducts(int categoryId)
        {
            var products = await ApiService.GetProductByCategory(categoryId);
            foreach (var product in products)
            {
                ProductByCategoryCollection.Add(product);
            }
            CvProducts.ItemsSource = ProductByCategoryCollection;
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void CvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection =  e.CurrentSelection.FirstOrDefault() as ProductByCategory;
            if (currentSelection == null) return;
            await Navigation.PushModalAsync(new ProductDetailPage(currentSelection.id));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}