using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EMS.Model;

namespace EMS.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20170329011331_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EMS.Model.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("ProjectName");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("ProjectId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("EMS.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Designation");

                    b.Property<string>("EmployeeName");

                    b.Property<int>("ProjectId");

                    b.Property<string>("Skills");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("EMS.Models.Employee", b =>
                {
                    b.HasOne("EMS.Model.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
