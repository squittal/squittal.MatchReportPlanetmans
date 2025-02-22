﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using squittal.MatchReportPlanetmans.Data;

namespace squittal.MatchReportPlanetmans.Migrations
{
    [DbContext(typeof(PlanetmansDbContext))]
    [Migration("20200609164520_AddConstructedTeamModels")]
    partial class AddConstructedTeamModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("squittal.ScrimPlanetmans.Data.Models.ConstructedTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConstructedTeam");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Data.Models.ConstructedTeamPlayerMembership", b =>
                {
                    b.Property<int>("ConstructedTeamId")
                        .HasColumnType("int");

                    b.Property<string>("CharacterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FactionId")
                        .HasColumnType("int");

                    b.HasKey("ConstructedTeamId", "CharacterId");

                    b.ToTable("ConstructedTeamPlayerMembership");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Data.Models.ScrimDeath", b =>
                {
                    b.Property<string>("ScrimMatchId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("AttackerCharacterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VictimCharacterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ActionType")
                        .HasColumnType("int");

                    b.Property<int>("AttackerFactionId")
                        .HasColumnType("int");

                    b.Property<bool>("AttackerIsOutfitless")
                        .HasColumnType("bit");

                    b.Property<int?>("AttackerLoadoutId")
                        .HasColumnType("int");

                    b.Property<string>("AttackerNameFull")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AttackerOutfitAlias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AttackerOutfitId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AttackerResultingNetScore")
                        .HasColumnType("int");

                    b.Property<int?>("AttackerResultingPoints")
                        .HasColumnType("int");

                    b.Property<int>("AttackerTeamOrdinal")
                        .HasColumnType("int");

                    b.Property<int?>("AttackerVehicleId")
                        .HasColumnType("int");

                    b.Property<int>("DeathType")
                        .HasColumnType("int");

                    b.Property<bool>("IsHeadshot")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsVehicleWeapon")
                        .HasColumnType("bit");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("ScrimMatchRound")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(-1);

                    b.Property<int>("VictimFactionId")
                        .HasColumnType("int");

                    b.Property<bool>("VictimIsOutfitless")
                        .HasColumnType("bit");

                    b.Property<int?>("VictimLoadoutId")
                        .HasColumnType("int");

                    b.Property<string>("VictimNameFull")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VictimOutfitAlias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VictimOutfitId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VictimResultingNetScore")
                        .HasColumnType("int");

                    b.Property<int?>("VictimResultingPoints")
                        .HasColumnType("int");

                    b.Property<int>("VictimTeamOrdinal")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponItemCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("WorldId")
                        .HasColumnType("int");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("ScrimMatchId", "Timestamp", "AttackerCharacterId", "VictimCharacterId");

                    b.ToTable("ScrimDeath");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Data.Models.ScrimMatch", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ScrimMatch");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Data.Models.ScrimMatchTeamPointAdjustment", b =>
                {
                    b.Property<string>("ScrimMatchId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TeamOrdinal")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("AdjustmentType")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Rationale")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScrimMatchId", "TeamOrdinal", "Timestamp");

                    b.ToTable("ScrimMatchTeamPointAdjustment");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Data.Models.ScrimMatchTeamResult", b =>
                {
                    b.Property<string>("ScrimMatchId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TeamOrdinal")
                        .HasColumnType("int");

                    b.Property<int>("BaseCaptures")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("BaseDefenses")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("DamageAssistedDeaths")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("DamageAssists")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Deaths")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("HeadshotDeaths")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Headshots")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Kills")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("NetScore")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("ObjectiveCaptureTicks")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("ObjectiveDefenseTicks")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Points")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("RevivesGiven")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("RevivesTaken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Suicides")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("TeamkillDeaths")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Teamkills")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("UtilityAssistedDeaths")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("UtilityAssists")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("ScrimMatchId", "TeamOrdinal");

                    b.ToTable("ScrimMatchTeamResult");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Data.Models.ScrimVehicleDestruction", b =>
                {
                    b.Property<string>("ScrimMatchId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("AttackerCharacterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VictimCharacterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("VictimVehicleId")
                        .HasColumnType("int");

                    b.Property<int>("ActionType")
                        .HasColumnType("int");

                    b.Property<int>("AttackerFactionId")
                        .HasColumnType("int");

                    b.Property<bool>("AttackerIsOutfitless")
                        .HasColumnType("bit");

                    b.Property<int?>("AttackerLoadoutId")
                        .HasColumnType("int");

                    b.Property<string>("AttackerNameFull")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AttackerOutfitAlias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AttackerOutfitId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AttackerResultingNetScore")
                        .HasColumnType("int");

                    b.Property<int?>("AttackerResultingPoints")
                        .HasColumnType("int");

                    b.Property<int>("AttackerTeamOrdinal")
                        .HasColumnType("int");

                    b.Property<int?>("AttackerVehicleClass")
                        .HasColumnType("int");

                    b.Property<int?>("AttackerVehicleId")
                        .HasColumnType("int");

                    b.Property<int>("DeathType")
                        .HasColumnType("int");

                    b.Property<bool?>("IsVehicleWeapon")
                        .HasColumnType("bit");

                    b.Property<int>("Points")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("ScrimMatchRound")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(-1);

                    b.Property<int>("VictimFactionId")
                        .HasColumnType("int");

                    b.Property<bool>("VictimIsOutfitless")
                        .HasColumnType("bit");

                    b.Property<int?>("VictimLoadoutId")
                        .HasColumnType("int");

                    b.Property<string>("VictimNameFull")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VictimOutfitAlias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VictimOutfitId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VictimResultingNetScore")
                        .HasColumnType("int");

                    b.Property<int?>("VictimResultingPoints")
                        .HasColumnType("int");

                    b.Property<int>("VictimTeamOrdinal")
                        .HasColumnType("int");

                    b.Property<int?>("VictimVehicleClass")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponItemCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("WorldId")
                        .HasColumnType("int");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("ScrimMatchId", "Timestamp", "AttackerCharacterId", "VictimCharacterId", "VictimVehicleId");

                    b.ToTable("ScrimVehicleDestruction");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Models.Planetside.FacilityType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FacilityType");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Models.Planetside.Faction", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CodeTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UserSelectable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Faction");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Models.Planetside.Item", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FactionId")
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<bool>("IsVehicleWeapon")
                        .HasColumnType("bit");

                    b.Property<int?>("ItemCategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("MaxStackSize")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Models.Planetside.ItemCategory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Domain")
                        .HasColumnType("int");

                    b.Property<bool>("IsWeaponCategory")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ItemCategory");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Models.Planetside.Loadout", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FactionId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Loadout");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Models.Planetside.MapRegion", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<string>("FacilityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacilityType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacilityTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("Id", "FacilityId");

                    b.ToTable("MapRegion");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Models.Planetside.Profile", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("FactionId")
                        .HasColumnType("int");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfileTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Models.Planetside.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("Cost")
                        .HasColumnType("int");

                    b.Property<int?>("CostResourceId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Models.Planetside.World", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("World");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Models.Planetside.Zone", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HexSize")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zone");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.ScrimMatch.Models.DeathType", b =>
                {
                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Type");

                    b.ToTable("DeathType");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.ScrimMatch.Models.Ruleset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsCustomDefault")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsDefault")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ruleset");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.ScrimMatch.Models.RulesetActionRule", b =>
                {
                    b.Property<int>("RulesetId")
                        .HasColumnType("int");

                    b.Property<int>("ScrimActionType")
                        .HasColumnType("int");

                    b.Property<bool>("DeferToItemCategoryRules")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Points")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("RulesetId", "ScrimActionType");

                    b.ToTable("RulesetActionRule");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.ScrimMatch.Models.RulesetItemCategoryRule", b =>
                {
                    b.Property<int>("RulesetId")
                        .HasColumnType("int");

                    b.Property<int>("ItemCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("RulesetId", "ItemCategoryId");

                    b.ToTable("RulesetItemCategoryRule");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.ScrimMatch.Models.ScrimAction", b =>
                {
                    b.Property<int>("Action")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Action");

                    b.ToTable("ScrimAction");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.ScrimMatch.Models.VehicleClass", b =>
                {
                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Class");

                    b.ToTable("VehicleClass");
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Data.Models.ConstructedTeamPlayerMembership", b =>
                {
                    b.HasOne("squittal.ScrimPlanetmans.Data.Models.ConstructedTeam", "ConstructedTeam")
                        .WithMany("PlayerMemberships")
                        .HasForeignKey("ConstructedTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.Data.Models.ScrimMatchTeamPointAdjustment", b =>
                {
                    b.HasOne("squittal.ScrimPlanetmans.Data.Models.ScrimMatchTeamResult", "ScrimMatchTeamResult")
                        .WithMany("PointAdjustments")
                        .HasForeignKey("ScrimMatchId", "TeamOrdinal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.ScrimMatch.Models.RulesetActionRule", b =>
                {
                    b.HasOne("squittal.ScrimPlanetmans.ScrimMatch.Models.Ruleset", "Ruleset")
                        .WithMany("ActionRules")
                        .HasForeignKey("RulesetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("squittal.ScrimPlanetmans.ScrimMatch.Models.RulesetItemCategoryRule", b =>
                {
                    b.HasOne("squittal.ScrimPlanetmans.ScrimMatch.Models.Ruleset", "Ruleset")
                        .WithMany("ItemCategoryRules")
                        .HasForeignKey("RulesetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
