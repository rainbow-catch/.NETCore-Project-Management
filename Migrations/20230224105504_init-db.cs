using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataRoom.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BidderProjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidderProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidderProjects_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BidderProjects_Users_BidderId",
                        column: x => x.BidderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8fd82ec0-7129-478b-9a11-251df8aafc51", "Admin", "ADMIN" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "285ba163-9b0b-496e-8801-46cea158b0fd", "Owner", "OWNER" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7212", "d938d0da-f3bf-4ad9-a093-6e79293a4f71", "Bidder", "BIDDER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "", "734a0e89-284a-4852-b29a-b775eec7920f", "admin@email.com", true, "admin", false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEAQRwkJWAM4SiMvCHnjcWy6AqvoG3v7+D4D8ACsfVS5ZFtf6KPFPXeMfCWovF3onYQ==", "123456789", false, "dc919890-4d25-45ee-b552-30ad980c3b72", false, "admin" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdba", 0, "owner company", "72514fba-ebea-4095-b3bf-463e5cfaa5e5", "owner1@email.com", true, "owner1", false, null, "OWNER1@EMAIL.COM", "OWNER1", "AQAAAAEAACcQAAAAENN15g5Gfk7eOM10IxRM9u/fNcuCNIzcKGM4kBF8lLtqJYDsjCny4+V1wn+nE1jvZg==", "123456789", false, "5f41d3f4-cbf9-410e-8170-d1ed9a83a546", false, "owner1" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdbb", 0, " company", "97d3e745-6afd-4fb4-ba81-7a681086e922", "owner2@email.com", true, "owner2", false, null, "OWNER2@EMAIL.COM", "OWNER2", "AQAAAAEAACcQAAAAEAXuFtRYBDA/yyOKVVaHVleLlNywtkg+JIJ440u/9wSIpniht91IXZHENagYbJou2g==", "123456789", false, "42b1e679-833a-45d3-b2dd-9008d4001b99", false, "owner2" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdbc", 0, "bidder company", "226ed194-ba9b-4e36-ac31-81b28cf61b7a", "bidder1@email.com", true, "bidder1", false, null, "BIDDER1@EMAIL.COM", "BIDDER1", "AQAAAAEAACcQAAAAEHd4NcwNvWqybUF7Kk+90eUGYCrbeQE1zihq7PvBp5QciYmALp5SCCRpAIYNKvda7w==", "123456789", false, "0c86d8da-68ca-4c14-9420-9ea906992e6f", false, "bidder1" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdbd", 0, "bidder company", "6889bbeb-4cec-4bef-899d-9ee506a1f379", "bidder2@email.com", true, "bidder2", false, null, "BIDDER2@EMAIL.COM", "BIDDER2", "AQAAAAEAACcQAAAAEO79AFqzfWp3+j/SQDdev83Rg8QAxLapsXEM4/TUiNIYLoklb9IufnIX31USv8y/fg==", "123456789", false, "7a551a7a-1857-414d-aada-e4e6711afb76", false, "bidder2" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdbe", 0, "bidder company", "99c2fcfb-3c25-468a-add2-084729ef9cb7", "bidder3@email.com", true, "bidder3", false, null, "BIDDER3@EMAIL.COM", "BIDDER3", "AQAAAAEAACcQAAAAEF1tIs8UOvL8eZOuF31+3Ed/tLY76/VysW3++9bVHoG3RS3Imsib/LkeIj6Vutnm7A==", "123456789", false, "a9ce6d5f-cb71-414b-a0df-6ba8cc252dde", false, "bidder3" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdbf", 0, "bidder company", "37fa0825-d094-478b-afb5-aaf4791ccb7f", "bidder4@email.com", true, "bidder4", false, null, "BIDDER4@EMAIL.COM", "BIDDER4", "AQAAAAEAACcQAAAAELwmPIgjA15n4ojsGqHWJrpT4SD86eorgx0fFMNaSRNciN+3SoR+wewO2rYDv7mHPQ==", "123456789", false, "1525b14b-9154-47ec-b68a-3d2a1a25641d", false, "bidder4" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "8e445865-a24d-4543-a6c6-9443d048cdba" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "8e445865-a24d-4543-a6c6-9443d048cdbb" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7212", "8e445865-a24d-4543-a6c6-9443d048cdbc" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7212", "8e445865-a24d-4543-a6c6-9443d048cdbd" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7212", "8e445865-a24d-4543-a6c6-9443d048cdbe" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7212", "8e445865-a24d-4543-a6c6-9443d048cdbf" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BidderProjects_BidderId",
                table: "BidderProjects",
                column: "BidderId");

            migrationBuilder.CreateIndex(
                name: "IX_BidderProjects_ProjectId",
                table: "BidderProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ApplicationUserId",
                table: "Project",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BidderProjects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
