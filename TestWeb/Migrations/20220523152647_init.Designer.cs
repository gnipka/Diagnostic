﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestWeb.Repositories;

namespace TestWeb.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220523152647_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestWeb.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.HasIndex("GenderId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("TestWeb.Models.Disease", b =>
                {
                    b.Property<int>("DiseaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<int>("Lower_age_limit")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Upper_age_limit")
                        .HasColumnType("int");

                    b.HasKey("DiseaseId");

                    b.HasIndex("GenderId");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("TestWeb.Models.DiseaseBySymptom", b =>
                {
                    b.Property<int>("DiseaseBySymptomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<int>("SymptomId")
                        .HasColumnType("int");

                    b.HasKey("DiseaseBySymptomId");

                    b.HasIndex("DiseaseId");

                    b.HasIndex("SymptomId");

                    b.ToTable("DiseaseBySymptoms");
                });

            modelBuilder.Entity("TestWeb.Models.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderId");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("TestWeb.Models.Localization", b =>
                {
                    b.Property<int>("LocalizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocalizationId");

                    b.ToTable("Localizations");
                });

            modelBuilder.Entity("TestWeb.Models.Symptom", b =>
                {
                    b.Property<int>("SymptomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LocalizationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SymptomId");

                    b.HasIndex("LocalizationId");

                    b.ToTable("Symptoms");
                });

            modelBuilder.Entity("TestWeb.Models.Client", b =>
                {
                    b.HasOne("TestWeb.Models.Gender", "ClientGender")
                        .WithMany("Clients")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientGender");
                });

            modelBuilder.Entity("TestWeb.Models.Disease", b =>
                {
                    b.HasOne("TestWeb.Models.Gender", "DiseaseGender")
                        .WithMany("Diseases")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiseaseGender");
                });

            modelBuilder.Entity("TestWeb.Models.DiseaseBySymptom", b =>
                {
                    b.HasOne("TestWeb.Models.Disease", "DiseaseFromDiseaseBySymptom")
                        .WithMany("DiseaseBySymptoms")
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestWeb.Models.Symptom", "SymptomFromDiseaseBySymptom")
                        .WithMany()
                        .HasForeignKey("SymptomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiseaseFromDiseaseBySymptom");

                    b.Navigation("SymptomFromDiseaseBySymptom");
                });

            modelBuilder.Entity("TestWeb.Models.Symptom", b =>
                {
                    b.HasOne("TestWeb.Models.Localization", "SymptomLocalization")
                        .WithMany("Symptoms")
                        .HasForeignKey("LocalizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SymptomLocalization");
                });

            modelBuilder.Entity("TestWeb.Models.Disease", b =>
                {
                    b.Navigation("DiseaseBySymptoms");
                });

            modelBuilder.Entity("TestWeb.Models.Gender", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Diseases");
                });

            modelBuilder.Entity("TestWeb.Models.Localization", b =>
                {
                    b.Navigation("Symptoms");
                });
#pragma warning restore 612, 618
        }
    }
}
