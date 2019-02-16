﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WindowsFormsApp4.Data;

namespace WindowsFormsApp4.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity("WindowsFormsApp4.Models.DynamicEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("IntCol1");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("ProjectTableId");

                    b.Property<string>("StringCol1");

                    b.Property<string>("StringCol2");

                    b.Property<bool>("SyncStatus");

                    b.HasKey("Id");

                    b.ToTable("DynamicEntities");
                });

            modelBuilder.Entity("WindowsFormsApp4.Models.Project", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("WindowsFormsApp4.Models.ProjectTable", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ProjectId");

                    b.HasKey("Id");

                    b.ToTable("ProjectTables");
                });

            modelBuilder.Entity("WindowsFormsApp4.Models.TableSchema", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ColumnName");

                    b.Property<string>("ComboBoxValues");

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsComboBox");

                    b.Property<int?>("Order");

                    b.Property<string>("PhysicalColumnName");

                    b.Property<string>("ProjectTableId");

                    b.HasKey("Id");

                    b.ToTable("TableSchemas");
                });
#pragma warning restore 612, 618
        }
    }
}
