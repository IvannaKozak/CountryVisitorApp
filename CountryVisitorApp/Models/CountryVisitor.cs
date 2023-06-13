using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace CountryVisitorApp.Models
{
    public class CountryVisitor : ICountryVisitor
    {
        private ObservableCollection<Country> countries;

        public CountryVisitor()
        {
            countries = new ObservableCollection<Country>();
        }

        public ObservableCollection<Country> GetAllCountries()
        {
            return countries;
        }

        public void AddCountry(Country country)
        {
            countries.Add(country);
        }

        public void RemoveCountry(string countryName)
        {
            var countryToRemove = countries.FirstOrDefault(c => c.Name == countryName);
            if (countryToRemove != null)
            {
                countries.Remove(countryToRemove);
            }
        }
    }
}
