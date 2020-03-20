using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lampu.Entities
{
    public class Lampu
    {
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id Lampu")]
        public Guid IdLampu { set; get; }

        [Required]
        [Display(Name = "Name Lampu")]
        [StringLength(7, MinimumLength =5)]
        public string NamaLampu { set; get; }

        [Required]
        [Display(Name = "Stock Lampu")]
        public int StockLampu { set; get; }
    }
}
