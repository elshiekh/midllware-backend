﻿// <auto-generated />
using System;
using APIMiddleware.Core.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIMiddleware.Core.Migrations
{
    [DbContext(typeof(APIMiddlewareContext))]
    [Migration("20200816140056_dbIniti111")]
    partial class dbIniti111
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIMiddleware.Core.DBContext.Entities.Project", b =>
                {
                    b.Property<int>("ProjectCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectCode");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("APIMiddleware.Core.DBContext.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ElapsedMilliseconds")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<string>("RequestMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectCode")
                        .HasColumnType("int");

                    b.Property<string>("QueryString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RequestBody")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RequestGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestTime")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("ResponseBody")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ResponseStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectCode");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("APIMiddleware.Core.DBContext.Entities.SystemPreference", b =>
                {
                    b.Property<int>("PreferenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PreferenceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreferenceValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PreferenceId");

                    b.ToTable("SystemPreferences");
                });

            modelBuilder.Entity("APIMiddleware.Core.DBContext.Entities.Request", b =>
                {
                    b.HasOne("APIMiddleware.Core.DBContext.Entities.Project", "Project")
                        .WithMany("Requests")
                        .HasForeignKey("ProjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
