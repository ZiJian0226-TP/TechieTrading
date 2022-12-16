using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechieTrading.Server.Data.Migrations
{
    public partial class AddCompulsoryEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "StaffRole", "17b7f776-5ed9-44bc-be76-aa3409b63bb8", "Staff", "STAFF" },
                    { "CustomerRole", "80fb392e-8bbb-4975-b5ad-dc710476b2c7", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Contact", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "LocalStaff", 0, "1a5ec90b-0943-4aa4-b338-a2d652cc8c8d", null, "staff@localhost.com", false, "Staff", null, "Admin", false, null, "STAFF@LOCALHOST.COM", "STAFF", "AQAAAAEAACcQAAAAEOc02msbGaTRkkd6exrBFtJcjdH7q7gZFS/9SE0tcOVtlXJg0SPZ3WMZ5uo7ivEIbA==", null, false, "b4836fea-04dd-418f-8c65-0d23460d402a", false, "Staff" },
                    { "GuestCustomer", 0, "936d06c0-d929-40be-8e95-4ecdfb9ca82c", null, "guest@localhost.com", false, "Guest", null, "Customer", false, null, "GUEST@LOCALHOST.COM", "GUEST", "AQAAAAEAACcQAAAAEGxzc/AsyaEkHaat5P7+IFBRVzglMzM2zLldO57UVUtho2KMdpYp6IiW4TooX8aFRg==", null, false, "425d7dc1-c4a0-4d18-b456-0e7b9048f853", false, "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "Contact", "DateOfBirth", "Email", "FirstName", "Gender", "LastName" },
                values: new object[] { 1, "465 Tampines St 44, 520465 Singapore", "96369464", new DateTime(1999, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "2003980F@student.tp.edu.sg", "ZiJian", "Male", "Pang" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "ManufactureDate", "Name", "Price", "Quantity", "Type" },
                values: new object[] { 1, "8500 DPI", new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Razer Viper Mini Mouse", 30.0, 60, "Accessory" });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "Contact", "Email", "FirstName", "Gender", "LastName" },
                values: new object[] { 1, "87977031", "2100867G@student.tp.edu.sg", "JiaJun", "Male", "Ang" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "StaffRole", "LocalStaff" },
                    { "CustomerRole", "GuestCustomer" }
                });

            migrationBuilder.InsertData(
                table: "SellOrder",
                columns: new[] { "Id", "CustomerId", "DeliveryType", "OrderDate", "OrderTime", "ProductId", "StaffId" },
                values: new object[] { 1, 1, "Standard-Shipping", new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 16, 16, 14, 11, 914, DateTimeKind.Local).AddTicks(2887), null, 1 });

            migrationBuilder.InsertData(
                table: "TradeOrder",
                columns: new[] { "Id", "CustomerId", "DeliveryType", "OrderDate", "OrderTime", "ProductId", "StaffId" },
                values: new object[] { 1, 1, "Store-Pick-Up", new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 16, 16, 14, 11, 915, DateTimeKind.Local).AddTicks(9265), null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "CustomerRole", "GuestCustomer" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "StaffRole", "LocalStaff" });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SellOrder",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TradeOrder",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "CustomerRole");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "StaffRole");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "GuestCustomer");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "LocalStaff");

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");
        }
    }
}
