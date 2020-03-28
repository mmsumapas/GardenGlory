using System;
using System.Collections.Generic;
using System.Text;

namespace GardenGlory.EfClasses
{
    public class Service
    {
        public string ServiceId { get; set; }
        public string PropertyId { get; set; }
        public string ServiceTypeId { get; set; }
        public DateTime RequestDate { get; set; }
        public string ServiceRequest { get; set; }
        public bool IsDeleted { get; set; }
        
        //Relation 
        public Property PropertyLink { get; set; }
        public ServiceType ServiceTypeLink { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
