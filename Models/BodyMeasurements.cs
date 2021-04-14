using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class BodyMeasurements
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntryId { get; set; }
        public int BurialId { get; set; }
        public int? VentralArc { get; set; }
        public int? SubpubicAngle { get; set; }
        public int? SciaticNotch { get; set; }
        public int? PubicBone { get; set; }
        public int? PreaurSulcus { get; set; }
        public int? MedicalIpRamus { get; set; }
        public int? DorsalPitting { get; set; }
        public double? FemurHead { get; set; }
        public double? HumerusHead { get; set; }
        public string PubicSymphysis { get; set; }
        public string BoneLength { get; set; }
        public string MedicalClavicle { get; set; }
        public string IliacCrest { get; set; }
        public string FemurDiameter { get; set; }
        public string Humerus { get; set; }
        public double? FemurLength { get; set; }
        public double? HumerusLength { get; set; }
        public double? TibiaLength { get; set; }
        public string PreservationIndex { get; set; }
        public double? EstimateLivingStature { get; set; }
        public string PathologyAnomalies { get; set; }
        public string EpiphysealUnion { get; set; }
        public string Osteophytosis { get; set; }

        public virtual BurialRecords Burial { get; set; }
        public virtual MainEntries Entry { get; set; }
    }
}
