using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KenJP2._0.Data
{
    public class Dinosaurs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }


        [Display(Name = "Food Type")]
        public string Diet { get; set; }

        public string Territory { get; set; }

        public int EID { get; set; }

        [ForeignKey("EID")]
        public Exhibits ExhibitID { get; set; }
    }
}
