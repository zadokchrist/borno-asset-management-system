using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementDashboardInsideLogic.Models
{
    public class HardWareStock
    {
        public string id { get; set; }
        public string hw_name { get; set; }
        public string qty { get; set; }
        public string avbl_qty { get; set; }
        public string vid { get; set; }
        public string dop { get; set; }
        public string price { get; set; }
        public string cid { get; set; }
    }
}
