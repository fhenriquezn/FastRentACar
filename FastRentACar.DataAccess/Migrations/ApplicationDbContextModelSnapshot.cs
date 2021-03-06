// <auto-generated />
using System;
using FastRentACar.DataAccess.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FastRentACar.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FastRentACar.Domain.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("VARCHAR(250)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("Brand");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 197, DateTimeKind.Local).AddTicks(4605),
                            CreatedBy = "system",
                            Name = "Toyota"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 197, DateTimeKind.Local).AddTicks(4669),
                            CreatedBy = "system",
                            Name = "Hyundai"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 197, DateTimeKind.Local).AddTicks(4671),
                            CreatedBy = "system",
                            Name = "Kia"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 197, DateTimeKind.Local).AddTicks(4673),
                            CreatedBy = "system",
                            Name = "Acura"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 197, DateTimeKind.Local).AddTicks(4674),
                            CreatedBy = "system",
                            Name = "Alfa-Romeo"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 197, DateTimeKind.Local).AddTicks(4675),
                            CreatedBy = "system",
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 197, DateTimeKind.Local).AddTicks(4676),
                            CreatedBy = "system",
                            Name = "Dodge"
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 197, DateTimeKind.Local).AddTicks(4677),
                            CreatedBy = "system",
                            Name = "Honda"
                        });
                });

            modelBuilder.Entity("FastRentACar.Domain.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<int>("CarTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Doors")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("Seats")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.HasIndex("CarTypeId");

                    b.ToTable("Car");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarModelId = 2,
                            CarTypeId = 1,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 199, DateTimeKind.Local).AddTicks(5172),
                            Doors = 4,
                            Price = 15000m,
                            Seats = 5,
                            Year = "2019"
                        });
                });

            modelBuilder.Entity("FastRentACar.Domain.Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("VARCHAR(250)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("CarModel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(3948),
                            CreatedBy = "system",
                            Name = "Fortuner"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(3993),
                            CreatedBy = "system",
                            Name = "Corolla"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 1,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(3995),
                            CreatedBy = "system",
                            Name = "Yaris"
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 1,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(3996),
                            CreatedBy = "system",
                            Name = "Camry"
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 2,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(3997),
                            CreatedBy = "system",
                            Name = "I20"
                        },
                        new
                        {
                            Id = 6,
                            BrandId = 2,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(3999),
                            CreatedBy = "system",
                            Name = "Creta"
                        },
                        new
                        {
                            Id = 7,
                            BrandId = 2,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4000),
                            CreatedBy = "system",
                            Name = "Grand i10"
                        },
                        new
                        {
                            Id = 8,
                            BrandId = 2,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4001),
                            CreatedBy = "system",
                            Name = "Verna"
                        },
                        new
                        {
                            Id = 9,
                            BrandId = 3,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4002),
                            CreatedBy = "system",
                            Name = "Forte"
                        },
                        new
                        {
                            Id = 10,
                            BrandId = 3,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4003),
                            CreatedBy = "system",
                            Name = "Optima"
                        },
                        new
                        {
                            Id = 11,
                            BrandId = 3,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4004),
                            CreatedBy = "system",
                            Name = "Rio"
                        },
                        new
                        {
                            Id = 12,
                            BrandId = 3,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4005),
                            CreatedBy = "system",
                            Name = "Sedona"
                        },
                        new
                        {
                            Id = 13,
                            BrandId = 4,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4006),
                            CreatedBy = "system",
                            Name = "RL"
                        },
                        new
                        {
                            Id = 14,
                            BrandId = 4,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4007),
                            CreatedBy = "system",
                            Name = "TL"
                        },
                        new
                        {
                            Id = 15,
                            BrandId = 4,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4009),
                            CreatedBy = "system",
                            Name = "Vigor"
                        },
                        new
                        {
                            Id = 16,
                            BrandId = 4,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4010),
                            CreatedBy = "system",
                            Name = "Integra"
                        },
                        new
                        {
                            Id = 17,
                            BrandId = 5,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4011),
                            CreatedBy = "system",
                            Name = "Giulia"
                        },
                        new
                        {
                            Id = 18,
                            BrandId = 5,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4012),
                            CreatedBy = "system",
                            Name = "Spider"
                        },
                        new
                        {
                            Id = 19,
                            BrandId = 5,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4013),
                            CreatedBy = "system",
                            Name = "Stelvio"
                        },
                        new
                        {
                            Id = 20,
                            BrandId = 5,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4014),
                            CreatedBy = "system",
                            Name = "Giuliva Quadrifoglio"
                        },
                        new
                        {
                            Id = 21,
                            BrandId = 6,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4015),
                            CreatedBy = "system",
                            Name = "X4"
                        },
                        new
                        {
                            Id = 22,
                            BrandId = 6,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4016),
                            CreatedBy = "system",
                            Name = "X1"
                        },
                        new
                        {
                            Id = 23,
                            BrandId = 6,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4017),
                            CreatedBy = "system",
                            Name = "X6"
                        },
                        new
                        {
                            Id = 24,
                            BrandId = 6,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4019),
                            CreatedBy = "system",
                            Name = "X7"
                        },
                        new
                        {
                            Id = 25,
                            BrandId = 7,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4020),
                            CreatedBy = "system",
                            Name = "Daytona"
                        },
                        new
                        {
                            Id = 26,
                            BrandId = 7,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4021),
                            CreatedBy = "system",
                            Name = "Deluxe"
                        },
                        new
                        {
                            Id = 27,
                            BrandId = 7,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4022),
                            CreatedBy = "system",
                            Name = "Viper"
                        },
                        new
                        {
                            Id = 28,
                            BrandId = 7,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4023),
                            CreatedBy = "system",
                            Name = "Raider"
                        },
                        new
                        {
                            Id = 29,
                            BrandId = 8,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4024),
                            CreatedBy = "system",
                            Name = "Amaze"
                        },
                        new
                        {
                            Id = 30,
                            BrandId = 8,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4025),
                            CreatedBy = "system",
                            Name = "civic"
                        },
                        new
                        {
                            Id = 31,
                            BrandId = 8,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4026),
                            CreatedBy = "system",
                            Name = "CR-V"
                        },
                        new
                        {
                            Id = 32,
                            BrandId = 8,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4027),
                            CreatedBy = "system",
                            Name = "Jazz"
                        });
                });

            modelBuilder.Entity("FastRentACar.Domain.Models.CarType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("VARCHAR(250)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("CarType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 202, DateTimeKind.Local).AddTicks(3788),
                            CreatedBy = "system",
                            Name = "Sedan"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 202, DateTimeKind.Local).AddTicks(3821),
                            CreatedBy = "system",
                            Name = "Hatchback"
                        });
                });

            modelBuilder.Entity("FastRentACar.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BranchOffice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Days")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(18,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("FastRentACar.Domain.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(18,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("FastRentACar.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<bool>("Is2FAEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ModifiedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("SecondSurname")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 3, 8, 23, 15, 53, 186, DateTimeKind.Local).AddTicks(985),
                            CreatedBy = "system",
                            Email = "admin@admin.com",
                            FirstName = "Admin",
                            Is2FAEnabled = true,
                            Password = "VPHsJPhGwlWKj/JjQl2nez/UAgRknL/X0Fo1E5Ba5GuU+PKu/H4h19ZXRpygNm9vIOvgNQVhqTdMxwoC2aVva9ot1SJTaV1qbl9F3nRne23NzLDjnYCNVuB7iZ3Q2qvMmEDskXDmmmV0tLlX+y8Xy/aEEhBJa1ZNbYrfKZ2b2TI=",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("FastRentACar.Domain.Models.Car", b =>
                {
                    b.HasOne("FastRentACar.Domain.Models.CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FastRentACar.Domain.Models.CarType", "CarType")
                        .WithMany()
                        .HasForeignKey("CarTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("FastRentACar.Domain.Models.CarModel", b =>
                {
                    b.HasOne("FastRentACar.Domain.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("FastRentACar.Domain.Models.OrderDetail", b =>
                {
                    b.HasOne("FastRentACar.Domain.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FastRentACar.Domain.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FastRentACar.Domain.Models.User", b =>
                {
                    b.OwnsMany("FastRentACar.Domain.Models.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("Created")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("datetime2");

                            b1.Property<string>("ReplacedByToken")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("datetime2");

                            b1.Property<string>("RevokedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Token")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
