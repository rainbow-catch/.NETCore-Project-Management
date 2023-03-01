using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataRoom.Migrations
{
    public partial class update_project_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Project",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Project",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "b50658cc-537a-47ab-9006-c5005f419e85");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "1dda4b4b-9118-4ef8-bf2a-b6ddb102d66e");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "cabb6de2-bf09-4e4d-b653-7ecbf56784e4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b3ed7d8-dbd1-47f1-b428-d7da627509c9", "AQAAAAEAACcQAAAAEDj13HOQNLWtq4h3szvfb9HO7eFlfbq8om+wMaPUWq/MlpuvWUuS/5eI0QMjsp13jw==", "4674de22-6977-46c1-9ed4-a40ef238dba8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b10bfffe-5741-4b19-8fc0-9dc16b8f8ec9", "AQAAAAEAACcQAAAAEN5zubBRUxhKNNJW3leChx5Qx4Oa3O/U5lvudHdxa+fPVayS1c3cSu7T1RsnoS8f6g==", "d890b020-d722-4ae6-8bd9-8f81cd96e85a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f7066b1-307f-44a8-93c2-ca331e701563", "AQAAAAEAACcQAAAAEAkQDtbKOddM8r4I+Fh2VEugxagAl2E5pFpnEgyvhbLZPzkz80ICW+U7DA69PIuwhA==", "51e822df-cc61-47ca-bc05-9988f426416a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db5b7f53-982d-4676-97f0-5f7ab21475cc", "AQAAAAEAACcQAAAAEMjAl4S8IMqUjMot73sdpiD10A6J/rtVjfEygQADLTr1e6Tsd7zd7WX3J19e51U30w==", "6ed8a3a4-5413-47f3-87cc-3c5ae1aff96b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d4d9b78-0e41-4f14-a178-6e2bb5248e8d", "AQAAAAEAACcQAAAAELQ7MRu7a/tGnW4koe5q2rNuOCV60yk0/TKdfKH2mG7+6gry1krK7cPxODQEvev5Qg==", "0d2d4dcd-88d7-4fda-8a77-e88d493ba039" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ac3befb-34cf-433a-ad4e-6bed82517f6c", "AQAAAAEAACcQAAAAECiq4KBYQmTSN5OZkJuazeDWOkJneLlraH5jwY6K1ydVt57QehAH/Z78efWMyrlzhg==", "6d1a6a09-b862-43aa-be47-18cf486887fb" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "809e59d3-f075-4ff7-97af-5dfb63d8e066", "AQAAAAEAACcQAAAAEO6ALbdrq5ZmpUIKWLw/oaFPHaYT7N0FsQsT27vT8JaNqPWGmgwtmH6MIZYzQzIIBw==", "2d68b8c3-903d-440e-96fa-bad5d4f85430" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Project");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "8cb1aec6-7c0f-48fb-a2c1-ccc026bf4d51");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "c59699b9-30c1-47b9-9520-56d462bc89c2");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "e423077a-5bd9-4038-ace9-a177e66f1956");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abeef323-999f-4f87-9721-c8bdff714e43", "AQAAAAEAACcQAAAAENAW+18n9eW8slj25gsl2wzAJSHjwNULKepaEpYOEVb8NTqlTwptRBWj7VopcPcgDg==", "3433f900-587d-49d7-871d-367d91b2bcfd" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eed5a152-bb1a-4f9b-8e59-a5786439d628", "AQAAAAEAACcQAAAAEGcaL+YQGMwnG1c1HFKpaBXyfNWY+EGM9psPaJcDkMNGe/teTjDGXP4YfE9AyophQQ==", "9e134a19-5592-4a6f-9def-f5e79b8fab4a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0327273-928a-4a3f-8c3f-a72bf4b6fccd", "AQAAAAEAACcQAAAAEKbVB+B+9sAYDezJ3fmvTLgpfPPQh2rW0NlUFLomBKqukiv0jfxA6XflGbEU6fx6GA==", "f8935f1d-3649-4d58-a148-32f055ec307f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b35720ca-1a2d-4823-b924-af24c0bdf4be", "AQAAAAEAACcQAAAAEPft8Sep4RSbk415d/iII9qivIHcmXoe3My93BFydW5dGbWFqQuSKUJef6pih8cH4w==", "c3fcbff3-0a21-4676-bf3a-9f43326161cd" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92e58a3b-08e8-46af-977b-6031c2259838", "AQAAAAEAACcQAAAAEETdWzwnrSHtDhvM6t7yoIo+zlgZihKho3/y8hZnCPNi8oMNYZ9hW4zGDAdsyUo4iQ==", "f6f6f7bb-734c-4a7a-bd23-1188264e3391" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00db050d-baf4-42ca-8297-c43f018829ba", "AQAAAAEAACcQAAAAEMEY3shihtNod6rqjC8VhnDYrrMvAGTimDQK8aO+voKSVg/Nbsga6tcRx6YrfsmUZQ==", "c2f62b5b-1238-4ad2-8192-87663c82f87f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "943f20c7-c000-48b2-a387-e6b5fadcc760", "AQAAAAEAACcQAAAAEOEg3TAIyPXvKJwU3PMlkuI81T0btYfDh/BRD7c1FaRt83etuul5szYj/uAljh3DYw==", "5d4f3a16-c0ee-4534-9d27-79d4356e7ef4" });
        }
    }
}
