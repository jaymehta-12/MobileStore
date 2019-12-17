using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    

    public class AccessoryItems
    {   
        public int AccessoryItemsId { get; set; }
        public string AccessoryName { get; set; }

        public int AccessoryPrice { get; set; }

        public int MobileItemsId { get; set; }

        


    }
}
