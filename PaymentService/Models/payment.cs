using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Models
{
    
        public class Payment
        {
            [Key]
            public long Payment_Id { get; set; }
            public long User_Id { get; set; }
            public long Mentor_Id { get; set; }
            [Required]
            public double Payment_Amount { get; set; }
            [Required]
            public string Skill_Name { get; set; }
            [Required]
            public double Mentor_Amount { get; set; }

        }
    
}
