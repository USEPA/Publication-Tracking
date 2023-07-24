﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PublicationTracking.Data;

#nullable disable

namespace PublicationTracking.Migrations
{
    [DbContext(typeof(PublicationContext))]
    partial class PublicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PublicationTracking.Data.AlphaDescriptor", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("AlphaDescriptors");
                });

            modelBuilder.Entity("PublicationTracking.Data.Publication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AlphaDescriptorCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateEntered")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRequested")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnteredBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpectedPublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDigital")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsInternalOnly")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsOriginal")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPrinted")
                        .HasColumnType("bit");

                    b.Property<int?>("Language")
                        .HasColumnType("int");

                    b.Property<string>("OriginalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PointOfContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PointOfContactMailCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PointOfContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PointOfContactOrganization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PointOfContactPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponsibleCodeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Revision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SequenceNumber")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Volume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlphaDescriptorCode");

                    b.HasIndex("ResponsibleCodeCode");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("PublicationTracking.Data.ResponsibleCode", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<string>("Organization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("ResponsibleCodes");
                });

            modelBuilder.Entity("PublicationTracking.Data.Publication", b =>
                {
                    b.HasOne("PublicationTracking.Data.AlphaDescriptor", "AlphaDescriptor")
                        .WithMany()
                        .HasForeignKey("AlphaDescriptorCode");

                    b.HasOne("PublicationTracking.Data.ResponsibleCode", "ResponsibleCode")
                        .WithMany()
                        .HasForeignKey("ResponsibleCodeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AlphaDescriptor");

                    b.Navigation("ResponsibleCode");
                });
#pragma warning restore 612, 618
        }
    }
}
