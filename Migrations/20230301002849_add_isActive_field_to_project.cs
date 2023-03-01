using Microsoft.EntityFrameworkCore.Migrations;

namespace DataRoom.Migrations
{
    public partial class add_isActive_field_to_project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Project",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "49204648-d4d5-4e65-9b2e-515f59b0bb96");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "e2840944-80d2-4b77-b3df-2d503ae94b08");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "f8a9c126-db9b-443f-9ba0-6d2e6f97f8c1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "724506fa-69c3-47e9-99b6-3c25f59a8372", "AQAAAAEAACcQAAAAEN+PJTVY/FGzvLZO9n/pSaiswiE/yUKCNzgOynuSoCjiK8VQXZhoTw7pQ3i7zzrWzw==", "3135a4d6-a7f1-4689-a0e7-3c359f9c6e1d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d200ab9-e940-4238-96df-02204245ba77", "AQAAAAEAACcQAAAAEPlcjiraDj9B9lo6uNMql7n5QNd3C0aERLB2WGQiqCJkMgVaQEJ+w3F1GsH6mIQ2Ew==", "ac437afa-1277-45a8-9ea1-11e6af0fecc8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f21381b-e12b-4d0b-adbe-d285369647db", "AQAAAAEAACcQAAAAEOgrZqQ9rLdmQ233cyo/GdvN9Vr/XSWRapEdbIG+wWNLNKDWo9U9BgzZDVh9hEdzZw==", "5cc92178-963f-44a7-8514-4255745d4b7c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2617355-10be-4ffe-b4ae-15ef0b20e41d", "AQAAAAEAACcQAAAAELZgDGzZi+2WkGEKsWbctO2jYF5W9KMWd24o7paBId0JIP8Jh6log7ekztId5XOrVA==", "31cc2702-577c-4eea-ac43-cd3c53a29f3a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fbeda75-045e-4821-ba1a-033a95ef3199", "AQAAAAEAACcQAAAAEKCFDPkAQZ7C9vBFrQA3/QUaoqK2bv11WPxxKxPJ6RTmZi0onEP1BSo0FG68cuFrKg==", "ca6aea69-7a3d-4359-95e6-1235eda1b79e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9d2a50d-5861-478a-9d1f-94e0e68356c7", "AQAAAAEAACcQAAAAEBR7JkSMQ3Bds/6v7Ia7z83jmkdXUS4WJJgHXW2aT6y53ceWInGLY3s3jwsA7BFDow==", "122325b4-658a-4223-85ec-b89aaee90df5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdbf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a37182b6-5495-4bf7-ae47-ec992cbd28eb", "AQAAAAEAACcQAAAAEIafEDL9aSkcuTl0QC6Zv7CasV+sHkIz7umQyA2AJVFst7QdydIQonaOtajU/+wRBQ==", "5b303728-cf5b-47a5-8e10-86fcee85c222" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Project");

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
    }
}
