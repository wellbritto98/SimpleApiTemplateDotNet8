using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleApiTemplateDotNet8.Web.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nickname = table.Column<string>(type: "text", nullable: false),
                    RegisteredAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RefreshToken = table.Column<string>(type: "text", nullable: false),
                    TokenExpiredAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TokenCreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Examples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Nickname = table.Column<string>(type: "text", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    ViaAdministracao = table.Column<string>(type: "text", nullable: false),
                    DosegemMaxima = table.Column<decimal>(type: "numeric", nullable: false),
                    IntervaloHoras = table.Column<int>(type: "integer", nullable: false),
                    DoseMinima = table.Column<decimal>(type: "numeric", nullable: false),
                    DoseMaxima = table.Column<decimal>(type: "numeric", nullable: false),
                    EmbalagemMl = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModeloReceituarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeInstituicao = table.Column<string>(type: "text", nullable: false),
                    EnderecoInstituicao = table.Column<string>(type: "text", nullable: false),
                    ImagemInstituicao = table.Column<byte[]>(type: "bytea", nullable: false),
                    NomePaciente = table.Column<string>(type: "text", nullable: false),
                    NomeProfissional = table.Column<string>(type: "text", nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Receita = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloReceituarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", null, "Admin", "ADMIN" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", null, "Player", "PLAYER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LastLoginAt", "LockoutEnabled", "LockoutEnd", "Nickname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RegisteredAt", "SecurityStamp", "TokenCreatedAt", "TokenExpiredAt", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "19b75c0c-5563-4bcf-9ece-10f5a4ffc433", 0, "c3baecdc-e6a5-42e6-ae98-f262f47d1386", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", true, null, false, null, "User 2", "USER2@EXAMPLE.COM", "USER2", "AQAAAAIAAYagAAAAEDG3+xXhG+ELA7CUzJ9StTKU1zlvjiCfJJ185JNQOFdN11LGG49pFJOFFXAOffsWdw==", null, false, "", new DateTime(2025, 1, 17, 17, 41, 34, 775, DateTimeKind.Local).AddTicks(1212), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user2" },
                    { "2e0c5469-fcba-43d9-9a2e-eb94e842e9df", 0, "74102ff7-2830-4ff6-9e43-7437dc3f5a9c", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@example.com", true, null, false, null, "User 4", "USER4@EXAMPLE.COM", "USER4", "AQAAAAIAAYagAAAAEPaZT09OETV4dfyZ3ouYDOTsaZwHhmGBdtLSlKGFgbSBpbwup9XMpXGykhFhn5CYDQ==", null, false, "", new DateTime(2025, 1, 17, 17, 41, 34, 917, DateTimeKind.Local).AddTicks(6992), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user4" },
                    { "304a26af-4eda-43a8-9eed-8c9620ccaa4f", 0, "80b631c6-08b0-4f31-b843-6eb5f6bb4bc2", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user7@example.com", true, null, false, null, "User 7", "USER7@EXAMPLE.COM", "USER7", "AQAAAAIAAYagAAAAEAaTxSjoPQ/im3NDS+HXigJ7j5bTiFA6xEGxsYrQYd0ktGy4gwJmkIt4kqkKcU7ohg==", null, false, "", new DateTime(2025, 1, 17, 17, 41, 35, 145, DateTimeKind.Local).AddTicks(9125), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user7" },
                    { "33d0e646-75af-4a07-ae7f-3cb912901191", 0, "b103b571-ac35-455e-976d-fa96a4868b75", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user11@example.com", true, null, false, null, "User 11", "USER11@EXAMPLE.COM", "USER11", "AQAAAAIAAYagAAAAEMWU4erfCuwHqXSYMTcrgwfJz3PDkB6o2zBYsZWX8qjcJerSeCLvYfRQVMSZuZU9/g==", null, false, "", new DateTime(2025, 1, 17, 17, 41, 35, 417, DateTimeKind.Local).AddTicks(3112), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user11" },
                    { "33ec9202-94e0-4435-8357-dfc2c475b50f", 0, "7a2ac06c-5813-4c93-bbe4-2e7335260cbf", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@example.com", true, null, false, null, "User 3", "USER3@EXAMPLE.COM", "USER3", "AQAAAAIAAYagAAAAEJnJ00KXQ4bSWanutPPKi0NTHn6rI0l2X933FdZVXZJdNitpctsHqZdVirkpViseXg==", null, false, "", new DateTime(2025, 1, 17, 17, 41, 34, 839, DateTimeKind.Local).AddTicks(7165), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user3" },
                    { "357be577-9a05-4f2f-ba77-dedadb5cd480", 0, "2af83759-150b-4a74-8146-f1d04eaba861", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user9@example.com", true, null, false, null, "User 9", "USER9@EXAMPLE.COM", "USER9", "AQAAAAIAAYagAAAAEKSNZ7eG3jvZ7JI1jHxikVPHohxuJA3+ASQtNW8oBnJS8N0mCFNjLZ41sukglXXbNw==", null, false, "", new DateTime(2025, 1, 17, 17, 41, 35, 275, DateTimeKind.Local).AddTicks(3049), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user9" },
                    { "35eab76f-0ca0-4acd-bce4-e7c68f625e01", 0, "e495f5f4-2c76-4636-b77f-7635119b3119", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user10@example.com", true, null, false, null, "User 10", "USER10@EXAMPLE.COM", "USER10", "AQAAAAIAAYagAAAAEL5dhGSqf0Xxf9Rz8+bTxyHSXehz6Yj0ZRpzS7jAGI9o43rFw7NW/Ql5S/TefkNMUg==", null, false, "", new DateTime(2025, 1, 17, 17, 41, 35, 351, DateTimeKind.Local).AddTicks(6158), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user10" },
                    { "3618b850-e9ce-48ff-a090-b78591cc3bbd", 0, "42c89af6-c239-4578-9a5e-53780049316c", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user8@example.com", true, null, false, null, "User 8", "USER8@EXAMPLE.COM", "USER8", "AQAAAAIAAYagAAAAEB0MCLxWDiNadpTiPWmf3zwFpe2A2c4Cdmh/KbSj7VkIni2t+k+8WT+HlmKBAcIMOQ==", null, false, "", new DateTime(2025, 1, 17, 17, 41, 35, 212, DateTimeKind.Local).AddTicks(2961), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user8" },
                    { "55a0ebd4-af5f-420a-85e0-3c7026caca02", 0, "42171438-55b2-4c43-8f38-e6ce718763aa", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user6@example.com", true, null, false, null, "User 6", "USER6@EXAMPLE.COM", "USER6", "AQAAAAIAAYagAAAAEKiDN1CkBY7qOuxpbC4+ZmL0mrMLTa4ujQ7LkhRB/lQugPQcEPv2eVbCk3zTZz3GTQ==", null, false, "", new DateTime(2025, 1, 17, 17, 41, 35, 74, DateTimeKind.Local).AddTicks(2596), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user6" },
                    { "7e21598a-9228-4dd9-8688-30c61f6fd115", 0, "4825edc1-588c-4eeb-9686-b347d4b46842", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5@example.com", true, null, false, null, "User 5", "USER5@EXAMPLE.COM", "USER5", "AQAAAAIAAYagAAAAEPQ5kWMZYJZuBsamUzSli+FBQpsLYQfCT5caFdZ90nfChdKcd/7r2DnvAkLUaJ+2zg==", null, false, "", new DateTime(2025, 1, 17, 17, 41, 34, 995, DateTimeKind.Local).AddTicks(2853), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user5" },
                    { "ab0148ad-552a-478e-86a2-9e08ba4d3a72", 0, "10c79e28-80db-45af-b056-f9c1b2b93966", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user12@example.com", true, null, false, null, "User 12", "USER12@EXAMPLE.COM", "USER12", "AQAAAAIAAYagAAAAEPSU1lSui2dXrXIp9OIBzqLla7eH80ZOksg9h8Caf+kH11wFcbvxblUJK9aLLrMohA==", null, false, "", new DateTime(2025, 1, 17, 17, 41, 35, 602, DateTimeKind.Local).AddTicks(2952), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user12" },
                    { "cce00265-37b5-42c4-98f0-5d0b11595552", 0, "d83fe92d-b776-454d-bf3f-4dcf663a2b05", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", true, null, false, null, "User 1", "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAEE0EqjmQyLKg8prhAHSlYhFGN92ofQq1bZwe2gK/PtWd3EePuuAP5HEukaZYiy1vdg==", null, false, "", new DateTime(2025, 1, 17, 17, 41, 34, 701, DateTimeKind.Local).AddTicks(2898), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user1" }
                });

            migrationBuilder.InsertData(
                table: "Examples",
                columns: new[] { "Id", "IsConfirmed", "Name", "Nickname" },
                values: new object[,]
                {
                    { 1, true, "Example1", "Example1Nickname" },
                    { 2, true, "Example2", "Example2Nickname" },
                    { 3, true, "Example3", "Example3Nickname" },
                    { 4, true, "Example4", "Example4Nickname" },
                    { 5, true, "Example5", "Example5Nickname" },
                    { 6, true, "Example6", "Example6Nickname" },
                    { 7, true, "Example7", "Example7Nickname" },
                    { 8, true, "Example8", "Example8Nickname" },
                    { 9, true, "Example9", "Example9Nickname" },
                    { 10, true, "Example10", "Example10Nickname" },
                    { 11, true, "Example11", "Example11Nickname" },
                    { 12, true, "Example12", "Example12Nickname" }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "DoseMaxima", "DoseMinima", "DosegemMaxima", "EmbalagemMl", "IntervaloHoras", "Nome", "ViaAdministracao" },
                values: new object[,]
                {
                    { 1, 5m, 1m, 10m, 100, 2, "Medication1", "Via Administracao 1" },
                    { 2, 5m, 1m, 10m, 100, 2, "Medication2", "Via Administracao 2" },
                    { 3, 5m, 1m, 10m, 100, 2, "Medication3", "Via Administracao 3" },
                    { 4, 5m, 1m, 10m, 100, 2, "Medication4", "Via Administracao 4" }
                });

            migrationBuilder.InsertData(
                table: "ModeloReceituarios",
                columns: new[] { "Id", "Data", "EnderecoInstituicao", "ImagemInstituicao", "NomeInstituicao", "NomePaciente", "NomeProfissional", "Receita" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 17, 17, 41, 34, 629, DateTimeKind.Local).AddTicks(2729), "Endereco Instituicao 1", new byte[] { 32, 32, 32, 32 }, "Nome Instituicao 1", "Nome Paciente 1", "Nome Profissional 1", "Receita 1" },
                    { 2, new DateTime(2025, 1, 17, 17, 41, 34, 629, DateTimeKind.Local).AddTicks(2784), "Endereco Instituicao 2", new byte[] { 32, 32, 32, 32 }, "Nome Instituicao 2", "Nome Paciente 2", "Nome Profissional 2", "Receita 2" },
                    { 3, new DateTime(2025, 1, 17, 17, 41, 34, 629, DateTimeKind.Local).AddTicks(2865), "Endereco Instituicao 3", new byte[] { 32, 32, 32, 32 }, "Nome Instituicao 3", "Nome Paciente 3", "Nome Profissional 3", "Receita 3" },
                    { 4, new DateTime(2025, 1, 17, 17, 41, 34, 629, DateTimeKind.Local).AddTicks(2897), "Endereco Instituicao 4", new byte[] { 32, 32, 32, 32 }, "Nome Instituicao 4", "Nome Paciente 4", "Nome Profissional 4", "Receita 4" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "19b75c0c-5563-4bcf-9ece-10f5a4ffc433" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "2e0c5469-fcba-43d9-9a2e-eb94e842e9df" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "304a26af-4eda-43a8-9eed-8c9620ccaa4f" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "33d0e646-75af-4a07-ae7f-3cb912901191" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "33ec9202-94e0-4435-8357-dfc2c475b50f" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "357be577-9a05-4f2f-ba77-dedadb5cd480" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "35eab76f-0ca0-4acd-bce4-e7c68f625e01" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "3618b850-e9ce-48ff-a090-b78591cc3bbd" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "55a0ebd4-af5f-420a-85e0-3c7026caca02" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "7e21598a-9228-4dd9-8688-30c61f6fd115" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "ab0148ad-552a-478e-86a2-9e08ba4d3a72" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "cce00265-37b5-42c4-98f0-5d0b11595552" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
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
                name: "Examples");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "ModeloReceituarios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
