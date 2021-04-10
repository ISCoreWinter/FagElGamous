using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class BiologicalSamples
    {
        public BiologicalSamples()
        {
            CarbonDating = new HashSet<CarbonDating>();
        }

        public int BioSampleId { get; set; }
        public int BurialId { get; set; }
        public int? RackNumber { get; set; }
        public int? BagNimber { get; set; }
        public int? ClusterNumber { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }
        public int? Year { get; set; }
        public bool? PreviouslySampled { get; set; }
        public string Notes { get; set; }
        public string Initials { get; set; }

        public virtual BurialRecords Burial { get; set; }
        public virtual ICollection<CarbonDating> CarbonDating { get; set; }
    }
}
