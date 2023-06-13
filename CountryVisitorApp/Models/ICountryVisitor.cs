using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace CountryVisitorApp.Models
{
    public interface ICountryVisitor
    {
        ObservableCollection<Country> GetAllCountries();
        void AddCountry(Country country);
        void RemoveCountry(string countryName);
    }
}

