﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Domain.Entities.BaseFare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ID");

                    b.ToTable("Fares");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Amount = 11.00m,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            IsActive = true
                        });
                });

            modelBuilder.Entity("Core.Domain.Entities.Card", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("DiscountType")
                        .HasColumnType("int");

                    b.Property<int>("IDTypeForDiscount")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("LastUsed")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PWD_SeniorRef")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Core.Domain.Entities.CardDiscountHistory", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CardID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("CurrentDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ID");

                    b.ToTable("DiscountHistories");
                });

            modelBuilder.Entity("Core.Domain.Entities.CardLimit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal>("Maximum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Minimum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ID");

                    b.ToTable("CardLimits");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Maximum = 10000m,
                            Minimum = 100m
                        });
                });

            modelBuilder.Entity("Core.Domain.Entities.CardTransactionHistory", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Adjustment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CardID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Transaction")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CardID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Core.Domain.Entities.Discount", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Percent")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Discounts");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "X5",
                            Percent = 0.20000000000000001
                        },
                        new
                        {
                            ID = 2L,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "X4",
                            Percent = 0.029999999999999999
                        },
                        new
                        {
                            ID = 3L,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "X0",
                            Percent = 0.0
                        });
                });

            modelBuilder.Entity("Core.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("Birthday")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NameSuffix")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID")
                        .HasName("PersonID");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            ID = new Guid("ff78f51f-46d5-4def-a9fa-66bd8b2ad444"),
                            Birthday = new DateTimeOffset(new DateTime(1986, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)),
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "John",
                            LastName = "Doe"
                        });
                });

            modelBuilder.Entity("Core.Domain.Entities.Station", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("FromPrevious")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("ModifiedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToNext")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Stations");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 0,
                            Name = "Baclaran",
                            ToNext = 1
                        },
                        new
                        {
                            ID = 2,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 1,
                            Name = "EDSA",
                            ToNext = 1
                        },
                        new
                        {
                            ID = 3,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 1,
                            Name = "Libertad",
                            ToNext = 0
                        },
                        new
                        {
                            ID = 4,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 0,
                            Name = "Gil Puyat",
                            ToNext = 1
                        },
                        new
                        {
                            ID = 5,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 1,
                            Name = "V. Cruz",
                            ToNext = 1
                        },
                        new
                        {
                            ID = 6,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 1,
                            Name = "Quirino",
                            ToNext = 1
                        },
                        new
                        {
                            ID = 7,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 1,
                            Name = "P. Gil",
                            ToNext = 1
                        },
                        new
                        {
                            ID = 8,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 1,
                            Name = "United Nations",
                            ToNext = 1
                        },
                        new
                        {
                            ID = 9,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 1,
                            Name = "C. Terminal",
                            ToNext = 1
                        },
                        new
                        {
                            ID = 10,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 1,
                            Name = "Carriedo",
                            ToNext = 0
                        },
                        new
                        {
                            ID = 11,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 0,
                            Name = "D. Jose",
                            ToNext = 1
                        },
                        new
                        {
                            ID = 12,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 1,
                            Name = "Bambang",
                            ToNext = 1
                        },
                        new
                        {
                            ID = 13,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 1,
                            Name = "Tayuman",
                            ToNext = 0
                        },
                        new
                        {
                            ID = 14,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 0,
                            Name = "Blumentritt",
                            ToNext = 1
                        },
                        new
                        {
                            ID = 15,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 1,
                            Name = "A. Santos",
                            ToNext = 1
                        },
                        new
                        {
                            ID = 16,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 1,
                            Name = "R. Papa",
                            ToNext = 1
                        },
                        new
                        {
                            ID = 17,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 1,
                            Name = "5th Ave.",
                            ToNext = 1
                        },
                        new
                        {
                            ID = 18,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 1,
                            Name = "Monumento",
                            ToNext = 2
                        },
                        new
                        {
                            ID = 19,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 2,
                            Name = "Balintawak",
                            ToNext = 2
                        },
                        new
                        {
                            ID = 20,
                            CreatedOn = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FromPrevious = 2,
                            Name = "Roosevelt",
                            ToNext = 0
                        });
                });

            modelBuilder.Entity("Core.Domain.Logs.Audit", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AuditDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("AuditType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuditUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChangedColumns")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeyValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Audits");
                });

            modelBuilder.Entity("Core.Domain.Logs.Event", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Timestamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trigger")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Core.Domain.Entities.CardTransactionHistory", b =>
                {
                    b.HasOne("Core.Domain.Entities.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
