using System;
using System.Collections.Generic;
using System.Text;
using GardenGlory.Context;

namespace ServiceLayer.MultipleServices
{
    public class EmployeeExperienceLevelEmployeeStatusEmployeeTypeService
    {
        public EmployeeService EmployeeService { get; }
        public ExperienceLevelService ExperienceLevelService { get; }
        public EmployeeStatusService EmployeeStatusService { get; }
        public EmployeeTypeService EmployeeTypeService { get; }

        public EmployeeExperienceLevelEmployeeStatusEmployeeTypeService(GardenGloryContext context)
        {
            EmployeeService = new EmployeeService(context);
            ExperienceLevelService = new ExperienceLevelService(context);
            EmployeeStatusService = new EmployeeStatusService(context);
            EmployeeTypeService = new EmployeeTypeService(context);
        }
    }
}
