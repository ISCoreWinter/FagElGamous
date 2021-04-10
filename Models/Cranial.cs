using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class Cranial
    {
        public int EntryId { get; set; }
        public int BurialId { get; set; }
        public int? SampleNumber { get; set; }
        public double? MaximumCranialLength { get; set; }
        public double? MaximumCranialBreadth { get; set; }
        public double? BasionBregmaHeight { get; set; }
        public double? BasionNasion { get; set; }
        public double? BasionProsthionLength { get; set; }
        public double? BizygomaticDiameter { get; set; }
        public double? NasionProsthion { get; set; }
        public double? MaximumNasalBreadth { get; set; }
        public double? InterorbitalBreadth { get; set; }
        public int? SupraorbitalRidges { get; set; }
        public int? OrbitEdge { get; set; }
        public int? ParietalBossing { get; set; }
        public int? Gonian { get; set; }
        public int? NuchalCrest { get; set; }
        public int? ZygomaticCrest { get; set; }
        public string CranialSuture { get; set; }
        public string BasilarSuture { get; set; }
        public string ForemanMagnum { get; set; }
        public string ToothAttrition { get; set; }
        public string ToothEruption { get; set; }
        public string SkullTrauma { get; set; }
        public string PostcraniaTrauma { get; set; }
        public string CribraOrbitala { get; set; }
        public string PoroticHyperostosis { get; set; }
        public string PoroticHyperostosisLocations { get; set; }
        public string MetopicSuture { get; set; }
        public string ButtonOsteoma { get; set; }
        public string TemporalMandibularJointOsteoarthritisTmjoa { get; set; }
        public string LinearHypoplasiaEnamel { get; set; }
        public int? SkullYear { get; set; }
        public int? SkullMonth { get; set; }
        public int? SkullDate { get; set; }
        public int? Robust { get; set; }

        public virtual BurialRecords Burial { get; set; }
        public virtual MainEntries Entry { get; set; }
    }
}
