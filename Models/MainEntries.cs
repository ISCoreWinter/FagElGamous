using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class MainEntries
    {
        public MainEntries()
        {
            BodyMeasurements = new HashSet<BodyMeasurements>();
            Cranial = new HashSet<Cranial>();
        }

        public int EntryId { get; set; }
        public int BurialId { get; set; }
        public int? BodyAnalysisYear { get; set; }
        public int? YearExcavated { get; set; }
        public int? MonthExcavated { get; set; }
        public int? DayExcavated { get; set; }
        public string ArtifactsDescription { get; set; }
        public string DescriptionOfTaken { get; set; }
        public string OsteologyNotes { get; set; }
        public string BurialSituation { get; set; }
        public int? GamousId { get; set; }
        public string FieldBook { get; set; }
        public string FieldBookPgnumber { get; set; }
        public string DataEntryExpertInitials { get; set; }
        public string DataEntryCheckerInitials { get; set; }
        public string ByuSample { get; set; }
        public string RackNumber { get; set; }
        public string ShelfNumber { get; set; }
        public string Tomb { get; set; }
        public string Cluster { get; set; }
        public string BodySex { get; set; }
        public string GeSex { get; set; }
        public string SexMethod { get; set; }
        public string GeFunctionTotal { get; set; }
        public string AgeRangeAtDeath { get; set; }
        public string AgeEstimateAtDeath { get; set; }
        public string AgeMethod { get; set; }
        public string AgeCode { get; set; }
        public string AgeCodeSingle { get; set; }
        public string BurialPreservation { get; set; }
        public string BurialWrapping { get; set; }
        public string FaceBundle { get; set; }
        public string HairColorCode { get; set; }
        public string HairColor { get; set; }
        public string LengthM { get; set; }
        public string LengthCm { get; set; }
        public string SkullAtMagazine { get; set; }
        public string PostcraniaAtMagazine { get; set; }
        public string ToBeConfirmed { get; set; }
        public bool? OsteologyUnknownComment { get; set; }
        public string Goods { get; set; }
        public bool? HairTaken { get; set; }
        public bool? SoftTissueTaken { get; set; }
        public bool? BoneTaken { get; set; }
        public bool? ToothTaken { get; set; }
        public bool? TextileTaken { get; set; }
        public bool? ArtifactFound { get; set; }
        public string BurialSampleTaken { get; set; }
        public string BurialWestToHead { get; set; }
        public string BurialWestToFeet { get; set; }
        public string BurialSouthToHead { get; set; }
        public string BurialSouthToFeet { get; set; }
        public string EastToHead { get; set; }
        public string EastToFeet { get; set; }
        public string BurialDepth { get; set; }
        public string HeadDirection { get; set; }
        public string BurialDirection { get; set; }
        public string Notes1 { get; set; }
        public string Notes2 { get; set; }
        public string Notes3 { get; set; }
        public string Notes4 { get; set; }
        public string Notes5 { get; set; }
        public string Notes6 { get; set; }
        public string Notes7 { get; set; }
        public string Notes8 { get; set; }
        public string Notes9 { get; set; }
        public TimeSpan? TimeEntered { get; set; }
        public bool? InCluster { get; set; }
        public string ClusterNumber { get; set; }
        public string ShaftNumber { get; set; }
        public string SharedShaft { get; set; }
        public string ExcavationRecorderFirstName { get; set; }
        public string ExcavationRecorderMiddleName { get; set; }
        public string ExcavationRecorderLastName { get; set; }

        public virtual BurialRecords Burial { get; set; }
        public virtual ICollection<BodyMeasurements> BodyMeasurements { get; set; }
        public virtual ICollection<Cranial> Cranial { get; set; }
    }
}
