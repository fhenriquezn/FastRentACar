using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastRentACar.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false, defaultValue: 0m),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Days = table.Column<int>(nullable: false, defaultValue: 0),
                    BranchOffice = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Username = table.Column<string>(maxLength: 25, nullable: false),
                    FirstName = table.Column<string>(maxLength: 25, nullable: true),
                    SecondName = table.Column<string>(maxLength: 25, nullable: true),
                    Surname = table.Column<string>(maxLength: 25, nullable: true),
                    SecondSurname = table.Column<string>(maxLength: 25, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Is2FAEnabled = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    BrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModel_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(nullable: true),
                    Expires = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedByIp = table.Column<string>(nullable: true),
                    Revoked = table.Column<DateTime>(nullable: true),
                    RevokedByIp = table.Column<string>(nullable: true),
                    ReplacedByToken = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Year = table.Column<string>(maxLength: 4, nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false, defaultValue: 0m),
                    Seats = table.Column<int>(nullable: false, defaultValue: 0),
                    Doors = table.Column<int>(nullable: false, defaultValue: 0),
                    CarModelId = table.Column<int>(nullable: false),
                    CarTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_CarModel_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Car_CarType_CarTypeId",
                        column: x => x.CarTypeId,
                        principalTable: "CarType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false, defaultValue: 0m),
                    CarId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 8, 23, 15, 53, 197, DateTimeKind.Local).AddTicks(4605), "system", null, null, null, "Toyota" },
                    { 2, new DateTime(2021, 3, 8, 23, 15, 53, 197, DateTimeKind.Local).AddTicks(4669), "system", null, null, null, "Hyundai" },
                    { 3, new DateTime(2021, 3, 8, 23, 15, 53, 197, DateTimeKind.Local).AddTicks(4671), "system", null, null, null, "Kia" },
                    { 4, new DateTime(2021, 3, 8, 23, 15, 53, 197, DateTimeKind.Local).AddTicks(4673), "system", null, null, null, "Acura" },
                    { 5, new DateTime(2021, 3, 8, 23, 15, 53, 197, DateTimeKind.Local).AddTicks(4674), "system", null, null, null, "Alfa-Romeo" },
                    { 6, new DateTime(2021, 3, 8, 23, 15, 53, 197, DateTimeKind.Local).AddTicks(4675), "system", null, null, null, "BMW" },
                    { 7, new DateTime(2021, 3, 8, 23, 15, 53, 197, DateTimeKind.Local).AddTicks(4676), "system", null, null, null, "Dodge" },
                    { 8, new DateTime(2021, 3, 8, 23, 15, 53, 197, DateTimeKind.Local).AddTicks(4677), "system", null, null, null, "Honda" }
                });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 8, 23, 15, 53, 202, DateTimeKind.Local).AddTicks(3788), "system", null, null, null, "Sedan" },
                    { 2, new DateTime(2021, 3, 8, 23, 15, 53, 202, DateTimeKind.Local).AddTicks(3821), "system", null, null, null, "Hatchback" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "FirstName", "Is2FAEnabled", "ModifiedAt", "ModifiedBy", "Password", "SecondName", "SecondSurname", "Surname", "Username" },
                values: new object[] { 1, new DateTime(2021, 3, 8, 23, 15, 53, 186, DateTimeKind.Local).AddTicks(985), "system", "admin@admin.com", "Admin", true, null, null, "VPHsJPhGwlWKj/JjQl2nez/UAgRknL/X0Fo1E5Ba5GuU+PKu/H4h19ZXRpygNm9vIOvgNQVhqTdMxwoC2aVva9ot1SJTaV1qbl9F3nRne23NzLDjnYCNVuB7iZ3Q2qvMmEDskXDmmmV0tLlX+y8Xy/aEEhBJa1ZNbYrfKZ2b2TI=", null, null, null, "admin" });

            migrationBuilder.InsertData(
                table: "CarModel",
                columns: new[] { "Id", "BrandId", "CreatedAt", "CreatedBy", "Description", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(3948), "system", null, null, null, "Fortuner" },
                    { 30, 8, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4025), "system", null, null, null, "civic" },
                    { 29, 8, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4024), "system", null, null, null, "Amaze" },
                    { 28, 7, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4023), "system", null, null, null, "Raider" },
                    { 27, 7, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4022), "system", null, null, null, "Viper" },
                    { 26, 7, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4021), "system", null, null, null, "Deluxe" },
                    { 25, 7, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4020), "system", null, null, null, "Daytona" },
                    { 24, 6, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4019), "system", null, null, null, "X7" },
                    { 23, 6, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4017), "system", null, null, null, "X6" },
                    { 22, 6, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4016), "system", null, null, null, "X1" },
                    { 21, 6, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4015), "system", null, null, null, "X4" },
                    { 20, 5, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4014), "system", null, null, null, "Giuliva Quadrifoglio" },
                    { 19, 5, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4013), "system", null, null, null, "Stelvio" },
                    { 18, 5, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4012), "system", null, null, null, "Spider" },
                    { 17, 5, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4011), "system", null, null, null, "Giulia" },
                    { 16, 4, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4010), "system", null, null, null, "Integra" },
                    { 15, 4, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4009), "system", null, null, null, "Vigor" },
                    { 14, 4, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4007), "system", null, null, null, "TL" },
                    { 13, 4, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4006), "system", null, null, null, "RL" },
                    { 12, 3, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4005), "system", null, null, null, "Sedona" },
                    { 11, 3, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4004), "system", null, null, null, "Rio" },
                    { 10, 3, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4003), "system", null, null, null, "Optima" },
                    { 9, 3, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4002), "system", null, null, null, "Forte" },
                    { 8, 2, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4001), "system", null, null, null, "Verna" },
                    { 7, 2, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4000), "system", null, null, null, "Grand i10" },
                    { 6, 2, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(3999), "system", null, null, null, "Creta" },
                    { 5, 2, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(3997), "system", null, null, null, "I20" },
                    { 4, 1, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(3996), "system", null, null, null, "Camry" },
                    { 3, 1, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(3995), "system", null, null, null, "Yaris" },
                    { 2, 1, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(3993), "system", null, null, null, "Corolla" },
                    { 31, 8, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4026), "system", null, null, null, "CR-V" },
                    { 32, 8, new DateTime(2021, 3, 8, 23, 15, 53, 201, DateTimeKind.Local).AddTicks(4027), "system", null, null, null, "Jazz" }
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarModelId", "CarTypeId", "CreatedAt", "CreatedBy", "Doors", "ModifiedAt", "ModifiedBy", "Price", "Seats", "Year" },
                values: new object[] { 1, 2, 1, new DateTime(2021, 3, 8, 23, 15, 53, 199, DateTimeKind.Local).AddTicks(5172), null, 4, null, null, 15000m, 5, "2019" });

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarModelId",
                table: "Car",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarTypeId",
                table: "Car",
                column: "CarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_BrandId",
                table: "CarModel",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_CarId",
                table: "OrderDetail",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "CarModel");

            migrationBuilder.DropTable(
                name: "CarType");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
