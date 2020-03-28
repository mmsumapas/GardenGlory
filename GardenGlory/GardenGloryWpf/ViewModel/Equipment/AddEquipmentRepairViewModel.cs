using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using GardenGlory.Context;
using GardenGlory.DefaultValueGenerator;
using GardenGlory.EfClasses;
using ServiceLayer;

namespace GardenGloryWpf.ViewModel.Equipment
{
    public class AddEquipmentRepairViewModel
    {
        public EquipmentViewModel AssociatedEquipmentViewModel { get; set; }
        private EquipmentRepairService _equipmentRepairService { get;  }

        public AddEquipmentRepairViewModel(EquipmentViewModel equipmentViewModel, EquipmentRepairService equipmentRepairService)
        {
            AssociatedEquipmentViewModel = equipmentViewModel;
            _equipmentRepairService = equipmentRepairService;

        }

        public string Add()
        {
            var equipmentRepair = new EquipmentRepair();
            if (DateOfRepair == null || Amount == null || Remarks == null)
            {
                return "Error";
            }
            var amountChecker = Amount.Any(c => char.IsLetter(c));
            if (amountChecker != true)
            {
                equipmentRepair.EquipmentRepairId = new EquipmentRepairDefaultValueGenerator(new GardenGloryContext()).EquipmentRepairPrimaryKeyGenerator();
                equipmentRepair.EquipmentId = AssociatedEquipmentViewModel.EquipmentId;
                var dateOfRepairSplit = DateOfRepair.Split(new char[]{'/', ' '});
                DateOfRepair = $"{dateOfRepairSplit[0]}/{dateOfRepairSplit[1]}/{dateOfRepairSplit[2]}";
                equipmentRepair.DateOfRepair = new DateTime(Convert.ToInt32(dateOfRepairSplit[2]), Convert.ToInt32(dateOfRepairSplit[0]), Convert.ToInt32(dateOfRepairSplit[1]));
                equipmentRepair.Amount = Convert.ToDouble(Amount);
                equipmentRepair.Remarks = Remarks;

                _equipmentRepairService.AddEquipmentRepair(equipmentRepair);
                AssociatedEquipmentViewModel.EquipmentRepairDetailList.Add(new EquipmentRepairDetail(equipmentRepair));

                return "New Equipment Repair detail is added successfully!";
            }
            else
            {
                return "Error";
            }


        }
        public string DateOfRepair { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }


    }
}
