using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models.ViewModels
{
    public class InputViewModel
    {
        public BodyMeasurements bodyMeasurements { get; set; }
        public MainEntries mainEntry { get; set; }
        public BurialRecords burialRecords { get; set; }
    }
}
