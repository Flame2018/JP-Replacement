using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KenJP2._0.Data
{
    public class Exhibits
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EID { get; set; }

        [Display(Name ="Exhibit Name")]
        public string Ename { get; set; }

        [Display(Name = "Capacity")]
        public int Cap { get; set; }
    }
}
