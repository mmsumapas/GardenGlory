using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GardenGlory.EfClasses;
using GardenGloryWpf.ViewModel.Equipment;
using ServiceLayer;

namespace GardenGloryWpf.CmbViewModel
{
    public class EquipmentCmbViewModel
    {
        private string _seachEquipmentNameText;
        private EquipmentService _equipmentService;
        public EquipmentViewModel AssociatedEquipmentViewModel { get; }

        public EquipmentCmbViewModel(EquipmentViewModel equipmentViewModel,EquipmentService equipmentService)
        {
            AssociatedEquipmentViewModel = equipmentViewModel;
            _equipmentService = equipmentService;
            Equipments = new ObservableCollection<Equipment>(_equipmentService.GetEquipments());
            SelectedEquipment = Equipments.First(c => c.EquipmentId == AssociatedEquipmentViewModel.EquipmentId);
        }

        public EquipmentCmbViewModel( EquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
            Equipments = new ObservableCollection<Equipment>(_equipmentService.GetEquipments());
        }

        public string SearchEquipmentText
        {
            get => _seachEquipmentNameText;
            set
            {
                _seachEquipmentNameText = value;
                if (_seachEquipmentNameText == null)
                {
                    _seachEquipmentNameText = "";
                    SearchEquipment(_seachEquipmentNameText);
                }
                else
                {
                    SearchEquipment(_seachEquipmentNameText);
                }
            }
        }
        public void SearchEquipment(string searchText)
        {
            var equipments = _equipmentService.GetEquipments().Where(c => c.EquipmentName.Contains(searchText));
            Equipments.Clear();
            foreach (var equipment in equipments)
            {
                Equipments.Add(equipment);
            }
        }
        public ObservableCollection<Equipment> Equipments { get; set; }
        public Equipment SelectedEquipment { get; set; }
    }
}
