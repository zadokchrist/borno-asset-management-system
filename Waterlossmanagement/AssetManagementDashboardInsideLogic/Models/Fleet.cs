using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementDashboardInsideLogic.Models
{
    public class Fleet
    {
        public string RecordId { get; set; }
        public string CarType { get; set; }
        public string Model { get; set; }
        public string Driver { get; set; }
        public string LocationOfDuty { get; set; }
        public string FuelAllocation { get; set; }
        public string MaintainaceSchedule { get; set; }
        public string InsuranceType { get; set; }
        public string InsuranceExpiry { get; set; }
    }
}
