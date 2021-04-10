using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class BurialRecords
    {
        public BurialRecords()
        {
            BiologicalSamples = new HashSet<BiologicalSamples>();
            BodyMeasurements = new HashSet<BodyMeasurements>();
            CarbonDating = new HashSet<CarbonDating>();
            Cranial = new HashSet<Cranial>();
            MainEntries = new HashSet<MainEntries>();
            Photos = new HashSet<Photos>();
        }

        public int BurialId { get; set; }
        public string LowPairNs { get; set; }
        public int? HighPairNs { get; set; }
        public string BurialLocationNs { get; set; }
        public int? LowPairEw { get; set; }
        public int? HighPairEw { get; set; }
        public string BurialLocationEw { get; set; }
        public string BurialSubplot { get; set; }
        public int? Area { get; set; }
        public string BurialNumber { get; set; }

        public virtual ICollection<BiologicalSamples> BiologicalSamples { get; set; }
        public virtual ICollection<BodyMeasurements> BodyMeasurements { get; set; }
        public virtual ICollection<CarbonDating> CarbonDating { get; set; }
        public virtual ICollection<Cranial> Cranial { get; set; }
        public virtual ICollection<MainEntries> MainEntries { get; set; }
        public virtual ICollection<Photos> Photos { get; set; }
    }
}
