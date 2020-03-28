using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GardenGlory.EfClasses;
using ServiceLayer;

namespace GardenGloryWpf.CmbViewModel
{
    public class OwnerCmbViewModel
    {
        private string _searchOwnerText;
        private OwnerService _ownerService;

        public OwnerCmbViewModel(OwnerService ownerService)
        {
            _ownerService = ownerService;
            Owners = new ObservableCollection<Owner>(_ownerService.GetOwners());
        }

        public void SearchOwner(string searchText)
        {
            var owners = _ownerService.GetOwners().Where(c => c.OwnerName.Contains(searchText));
            Owners.Clear();
            foreach (var owner in owners)
            {
                Owners.Add(owner);
            }
        }

        public string SearchOwnerText
        {
            get => _searchOwnerText;
            set
            {
                _searchOwnerText = value;
                if (_searchOwnerText == null)
                {
                    _searchOwnerText = "";
                    SearchOwner(_searchOwnerText);
                }
                else
                {
                    SearchOwner(_searchOwnerText);
                }
            }
        }
        public ObservableCollection<Owner> Owners { get; set; }
        public Owner SelectedOwner { get; set; }
    }
}
