using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.SearchModel
{
    public class BurialSearchModel
    {
        public int? BurialId { get; set; }
        public int? YearExcavated { get; set; }
        public string AgeEstimatedAtDeath { get; set; }
        public string HairColor { get; set; }
        public string Sex { get; set; }
        public string BurialSubplot { get; set; }
        public string Goods { get; set; }
        public string BurialDirection { get; set; }
    }
}
