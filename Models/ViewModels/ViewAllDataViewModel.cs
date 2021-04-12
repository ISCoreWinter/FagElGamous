using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.ViewModels
{
    public class ViewAllDataViewModel
    {
        public BurialRecords BurialRecord { get; set; }

        public IEnumerable<BiologicalSamples> BioSamples { get; set; }
        public IEnumerable<Photos> Photos { get; set; }
        public BodyMeasurements BodyMeasurements { get; set; }
        public CarbonDating CarbonDating { get; set; }
        public Cranial Cranial { get; set; }
        public MainEntries MainEntries { get; set; }
    }
}
