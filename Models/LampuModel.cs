using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz1_Elsya_A.T.Model
{
    public class LampuModel
    {
        /// <summary>
        /// IdLampu merupakan primary key
        /// </summary>
        public Guid IdLampu { set; get; }

        /// <summary>
        /// Nama lampu 
        /// </summary>
        [Required]
        [Display(Name = "Nama Lampu")]
        [StringLength(7, MinimumLength = 5)]
        public string NamaLampu { set; get; }

        /// <summary>
        /// Stock Lampu
        /// </summary>
        [Required]
        [Display(Name = "Stock Lampu")]
        public int StockLampu { set; get; }
    }
}
