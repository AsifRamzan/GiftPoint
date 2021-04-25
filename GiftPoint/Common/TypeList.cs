using GiftPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GiftPoint.Common
{
    public class TargetDetailList
    {
        [XmlElement("clsTargetDetail")]
        public List<clsTargetDetail> targets { get; set; }
    }

    public class clsTargetDetail
    {
        public string TargetDetailId { get; set; }
        public string DistributorId { get; set; }
        public string RouteId { get; set; }
        public string BrandPackingId { get; set; }
        public string Quantity { get; set; }
    }
}
