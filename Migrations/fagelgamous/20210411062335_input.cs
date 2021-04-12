using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FagElGamous.Migrations.fagelgamous
{
    public partial class input : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burial_Records",
                columns: table => new
                {
                    burial_id = table.Column<int>(nullable: false),
                    low_pair_NS = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    high_pair_NS = table.Column<int>(nullable: true),
                    burial_location_NS = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    low_pair_EW = table.Column<int>(nullable: true),
                    high_pair_EW = table.Column<int>(nullable: true),
                    burial_location_EW = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    burial_subplot = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    area = table.Column<int>(nullable: true),
                    Photo = table.Column<bool>(nullable: true),
                    BuriedGoods = table.Column<bool>(nullable: true),
                    burial_number = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burial_Records", x => x.burial_id);
                });

            migrationBuilder.CreateTable(
                name: "Biological_Samples",
                columns: table => new
                {
                    bio_sample_id = table.Column<int>(nullable: false),
                    burial_id = table.Column<int>(nullable: false),
                    rack_number = table.Column<int>(nullable: true),
                    bag_nimber = table.Column<int>(nullable: true),
                    cluster_number = table.Column<int>(nullable: true),
                    month = table.Column<int>(nullable: true),
                    day = table.Column<int>(nullable: true),
                    year = table.Column<int>(nullable: true),
                    previously_sampled = table.Column<bool>(nullable: true),
                    notes = table.Column<string>(unicode: false, nullable: true),
                    initials = table.Column<string>(unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biological_Samples", x => x.bio_sample_id);
                    table.ForeignKey(
                        name: "FK__Biologica__buria__4F7CD00D",
                        column: x => x.burial_id,
                        principalTable: "Burial_Records",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Main_Entries",
                columns: table => new
                {
                    entry_id = table.Column<int>(nullable: false),
                    burial_id = table.Column<int>(nullable: false),
                    body_analysis_year = table.Column<int>(nullable: true),
                    year_excavated = table.Column<int>(nullable: true),
                    month_excavated = table.Column<int>(nullable: true),
                    day_excavated = table.Column<int>(nullable: true),
                    artifacts_description = table.Column<string>(unicode: false, nullable: true),
                    description_of_taken = table.Column<string>(unicode: false, nullable: true),
                    osteology_notes = table.Column<string>(unicode: false, nullable: true),
                    burial_situation = table.Column<string>(unicode: false, nullable: true),
                    gamous_id = table.Column<int>(nullable: true),
                    field_book = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    field_book_pgnumber = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    data_entry_expert_initials = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    data_entry_checker_initials = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    byu_sample = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    rack_number = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    shelf_number = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    tomb = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    cluster = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    body_sex = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    GE_sex = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    sex_method = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    GE_function_total = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    age_range_at_death = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    age_estimate_at_death = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    age_method = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    age_code = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    Age_code_single = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    burial_preservation = table.Column<string>(unicode: false, nullable: true),
                    burial_wrapping = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    face_bundle = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    hair_color_code = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    hair_color = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    length_M = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    length_CM = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    skull_at_magazine = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    postcrania_at_magazine = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    to_be_confirmed = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    osteology_unknown_comment = table.Column<bool>(nullable: true),
                    goods = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    hair_taken = table.Column<bool>(nullable: true),
                    soft_tissue_taken = table.Column<bool>(nullable: true),
                    bone_taken = table.Column<bool>(nullable: true),
                    tooth_taken = table.Column<bool>(nullable: true),
                    textile_taken = table.Column<bool>(nullable: true),
                    artifact_found = table.Column<bool>(nullable: true),
                    burial_sample_taken = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    burial_WestToHead = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    burial_WestToFeet = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    burial_SouthTo_Head = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    burial_SouthToFeet = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    east_to_head = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    east_to_feet = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    burial_depth = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    head_direction = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    burial_direction = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    notes_1 = table.Column<string>(unicode: false, nullable: true),
                    notes_2 = table.Column<string>(unicode: false, nullable: true),
                    notes_3 = table.Column<string>(unicode: false, nullable: true),
                    notes_4 = table.Column<string>(unicode: false, nullable: true),
                    notes_5 = table.Column<string>(unicode: false, nullable: true),
                    notes_6 = table.Column<string>(unicode: false, nullable: true),
                    notes_7 = table.Column<string>(unicode: false, nullable: true),
                    notes_8 = table.Column<string>(unicode: false, nullable: true),
                    notes_9 = table.Column<string>(unicode: false, nullable: true),
                    time_entered = table.Column<TimeSpan>(nullable: true),
                    in_cluster = table.Column<bool>(nullable: true),
                    cluster_number = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    shaft_number = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    shared_shaft = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    excavation_recorder_first_name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    excavation_recorder_middle_name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    excavation_recorder_last_name = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main_Entries", x => x.entry_id);
                    table.ForeignKey(
                        name: "FK__Main_Entr__buria__44FF419A",
                        column: x => x.burial_id,
                        principalTable: "Burial_Records",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "photos",
                columns: table => new
                {
                    photo_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(unicode: false, nullable: true),
                    filestring = table.Column<string>(unicode: false, nullable: true),
                    burial_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__photos__CB48C83DDDE8113D", x => x.photo_id);
                    table.ForeignKey(
                        name: "FK__photos__burial_i__5CD6CB2B",
                        column: x => x.burial_id,
                        principalTable: "Burial_Records",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carbon_Dating",
                columns: table => new
                {
                    carbon_dating_id = table.Column<int>(nullable: false),
                    burial_id = table.Column<int>(nullable: false),
                    bio_sample_id = table.Column<int>(nullable: true),
                    rack_number = table.Column<int>(nullable: true),
                    tube_number = table.Column<int>(nullable: true),
                    description = table.Column<string>(unicode: false, nullable: true),
                    size_ml = table.Column<int>(nullable: true),
                    foci = table.Column<int>(nullable: true),
                    C14_Sample_2017 = table.Column<int>(nullable: true),
                    location_description = table.Column<string>(unicode: false, nullable: true),
                    research_questions = table.Column<string>(unicode: false, nullable: true),
                    conventional_14C_age_BP = table.Column<int>(nullable: true),
                    _14C_calendar_date = table.Column<int>(nullable: true),
                    calibrated_95_calendar_date_max = table.Column<int>(nullable: true),
                    calibrated_95_calendar_date_min = table.Column<int>(nullable: true),
                    calibrated_95_calendar_date_span = table.Column<int>(nullable: true),
                    calibrated_95_calendar_date_AVG = table.Column<double>(nullable: true),
                    category = table.Column<string>(unicode: false, nullable: true),
                    notes = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carbon_Dating", x => x.carbon_dating_id);
                    table.ForeignKey(
                        name: "FK__Carbon_Da__bio_s__534D60F1",
                        column: x => x.bio_sample_id,
                        principalTable: "Biological_Samples",
                        principalColumn: "bio_sample_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Carbon_Da__buria__52593CB8",
                        column: x => x.burial_id,
                        principalTable: "Burial_Records",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Body_Measurements",
                columns: table => new
                {
                    entry_id = table.Column<int>(nullable: false),
                    burial_id = table.Column<int>(nullable: false),
                    ventral_arc = table.Column<int>(nullable: true),
                    subpubic_angle = table.Column<int>(nullable: true),
                    sciatic_notch = table.Column<int>(nullable: true),
                    pubic_bone = table.Column<int>(nullable: true),
                    preaur_sulcus = table.Column<int>(nullable: true),
                    medical_IP_ramus = table.Column<int>(nullable: true),
                    dorsal_pitting = table.Column<int>(nullable: true),
                    femur_head = table.Column<double>(nullable: true),
                    humerus_head = table.Column<double>(nullable: true),
                    pubic_symphysis = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    bone_length = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    medical_clavicle = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    iliac_crest = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    femur_diameter = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    humerus = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    femur_length = table.Column<double>(nullable: true),
                    humerus_length = table.Column<double>(nullable: true),
                    tibia_length = table.Column<double>(nullable: true),
                    preservation_index = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    estimate_living_stature = table.Column<double>(nullable: true),
                    pathology_anomalies = table.Column<string>(unicode: false, nullable: true),
                    epiphyseal_union = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    osteophytosis = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Body_Measurements", x => new { x.entry_id, x.burial_id });
                    table.ForeignKey(
                        name: "FK__Body_Meas__buria__4CA06362",
                        column: x => x.burial_id,
                        principalTable: "Burial_Records",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Body_Meas__entry__4BAC3F29",
                        column: x => x.entry_id,
                        principalTable: "Main_Entries",
                        principalColumn: "entry_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cranial",
                columns: table => new
                {
                    entry_id = table.Column<int>(nullable: false),
                    burial_id = table.Column<int>(nullable: false),
                    sample_number = table.Column<int>(nullable: true),
                    maximum_cranial_length = table.Column<double>(nullable: true),
                    maximum_cranial_breadth = table.Column<double>(nullable: true),
                    basion_bregma_height = table.Column<double>(nullable: true),
                    basion_nasion = table.Column<double>(nullable: true),
                    basion_prosthion_length = table.Column<double>(nullable: true),
                    bizygomatic_diameter = table.Column<double>(nullable: true),
                    nasion_prosthion = table.Column<double>(nullable: true),
                    maximum_nasal_breadth = table.Column<double>(nullable: true),
                    interorbital_breadth = table.Column<double>(nullable: true),
                    supraorbital_ridges = table.Column<int>(nullable: true),
                    orbit_edge = table.Column<int>(nullable: true),
                    parietal_bossing = table.Column<int>(nullable: true),
                    gonian = table.Column<int>(nullable: true),
                    nuchal_crest = table.Column<int>(nullable: true),
                    zygomatic_crest = table.Column<int>(nullable: true),
                    cranial_suture = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    basilar_suture = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    foreman_magnum = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    tooth_attrition = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    tooth_eruption = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    skull_trauma = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    postcrania_trauma = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    cribra_orbitala = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    porotic_hyperostosis = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    porotic_hyperostosis_locations = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    metopic_suture = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    button_osteoma = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    temporal_mandibular_joint_osteoarthritis_TMJOA = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    linear_hypoplasia_enamel = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    skull_year = table.Column<int>(nullable: true),
                    skull_month = table.Column<int>(nullable: true),
                    skull_date = table.Column<int>(nullable: true),
                    robust = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cranial", x => new { x.entry_id, x.burial_id });
                    table.ForeignKey(
                        name: "FK__Cranial__burial___47DBAE45",
                        column: x => x.burial_id,
                        principalTable: "Burial_Records",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Cranial__entry_i__48CFD27E",
                        column: x => x.entry_id,
                        principalTable: "Main_Entries",
                        principalColumn: "entry_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biological_Samples_burial_id",
                table: "Biological_Samples",
                column: "burial_id");

            migrationBuilder.CreateIndex(
                name: "IX_Body_Measurements_burial_id",
                table: "Body_Measurements",
                column: "burial_id");

            migrationBuilder.CreateIndex(
                name: "IX_Carbon_Dating_bio_sample_id",
                table: "Carbon_Dating",
                column: "bio_sample_id");

            migrationBuilder.CreateIndex(
                name: "IX_Carbon_Dating_burial_id",
                table: "Carbon_Dating",
                column: "burial_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cranial_burial_id",
                table: "Cranial",
                column: "burial_id");

            migrationBuilder.CreateIndex(
                name: "IX_Main_Entries_burial_id",
                table: "Main_Entries",
                column: "burial_id");

            migrationBuilder.CreateIndex(
                name: "IX_photos_burial_id",
                table: "photos",
                column: "burial_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Body_Measurements");

            migrationBuilder.DropTable(
                name: "Carbon_Dating");

            migrationBuilder.DropTable(
                name: "Cranial");

            migrationBuilder.DropTable(
                name: "photos");

            migrationBuilder.DropTable(
                name: "Biological_Samples");

            migrationBuilder.DropTable(
                name: "Main_Entries");

            migrationBuilder.DropTable(
                name: "Burial_Records");
        }
    }
}
