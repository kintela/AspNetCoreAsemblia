﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CursoAspNet.Core.Domain.Infrastructure
{
    [DbContext(typeof(FysegContext))]
    [Migration("20180323075821_AddFieldStateInOpportunity")]
    partial class AddFieldStateInOpportunity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("web.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("web.Models.Opportunity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("CallDate");

                    b.Property<string>("Country");

                    b.Property<int>("LeadEmployeeId");

                    b.Property<string>("State");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("LeadEmployeeId");

                    b.ToTable("Opportunities");
                });

            modelBuilder.Entity("web.Models.Opportunity", b =>
                {
                    b.HasOne("web.Models.Employee", "LeadEmployee")
                        .WithMany("Opportunities")
                        .HasForeignKey("LeadEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
