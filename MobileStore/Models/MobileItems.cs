using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public class MobileItems
    {

        public int MobileItemsId { get; set; }

        public string MobileName { get; set; }

        public int MobilePrice { get; set; }

        public List<AccessoryItems> AccessoryItems { get; set; }
    }

    

}
