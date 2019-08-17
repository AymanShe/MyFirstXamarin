using MyFirstXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MyFirstXamarin.Services
{
    class SearchService
    {
        private ObservableCollection<Search> _searches = new ObservableCollection<Search>
        {
            new Search
            {
                Id = 1,
                Location = "Montreal",
                CheckIn = new DateTime(2019, 9, 29),
                CheckOut = new DateTime(2019, 10, 3)
            },
            new Search
            {
                Id = 2,
                Location = "New York",
                CheckIn = new DateTime(2019, 10, 3),
                CheckOut = new DateTime(2019, 10, 15)
            },
            new Search
            {
                Id = 3,
                Location = "Los Angeles",
                CheckIn = new DateTime(2019, 10, 15),
                CheckOut = new DateTime(2019, 10, 22)
            }
        };


        public IEnumerable<Search> GetSearches(string filter = null)
        {
            if (String.IsNullOrWhiteSpace(filter))
            {
                return _searches;
            }
            return _searches.Where(x=>x.Location.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase));
        }

        internal void DeleteSearch(int id)
        {
            _searches.Remove(_searches.Single(x=> x.Id == id));
        }
    }
}
