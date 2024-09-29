﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TekhnelogosOkr.DataAccess.Concrete.Context;

#nullable disable

namespace TekhnelogosOkr.DataAccess.Migrations
{
    [DbContext(typeof(TekhnelogosOkrContext))]
    [Migration("20240812105005_keyresultupdate")]
    partial class keyresultupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.CompanyObjective", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Progress")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("CompanyObjectives");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.CompanyObjectiveOkrObjective", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyObjectiveId")
                        .HasColumnType("int");

                    b.Property<int>("ObjectiveId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyObjectiveId");

                    b.HasIndex("ObjectiveId");

                    b.ToTable("CompanyObjectiveOkrObjectives");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentManagerID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.KeyResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OkrObjectiveId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int?>("Progress")
                        .HasColumnType("int");

                    b.Property<DateTime>("TargetDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OkrObjectiveId");

                    b.HasIndex("OwnerId");

                    b.ToTable("KeyResults");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.OkrObjective", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Progress")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("OkrObjectives");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.OkrObjectiveUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OkrObjectiveId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OkrObjectiveId");

                    b.HasIndex("UserId");

                    b.ToTable("OkrObjectiveUsers");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusName = "Devam Ediyor"
                        },
                        new
                        {
                            Id = 2,
                            StatusName = "Tamamlandı"
                        },
                        new
                        {
                            Id = 3,
                            StatusName = "Vazgeçildi"
                        });
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.TekhnelogosOkr.Entity.Concrete.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ManagerID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartWorkDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("ManagerID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.CompanyObjective", b =>
                {
                    b.HasOne("TekhnelogosOkr.Entity.Concrete.Status", "Status")
                        .WithMany("CompanyObjectives")
                        .HasForeignKey("StatusId");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.CompanyObjectiveOkrObjective", b =>
                {
                    b.HasOne("TekhnelogosOkr.Entity.Concrete.CompanyObjective", "CompanyObjective")
                        .WithMany("CompanyObjectiveOkrObjectives")
                        .HasForeignKey("CompanyObjectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TekhnelogosOkr.Entity.Concrete.OkrObjective", "Objective")
                        .WithMany("CompanyObjectiveOkrObjectives")
                        .HasForeignKey("ObjectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyObjective");

                    b.Navigation("Objective");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.KeyResult", b =>
                {
                    b.HasOne("TekhnelogosOkr.Entity.Concrete.OkrObjective", "OkrObjective")
                        .WithMany()
                        .HasForeignKey("OkrObjectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TekhnelogosOkr.Entity.Concrete.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OkrObjective");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.OkrObjective", b =>
                {
                    b.HasOne("TekhnelogosOkr.Entity.Concrete.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.OkrObjectiveUser", b =>
                {
                    b.HasOne("TekhnelogosOkr.Entity.Concrete.OkrObjective", "Objective")
                        .WithMany("OkrObjectiveUsers")
                        .HasForeignKey("OkrObjectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TekhnelogosOkr.Entity.Concrete.User", "User")
                        .WithMany("OkrObjectiveUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Objective");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.TekhnelogosOkr.Entity.Concrete.UserRole", b =>
                {
                    b.HasOne("TekhnelogosOkr.Entity.Concrete.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TekhnelogosOkr.Entity.Concrete.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.User", b =>
                {
                    b.HasOne("TekhnelogosOkr.Entity.Concrete.Department", "Departments")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentID");

                    b.HasOne("TekhnelogosOkr.Entity.Concrete.User", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerID");

                    b.Navigation("Departments");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.CompanyObjective", b =>
                {
                    b.Navigation("CompanyObjectiveOkrObjectives");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.OkrObjective", b =>
                {
                    b.Navigation("CompanyObjectiveOkrObjectives");

                    b.Navigation("OkrObjectiveUsers");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.Status", b =>
                {
                    b.Navigation("CompanyObjectives");
                });

            modelBuilder.Entity("TekhnelogosOkr.Entity.Concrete.User", b =>
                {
                    b.Navigation("OkrObjectiveUsers");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
