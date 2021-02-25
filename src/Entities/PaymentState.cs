using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace filedChallenge.Entities
{
    public class PaymentState
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public string PaymentStatus {get; set;}  
        public List<Payment> Payment {get; set;}
    }
}