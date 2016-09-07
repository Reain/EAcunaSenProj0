using System;
using System.Collections.Generic;


namespace MVCBartender.Models
{
    public class drinkInv
    {
        public int ID { get; set; }
        public string DrinkName { get; set; }
        public string DrinkDesc { get; set; }
        public decimal DrinkPrice { get; set; }


       // public virtual ICollection<DrinkOrder> Orders { get; set; }



    }




}
