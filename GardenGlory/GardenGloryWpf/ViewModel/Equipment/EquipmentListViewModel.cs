using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGloryWpf.ViewModel.Customer;
using ServiceLayer;

namespace GardenGloryWpf.ViewModel.Equipment
{
    public class EquipmentListViewModel
    {
        private EquipmentService _equipmentService;
        private string _searchText;

        public EquipmentListViewModel(EquipmentService equipmentService)
        {
            var context = new GardenGloryContext();
            _equipmentService = equipmentService;
            EquipmentList = new ObservableCollection<EquipmentViewModel>(_equipmentService.GetEquipments().Select(c =>
                    new EquipmentViewModel(c, new EquipmentRepairService(context), new TrainedEmployeeService(context), new EquipmentUsageService(context)  )));
                
        }

        public void SearchEquipment(string searchString)
        {
            EquipmentList.Clear();
            var equipments = _equipmentService.GetEquipments().Where(c =>
                c.EquipmentName.Contains(searchString) || c.EquipmentId.Contains(SearchText));
            var context = new GardenGloryContext();
            foreach (var equipment in equipments)
            {
                var equipmentModel = new EquipmentViewModel(equipment, new EquipmentRepairService(context), new TrainedEmployeeService(context), new EquipmentUsageService(context)  );
                EquipmentList.Add(equipmentModel);
            }
        }
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchEquipment(_searchText);
            }
        }


        public ObservableCollection<EquipmentViewModel> EquipmentList { get; }
        public EquipmentViewModel SelectedEquipment { get; set; }
    }
}
