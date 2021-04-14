using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.SearchModel
{
    //model made with the attributes that the data will be filtered by
    public class BurialSearchModel
    {
        public int? BurialId { get; set; }
        public int? HighPairNs { get; set; }
        public int? HighPairEw { get; set; }
        public string BurialNumber { get; set; }
        public string LowPairNs { get; set; }
        public string BurialLocationNs { get; set; }
        public string BurialLocationEw { get; set; }
        public string BurialSubplot { get; set; }
        public int? LowPairEw { get; set; }
        public int? Area { get; set; }
    }
}
