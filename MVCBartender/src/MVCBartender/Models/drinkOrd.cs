using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MVCBartender.Models
{

    public class drinkOrd
    {

        
               
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int drinkOrdID { get; set; }


        [Display(Name = "drinkInv")]
        public int Id { get; set; }
        
        [ForeignKey("Id")]
        public virtual drinkInv drinkInvs { get; set; }


        public int drinkQuant { get; set; }
        public decimal totalPrice { get; set; }
        public bool? orderComplete { get; set; }

    }
}
