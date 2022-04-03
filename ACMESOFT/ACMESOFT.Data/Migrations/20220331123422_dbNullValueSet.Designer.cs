﻿// <auto-generated />
using System;
using ACMESOFT.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ACMESOFT.Data.Migrations
{
    [DbContext(typeof(AcmesoftDataContext))]
    [Migration("20220331123422_dbNullValueSet")]
    partial class dbNullValueSet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ACMESOFT.Entity.Employee", b =>
                {
                    b.Property<int?>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("EmployeeId"), 1L, 1);

                    b.Property<DateTime>("EmployeeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TerminationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeId");

                    b.HasIndex("PersonId")
                        .IsUnique()
                        .HasFilter("[PersonId] IS NOT NULL");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("ACMESOFT.Entity.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"), 1L, 1);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LastName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("PersonId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("ACMESOFT.Entity.Employee", b =>
                {
                    b.HasOne("ACMESOFT.Entity.Person", "Person")
                        .WithOne("Employee")
                        .HasForeignKey("ACMESOFT.Entity.Employee", "PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("ACMESOFT.Entity.Person", b =>
                {
                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
