using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
using CountryVisitorApp.Commands;
using CountryVisitorApp.Models;
using System.Collections.ObjectModel;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CountryVisitorApp.ViewModels
{
    public class CountryViewModel : INotifyPropertyChanged
    {
        private ICountryVisitor countryVisitor;

        private string _newCountryName = string.Empty;

        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public string NewCountryName
        {
            get { return _newCountryName; }
            set
            {
                if (value != _newCountryName)
                {
                    _newCountryName = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Country> Countries { get; set; }

        public CountryViewModel()
        {
            countryVisitor = new CountryVisitor();
            Countries = countryVisitor.GetAllCountries();

            AddCommand = new CustomCommand(AddCountry);
            DeleteCommand = new CustomCommand(DeleteCountry);
        }

        private void AddCountry()
        {
            countryVisitor.AddCountry(new Country() { Name = NewCountryName });
            NewCountryName = string.Empty;
        }

        private void DeleteCountry()
        {
            countryVisitor.RemoveCountry(NewCountryName);
            NewCountryName = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
