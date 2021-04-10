using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamous.Models
{
    public partial class fagelgamousContext : DbContext
    {
        public fagelgamousContext()
        {
        }

        public fagelgamousContext(DbContextOptions<fagelgamousContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BiologicalSamples> BiologicalSamples { get; set; }
        public virtual DbSet<BodyMeasurements> BodyMeasurements { get; set; }
        public virtual DbSet<BurialRecords> BurialRecords { get; set; }
        public virtual DbSet<CarbonDating> CarbonDating { get; set; }
        public virtual DbSet<Cranial> Cranial { get; set; }
        public virtual DbSet<MainEntries> MainEntries { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = aaypiz7rjrueva.crds8ouljelx.us-east-1.rds.amazonaws.com,1433; Initial Catalog=fagelgamous;User Id=admin;password=byuFagel-Gamous2021");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BiologicalSamples>(entity =>
            {
                entity.HasKey(e => e.BioSampleId);

                entity.ToTable("Biological_Samples");

                entity.Property(e => e.BioSampleId)
                    .HasColumnName("bio_sample_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BagNimber).HasColumnName("bag_nimber");

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.ClusterNumber).HasColumnName("cluster_number");

                entity.Property(e => e.Day).HasColumnName("day");

                entity.Property(e => e.Initials)
                    .HasColumnName("initials")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .IsUnicode(false);

                entity.Property(e => e.PreviouslySampled).HasColumnName("previously_sampled");

                entity.Property(e => e.RackNumber).HasColumnName("rack_number");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.BiologicalSamples)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Biologica__buria__4F7CD00D");
            });

            modelBuilder.Entity<BodyMeasurements>(entity =>
            {
                entity.HasKey(e => new { e.EntryId, e.BurialId });

                entity.ToTable("Body_Measurements");

                entity.Property(e => e.EntryId).HasColumnName("entry_id");

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.BoneLength)
                    .HasColumnName("bone_length")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DorsalPitting).HasColumnName("dorsal_pitting");

                entity.Property(e => e.EpiphysealUnion)
                    .HasColumnName("epiphyseal_union")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstimateLivingStature).HasColumnName("estimate_living_stature");

                entity.Property(e => e.FemurDiameter)
                    .HasColumnName("femur_diameter")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FemurHead).HasColumnName("femur_head");

                entity.Property(e => e.FemurLength).HasColumnName("femur_length");

                entity.Property(e => e.Humerus)
                    .HasColumnName("humerus")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HumerusHead).HasColumnName("humerus_head");

                entity.Property(e => e.HumerusLength).HasColumnName("humerus_length");

                entity.Property(e => e.IliacCrest)
                    .HasColumnName("iliac_crest")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MedicalClavicle)
                    .HasColumnName("medical_clavicle")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MedicalIpRamus).HasColumnName("medical_IP_ramus");

                entity.Property(e => e.Osteophytosis)
                    .HasColumnName("osteophytosis")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PathologyAnomalies)
                    .HasColumnName("pathology_anomalies")
                    .IsUnicode(false);

                entity.Property(e => e.PreaurSulcus).HasColumnName("preaur_sulcus");

                entity.Property(e => e.PreservationIndex)
                    .HasColumnName("preservation_index")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PubicBone).HasColumnName("pubic_bone");

                entity.Property(e => e.PubicSymphysis)
                    .HasColumnName("pubic_symphysis")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SciaticNotch).HasColumnName("sciatic_notch");

                entity.Property(e => e.SubpubicAngle).HasColumnName("subpubic_angle");

                entity.Property(e => e.TibiaLength).HasColumnName("tibia_length");

                entity.Property(e => e.VentralArc).HasColumnName("ventral_arc");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.BodyMeasurements)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Body_Meas__buria__4CA06362");

                entity.HasOne(d => d.Entry)
                    .WithMany(p => p.BodyMeasurements)
                    .HasForeignKey(d => d.EntryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Body_Meas__entry__4BAC3F29");
            });

            modelBuilder.Entity<BurialRecords>(entity =>
            {
                entity.HasKey(e => e.BurialId);

                entity.ToTable("Burial_Records");

                entity.Property(e => e.BurialId)
                    .HasColumnName("burial_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Area).HasColumnName("area");

                entity.Property(e => e.BurialLocationEw)
                    .HasColumnName("burial_location_EW")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BurialLocationNs)
                    .HasColumnName("burial_location_NS")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BurialNumber)
                    .HasColumnName("burial_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BurialSubplot)
                    .HasColumnName("burial_subplot")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.HighPairEw).HasColumnName("high_pair_EW");

                entity.Property(e => e.HighPairNs).HasColumnName("high_pair_NS");

                entity.Property(e => e.LowPairEw).HasColumnName("low_pair_EW");

                entity.Property(e => e.LowPairNs)
                    .HasColumnName("low_pair_NS")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CarbonDating>(entity =>
            {
                entity.ToTable("Carbon_Dating");

                entity.Property(e => e.CarbonDatingId)
                    .HasColumnName("carbon_dating_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BioSampleId).HasColumnName("bio_sample_id");

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.C14Sample2017).HasColumnName("C14_Sample_2017");

                entity.Property(e => e.Calibrated95CalendarDateAvg).HasColumnName("calibrated_95_calendar_date_AVG");

                entity.Property(e => e.Calibrated95CalendarDateMax).HasColumnName("calibrated_95_calendar_date_max");

                entity.Property(e => e.Calibrated95CalendarDateMin).HasColumnName("calibrated_95_calendar_date_min");

                entity.Property(e => e.Calibrated95CalendarDateSpan).HasColumnName("calibrated_95_calendar_date_span");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .IsUnicode(false);

                entity.Property(e => e.Conventional14cAgeBp).HasColumnName("conventional_14C_age_BP");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Foci).HasColumnName("foci");

                entity.Property(e => e.LocationDescription)
                    .HasColumnName("location_description")
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .IsUnicode(false);

                entity.Property(e => e.RackNumber).HasColumnName("rack_number");

                entity.Property(e => e.ResearchQuestions)
                    .HasColumnName("research_questions")
                    .IsUnicode(false);

                entity.Property(e => e.SizeMl).HasColumnName("size_ml");

                entity.Property(e => e.TubeNumber).HasColumnName("tube_number");

                entity.Property(e => e._14cCalendarDate).HasColumnName("_14C_calendar_date");

                entity.HasOne(d => d.BioSample)
                    .WithMany(p => p.CarbonDating)
                    .HasForeignKey(d => d.BioSampleId)
                    .HasConstraintName("FK__Carbon_Da__bio_s__534D60F1");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.CarbonDating)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Carbon_Da__buria__52593CB8");
            });

            modelBuilder.Entity<Cranial>(entity =>
            {
                entity.HasKey(e => new { e.EntryId, e.BurialId });

                entity.Property(e => e.EntryId).HasColumnName("entry_id");

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.BasilarSuture)
                    .HasColumnName("basilar_suture")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BasionBregmaHeight).HasColumnName("basion_bregma_height");

                entity.Property(e => e.BasionNasion).HasColumnName("basion_nasion");

                entity.Property(e => e.BasionProsthionLength).HasColumnName("basion_prosthion_length");

                entity.Property(e => e.BizygomaticDiameter).HasColumnName("bizygomatic_diameter");

                entity.Property(e => e.ButtonOsteoma)
                    .HasColumnName("button_osteoma")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CranialSuture)
                    .HasColumnName("cranial_suture")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CribraOrbitala)
                    .HasColumnName("cribra_orbitala")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ForemanMagnum)
                    .HasColumnName("foreman_magnum")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gonian).HasColumnName("gonian");

                entity.Property(e => e.InterorbitalBreadth).HasColumnName("interorbital_breadth");

                entity.Property(e => e.LinearHypoplasiaEnamel)
                    .HasColumnName("linear_hypoplasia_enamel")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MaximumCranialBreadth).HasColumnName("maximum_cranial_breadth");

                entity.Property(e => e.MaximumCranialLength).HasColumnName("maximum_cranial_length");

                entity.Property(e => e.MaximumNasalBreadth).HasColumnName("maximum_nasal_breadth");

                entity.Property(e => e.MetopicSuture)
                    .HasColumnName("metopic_suture")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NasionProsthion).HasColumnName("nasion_prosthion");

                entity.Property(e => e.NuchalCrest).HasColumnName("nuchal_crest");

                entity.Property(e => e.OrbitEdge).HasColumnName("orbit_edge");

                entity.Property(e => e.ParietalBossing).HasColumnName("parietal_bossing");

                entity.Property(e => e.PoroticHyperostosis)
                    .HasColumnName("porotic_hyperostosis")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PoroticHyperostosisLocations)
                    .HasColumnName("porotic_hyperostosis_locations")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostcraniaTrauma)
                    .HasColumnName("postcrania_trauma")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Robust).HasColumnName("robust");

                entity.Property(e => e.SampleNumber).HasColumnName("sample_number");

                entity.Property(e => e.SkullDate).HasColumnName("skull_date");

                entity.Property(e => e.SkullMonth).HasColumnName("skull_month");

                entity.Property(e => e.SkullTrauma)
                    .HasColumnName("skull_trauma")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SkullYear).HasColumnName("skull_year");

                entity.Property(e => e.SupraorbitalRidges).HasColumnName("supraorbital_ridges");

                entity.Property(e => e.TemporalMandibularJointOsteoarthritisTmjoa)
                    .HasColumnName("temporal_mandibular_joint_osteoarthritis_TMJOA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ToothAttrition)
                    .HasColumnName("tooth_attrition")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToothEruption)
                    .HasColumnName("tooth_eruption")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZygomaticCrest).HasColumnName("zygomatic_crest");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.Cranial)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cranial__burial___47DBAE45");

                entity.HasOne(d => d.Entry)
                    .WithMany(p => p.Cranial)
                    .HasForeignKey(d => d.EntryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cranial__entry_i__48CFD27E");
            });

            modelBuilder.Entity<MainEntries>(entity =>
            {
                entity.HasKey(e => e.EntryId);

                entity.ToTable("Main_Entries");

                entity.Property(e => e.EntryId)
                    .HasColumnName("entry_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AgeCode)
                    .HasColumnName("age_code")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AgeCodeSingle)
                    .HasColumnName("Age_code_single")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AgeEstimateAtDeath)
                    .HasColumnName("age_estimate_at_death")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AgeMethod)
                    .HasColumnName("age_method")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AgeRangeAtDeath)
                    .HasColumnName("age_range_at_death")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ArtifactFound).HasColumnName("artifact_found");

                entity.Property(e => e.ArtifactsDescription)
                    .HasColumnName("artifacts_description")
                    .IsUnicode(false);

                entity.Property(e => e.BodyAnalysisYear).HasColumnName("body_analysis_year");

                entity.Property(e => e.BodySex)
                    .HasColumnName("body_sex")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BoneTaken).HasColumnName("bone_taken");

                entity.Property(e => e.BurialDepth)
                    .HasColumnName("burial_depth")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BurialDirection)
                    .HasColumnName("burial_direction")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.BurialPreservation)
                    .HasColumnName("burial_preservation")
                    .IsUnicode(false);

                entity.Property(e => e.BurialSampleTaken)
                    .HasColumnName("burial_sample_taken")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BurialSituation)
                    .HasColumnName("burial_situation")
                    .IsUnicode(false);

                entity.Property(e => e.BurialSouthToFeet)
                    .HasColumnName("burial_SouthToFeet")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BurialSouthToHead)
                    .HasColumnName("burial_SouthTo_Head")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BurialWestToFeet)
                    .HasColumnName("burial_WestToFeet")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BurialWestToHead)
                    .HasColumnName("burial_WestToHead")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BurialWrapping)
                    .HasColumnName("burial_wrapping")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ByuSample)
                    .HasColumnName("byu_sample")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Cluster)
                    .HasColumnName("cluster")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClusterNumber)
                    .HasColumnName("cluster_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataEntryCheckerInitials)
                    .HasColumnName("data_entry_checker_initials")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DataEntryExpertInitials)
                    .HasColumnName("data_entry_expert_initials")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DayExcavated).HasColumnName("day_excavated");

                entity.Property(e => e.DescriptionOfTaken)
                    .HasColumnName("description_of_taken")
                    .IsUnicode(false);

                entity.Property(e => e.EastToFeet)
                    .HasColumnName("east_to_feet")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EastToHead)
                    .HasColumnName("east_to_head")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExcavationRecorderFirstName)
                    .HasColumnName("excavation_recorder_first_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExcavationRecorderLastName)
                    .HasColumnName("excavation_recorder_last_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExcavationRecorderMiddleName)
                    .HasColumnName("excavation_recorder_middle_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FaceBundle)
                    .HasColumnName("face_bundle")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FieldBook)
                    .HasColumnName("field_book")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FieldBookPgnumber)
                    .HasColumnName("field_book_pgnumber")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GamousId).HasColumnName("gamous_id");

                entity.Property(e => e.GeFunctionTotal)
                    .HasColumnName("GE_function_total")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GeSex)
                    .HasColumnName("GE_sex")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Goods)
                    .HasColumnName("goods")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.HairColor)
                    .HasColumnName("hair_color")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HairColorCode)
                    .HasColumnName("hair_color_code")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.HairTaken).HasColumnName("hair_taken");

                entity.Property(e => e.HeadDirection)
                    .HasColumnName("head_direction")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.InCluster).HasColumnName("in_cluster");

                entity.Property(e => e.LengthCm)
                    .HasColumnName("length_CM")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LengthM)
                    .HasColumnName("length_M")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MonthExcavated).HasColumnName("month_excavated");

                entity.Property(e => e.Notes1)
                    .HasColumnName("notes_1")
                    .IsUnicode(false);

                entity.Property(e => e.Notes2)
                    .HasColumnName("notes_2")
                    .IsUnicode(false);

                entity.Property(e => e.Notes3)
                    .HasColumnName("notes_3")
                    .IsUnicode(false);

                entity.Property(e => e.Notes4)
                    .HasColumnName("notes_4")
                    .IsUnicode(false);

                entity.Property(e => e.Notes5)
                    .HasColumnName("notes_5")
                    .IsUnicode(false);

                entity.Property(e => e.Notes6)
                    .HasColumnName("notes_6")
                    .IsUnicode(false);

                entity.Property(e => e.Notes7)
                    .HasColumnName("notes_7")
                    .IsUnicode(false);

                entity.Property(e => e.Notes8)
                    .HasColumnName("notes_8")
                    .IsUnicode(false);

                entity.Property(e => e.Notes9)
                    .HasColumnName("notes_9")
                    .IsUnicode(false);

                entity.Property(e => e.OsteologyNotes)
                    .HasColumnName("osteology_notes")
                    .IsUnicode(false);

                entity.Property(e => e.OsteologyUnknownComment).HasColumnName("osteology_unknown_comment");

                entity.Property(e => e.PostcraniaAtMagazine)
                    .HasColumnName("postcrania_at_magazine")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RackNumber)
                    .HasColumnName("rack_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SexMethod)
                    .HasColumnName("sex_method")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ShaftNumber)
                    .HasColumnName("shaft_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SharedShaft)
                    .HasColumnName("shared_shaft")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ShelfNumber)
                    .HasColumnName("shelf_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SkullAtMagazine)
                    .HasColumnName("skull_at_magazine")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SoftTissueTaken).HasColumnName("soft_tissue_taken");

                entity.Property(e => e.TextileTaken).HasColumnName("textile_taken");

                entity.Property(e => e.TimeEntered).HasColumnName("time_entered");

                entity.Property(e => e.ToBeConfirmed)
                    .HasColumnName("to_be_confirmed")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Tomb)
                    .HasColumnName("tomb")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToothTaken).HasColumnName("tooth_taken");

                entity.Property(e => e.YearExcavated).HasColumnName("year_excavated");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.MainEntries)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Main_Entr__buria__44FF419A");
            });

            modelBuilder.Entity<Photos>(entity =>
            {
                entity.HasKey(e => e.PhotoId)
                    .HasName("PK__photos__CB48C83DDDE8113D");

                entity.ToTable("photos");

                entity.Property(e => e.PhotoId).HasColumnName("photo_id");

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Filestring)
                    .HasColumnName("filestring")
                    .IsUnicode(false);

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.BurialId)
                    .HasConstraintName("FK__photos__burial_i__5CD6CB2B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
