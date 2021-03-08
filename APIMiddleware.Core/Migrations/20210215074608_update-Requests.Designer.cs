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
    [Migration("20210215074608_update-Requests")]
    partial class updateRequests
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

                    b.Property<string>("CREATED_BY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CREATION_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("LAST_UPDATED_BY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LAST_UPDATE_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RowVersion")
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

                    b.Property<string>("Created_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Creation_Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("ElapsedMilliseconds")
                        .HasColumnType("bigint");

                    b.Property<string>("IP_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Last_Update_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Last_Updated_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectCode")
                        .HasColumnType("int");

                    b.Property<string>("QueryString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RequestBody")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RequestFormat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestFunction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequestUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ResponseBody")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ResponseFormat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResponseStatus")
                        .HasColumnType("int");

                    b.Property<string>("RowVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

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
