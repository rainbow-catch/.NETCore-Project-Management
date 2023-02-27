using Microsoft.EntityFrameworkCore.Migrations;

namespace DataRoom.Migrations
{
    public partial class update_user_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8cb1aec6-7c0f-48fb-a2c1-ccc026bf4d51", "Admins", "ADMINS" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c59699b9-30c1-47b9-9520-56d462bc89c2", "Owners", "OWNERS" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e423077a-5bd9-4038-ace9-a177e66f1956", "Bidders", "BIDDERS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "City", "CompanyName", "ConcurrencyStamp", "Country", "Name", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "Dili", "Ministry of Finance", "abeef323-999f-4f87-9721-c8bdff714e43", "Timor-Leste", "Admin", "AQAAAAEAACcQAAAAENAW+18n9eW8slj25gsl2wzAJSHjwNULKepaEpYOEVb8NTqlTwptRBWj7VopcPcgDg==", "3433f900-587d-49d7-871d-367d91b2bcfd", "Main Street" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdba",
                columns: new[] { "City", "CompanyName", "ConcurrencyStamp", "Country", "Name", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "Dili", "Ministry of Finance", "eed5a152-bb1a-4f9b-8e59-a5786439d628", "Timor-Leste", "Project Owner1", "AQAAAAEAACcQAAAAEGcaL+YQGMwnG1c1HFKpaBXyfNWY+EGM9psPaJcDkMNGe/teTjDGXP4YfE9AyophQQ==", "9e134a19-5592-4a6f-9def-f5e79b8fab4a", "Main Street" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbb",
                columns: new[] { "City", "CompanyName", "ConcurrencyStamp", "Country", "Name", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "Dili", "Ministry of Finance", "d0327273-928a-4a3f-8c3f-a72bf4b6fccd", "Timor-Leste", "Project Owner2", "AQAAAAEAACcQAAAAEKbVB+B+9sAYDezJ3fmvTLgpfPPQh2rW0NlUFLomBKqukiv0jfxA6XflGbEU6fx6GA==", "f8935f1d-3649-4d58-a148-32f055ec307f", "Main Street" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbc",
                columns: new[] { "City", "CompanyName", "ConcurrencyStamp", "Country", "Name", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "Dili", "Ministry of Finance", "b35720ca-1a2d-4823-b924-af24c0bdf4be", "Timor-Leste", "Bidder1", "AQAAAAEAACcQAAAAEPft8Sep4RSbk415d/iII9qivIHcmXoe3My93BFydW5dGbWFqQuSKUJef6pih8cH4w==", "c3fcbff3-0a21-4676-bf3a-9f43326161cd", "Main Street" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbd",
                columns: new[] { "City", "CompanyName", "ConcurrencyStamp", "Country", "Name", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "Dili", "Ministry of Finance", "92e58a3b-08e8-46af-977b-6031c2259838", "Timor-Leste", "Bidder2", "AQAAAAEAACcQAAAAEETdWzwnrSHtDhvM6t7yoIo+zlgZihKho3/y8hZnCPNi8oMNYZ9hW4zGDAdsyUo4iQ==", "f6f6f7bb-734c-4a7a-bd23-1188264e3391", "Main Street" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbe",
                columns: new[] { "City", "CompanyName", "ConcurrencyStamp", "Country", "Name", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "Dili", "Ministry of Finance", "00db050d-baf4-42ca-8297-c43f018829ba", "Timor-Leste", "Bidder3", "AQAAAAEAACcQAAAAEMEY3shihtNod6rqjC8VhnDYrrMvAGTimDQK8aO+voKSVg/Nbsga6tcRx6YrfsmUZQ==", "c2f62b5b-1238-4ad2-8192-87663c82f87f", "Main Street" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbf",
                columns: new[] { "City", "CompanyName", "ConcurrencyStamp", "Country", "Name", "PasswordHash", "SecurityStamp", "StreetAddress" },
                values: new object[] { "Dili", "Ministry of Finance", "943f20c7-c000-48b2-a387-e6b5fadcc760", "Timor-Leste", "Bidder4", "AQAAAAEAACcQAAAAEOEg3TAIyPXvKJwU3PMlkuI81T0btYfDh/BRD7c1FaRt83etuul5szYj/uAljh3DYw==", "5d4f3a16-c0ee-4534-9d27-79d4356e7ef4", "Main Street" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Name", "PhotoPath" },
                values: new object[,]
                {
                    { 1, 3, "sothun.thay@icloud.com", "Sothun Thay", null },
                    { 2, 1, "sreyneth.khorn@icloud.com", "Sreyneth Khorn", null },
                    { 3, 0, "nisa.thay@icloud.com", "Nisa Thay", null },
                    { 4, 0, "bosba.sthay@icloud.com", "Bosba Thay", null }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8fd82ec0-7129-478b-9a11-251df8aafc51", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "285ba163-9b0b-496e-8801-46cea158b0fd", "Owner", "OWNER" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d938d0da-f3bf-4ad9-a093-6e79293a4f71", "Bidder", "BIDDER" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "CompanyName", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "", "734a0e89-284a-4852-b29a-b775eec7920f", "AQAAAAEAACcQAAAAEAQRwkJWAM4SiMvCHnjcWy6AqvoG3v7+D4D8ACsfVS5ZFtf6KPFPXeMfCWovF3onYQ==", "dc919890-4d25-45ee-b552-30ad980c3b72" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdba",
                columns: new[] { "CompanyName", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "owner company", "72514fba-ebea-4095-b3bf-463e5cfaa5e5", "AQAAAAEAACcQAAAAENN15g5Gfk7eOM10IxRM9u/fNcuCNIzcKGM4kBF8lLtqJYDsjCny4+V1wn+nE1jvZg==", "5f41d3f4-cbf9-410e-8170-d1ed9a83a546" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbb",
                columns: new[] { "CompanyName", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { " company", "97d3e745-6afd-4fb4-ba81-7a681086e922", "AQAAAAEAACcQAAAAEAXuFtRYBDA/yyOKVVaHVleLlNywtkg+JIJ440u/9wSIpniht91IXZHENagYbJou2g==", "42b1e679-833a-45d3-b2dd-9008d4001b99" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbc",
                columns: new[] { "CompanyName", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bidder company", "226ed194-ba9b-4e36-ac31-81b28cf61b7a", "AQAAAAEAACcQAAAAEHd4NcwNvWqybUF7Kk+90eUGYCrbeQE1zihq7PvBp5QciYmALp5SCCRpAIYNKvda7w==", "0c86d8da-68ca-4c14-9420-9ea906992e6f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbd",
                columns: new[] { "CompanyName", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bidder company", "6889bbeb-4cec-4bef-899d-9ee506a1f379", "AQAAAAEAACcQAAAAEO79AFqzfWp3+j/SQDdev83Rg8QAxLapsXEM4/TUiNIYLoklb9IufnIX31USv8y/fg==", "7a551a7a-1857-414d-aada-e4e6711afb76" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbe",
                columns: new[] { "CompanyName", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bidder company", "99c2fcfb-3c25-468a-add2-084729ef9cb7", "AQAAAAEAACcQAAAAEF1tIs8UOvL8eZOuF31+3Ed/tLY76/VysW3++9bVHoG3RS3Imsib/LkeIj6Vutnm7A==", "a9ce6d5f-cb71-414b-a0df-6ba8cc252dde" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbf",
                columns: new[] { "CompanyName", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bidder company", "37fa0825-d094-478b-afb5-aaf4791ccb7f", "AQAAAAEAACcQAAAAELwmPIgjA15n4ojsGqHWJrpT4SD86eorgx0fFMNaSRNciN+3SoR+wewO2rYDv7mHPQ==", "1525b14b-9154-47ec-b68a-3d2a1a25641d" });
        }
    }
}
