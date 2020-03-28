using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using GardenGlory.EfClasses;
using ServiceLayer;

namespace GardenGloryWpf.CmbViewModel
{
    public class OwnerTypeCmbViewModel
    {
        private string _searchOwnerTypeText;
        private OwnerTypeService _ownerTypeService;
        public CustomerViewModel AssociatedCustomerViewModel { get; }
        public OwnerTypeCmbViewModel(CustomerViewModel customerViewModel, OwnerTypeService ownerTypeService)
        {
            AssociatedCustomerViewModel = customerViewModel;
            _ownerTypeService = ownerTypeService;
            OwnerTypes = new ObservableCollection<OwnerType>(_ownerTypeService.GetOwnerTypes());
            SelectedOwnerType = OwnerTypes.First(c => c.OwnerTypeId == AssociatedCustomerViewModel.OwnerTypeId);
        }

        public OwnerTypeCmbViewModel( OwnerTypeService ownerTypeService)
        {

            _ownerTypeService = ownerTypeService;
            OwnerTypes = new ObservableCollection<OwnerType>(_ownerTypeService.GetOwnerTypes());
        }
        public string SearchOwnerTypeText
        {
            get => _searchOwnerTypeText;
            set
            {
                _searchOwnerTypeText= value;
                if (_searchOwnerTypeText == null)
                {
                    _searchOwnerTypeText = "";
                    SearchOwnerType(_searchOwnerTypeText);
                }
                else
                {
                    SearchOwnerType(_searchOwnerTypeText);
                }
            }

        }
        public void SearchOwnerType(string searchText)
        {
            var ownerTypes = _ownerTypeService.GetOwnerTypes().Where(c => c.Type.Contains(searchText) );
            OwnerTypes.Clear();
            foreach (var ownerType in ownerTypes)
            {
                OwnerTypes.Add(ownerType);
            }
        }

        public ObservableCollection<OwnerType> OwnerTypes { get; set; }
        public OwnerType SelectedOwnerType { get; set; }
    }
}
