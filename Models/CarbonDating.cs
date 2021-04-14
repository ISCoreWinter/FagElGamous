using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class CarbonDating
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarbonDatingId { get; set; }
        public int BurialId { get; set; }
        public int? BioSampleId { get; set; }
        public int? RackNumber { get; set; }
        public int? TubeNumber { get; set; }
        public string Description { get; set; }
        public int? SizeMl { get; set; }
        public int? Foci { get; set; }
        public int? C14Sample2017 { get; set; }
        public string LocationDescription { get; set; }
        public string ResearchQuestions { get; set; }
        public int? Conventional14cAgeBp { get; set; }
        public int? _14cCalendarDate { get; set; }
        public int? Calibrated95CalendarDateMax { get; set; }
        public int? Calibrated95CalendarDateMin { get; set; }
        public int? Calibrated95CalendarDateSpan { get; set; }
        public double? Calibrated95CalendarDateAvg { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }

        public virtual BiologicalSamples BioSample { get; set; }
        public virtual BurialRecords Burial { get; set; }
    }
}
