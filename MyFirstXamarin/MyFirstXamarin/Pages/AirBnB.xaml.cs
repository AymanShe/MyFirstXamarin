using MyFirstXamarin.Models;
using MyFirstXamarin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFirstXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AirBnB : ContentPage
    {
        private readonly SearchService _service;
        private List<SearchGroup> _searchGroupList;
        public string Keywords { get; set; }
        public AirBnB()
        {
            _service = new SearchService();

            InitializeComponent();

            var searchesList = _service.GetSearches();
            PopulateList(searchesList);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Keywords = e.NewTextValue;
            var searchesList = _service.GetSearches(Keywords);
            PopulateList(searchesList);
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var clickedItem = sender as MenuItem;
            var searchObject = clickedItem.CommandParameter as Search;
            _searchGroupList[0].Remove(searchObject);
            _service.DeleteSearch(searchObject.Id);
        }

        private void Lv_search_list_Refreshing(object sender, EventArgs e)
        {
            var searchesList = _service.GetSearches(Keywords);
            PopulateList(searchesList);
            lv_search_list.EndRefresh();
        }

        private void PopulateList(IEnumerable<Search> searches)
        {
            _searchGroupList = new List<SearchGroup>
            {
                new SearchGroup("Recent Searches")
            };
            foreach (var item in searches)
            {
                _searchGroupList[0].Add(item);
            }

            lv_search_list.ItemsSource = _searchGroupList;
        }

        private void Lv_search_list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as Search;
            DisplayAlert("Locaiton", selectedItem.Location, "Ok");
            lv_search_list.SelectedItem = null;
        }
    }
}