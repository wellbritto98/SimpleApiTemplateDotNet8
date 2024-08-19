using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleApiTemplate.Migrations
{
    /// <inheritdoc />
    public partial class seeders : Migration
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
                    { "2990af37-64f8-4c15-ba1d-47207887fa07", 0, "a93ee791-61f1-4a2b-9dc9-5016ae5fe258", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5@example.com", true, null, false, null, "User 5", "USER5@EXAMPLE.COM", "USER5", "AQAAAAIAAYagAAAAEE5lok8cOs53Fb7LPRdPkhN597bu1qJvSt6P+pT3eb47uFl6p2htKPv4FbEyz2k0uA==", null, false, "", new DateTime(2024, 6, 20, 11, 28, 48, 244, DateTimeKind.Local).AddTicks(1674), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user5" },
                    { "2a4350fd-0cb6-47c1-8adb-c90b3c719455", 0, "9d5d1888-e1d9-4af3-a9b3-ea92fe9e870c", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", true, null, false, null, "User 2", "USER2@EXAMPLE.COM", "USER2", "AQAAAAIAAYagAAAAEKG3bYsM9X9G1YEJ7nPCr6oyaEy18B8R4e5SHXSqAR5i3Da985tu2upWKFGALVruMQ==", null, false, "", new DateTime(2024, 6, 20, 11, 28, 48, 56, DateTimeKind.Local).AddTicks(3200), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user2" },
                    { "56fd83e3-72bf-4e16-803c-6fcc401e5a9f", 0, "b8bc6ab8-c688-4a5e-b02b-4401cecea17c", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user6@example.com", true, null, false, null, "User 6", "USER6@EXAMPLE.COM", "USER6", "AQAAAAIAAYagAAAAEF+wJ5XBoCneNciPuNW54DK855V40bsUuQ44pfM0EFS7YHioFkhu0stsvui+/FeOcg==", null, false, "", new DateTime(2024, 6, 20, 11, 28, 48, 314, DateTimeKind.Local).AddTicks(7699), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user6" },
                    { "639f3e9c-4b84-4947-ae02-d8a69411d757", 0, "faf2996d-3075-49d7-9233-7c2897fbbae3", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@example.com", true, null, false, null, "User 4", "USER4@EXAMPLE.COM", "USER4", "AQAAAAIAAYagAAAAEKn40b8zyN8LELJFDX7gXao+a1LrPGEmUkKwFZCZ1ij6R0eiQ1awQratpvPsJSGPWg==", null, false, "", new DateTime(2024, 6, 20, 11, 28, 48, 180, DateTimeKind.Local).AddTicks(5497), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user4" },
                    { "854970b5-1f8d-4ded-9a9a-234b8c2b42f0", 0, "8a0eb5e1-45d9-45b3-a244-389dd8d3a734", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user8@example.com", true, null, false, null, "User 8", "USER8@EXAMPLE.COM", "USER8", "AQAAAAIAAYagAAAAEAOJwJ57kV7K3971WTR7z1ntjEUCq5pbKSOLZaKfLqHdluFuQi6LpPBbrTUJ4w8ZLw==", null, false, "", new DateTime(2024, 6, 20, 11, 28, 48, 463, DateTimeKind.Local).AddTicks(713), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user8" },
                    { "97c7edad-56a5-4f30-883d-1bb504a3fbbc", 0, "716b9b40-e70c-41ce-8e4c-92b1536711ab", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user7@example.com", true, null, false, null, "User 7", "USER7@EXAMPLE.COM", "USER7", "AQAAAAIAAYagAAAAELXXMoUIB0Wt0u8CIh1FRdVD+djqTMBKleb0fqyTWFNkPpt8EsZkhv0GHV55rK+k3g==", null, false, "", new DateTime(2024, 6, 20, 11, 28, 48, 392, DateTimeKind.Local).AddTicks(6326), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user7" },
                    { "d04bb1c2-0e0a-425e-a14e-c47f6fa38eca", 0, "e228d2b7-eef5-46f2-a4c1-3d2ab3ab99a4", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@example.com", true, null, false, null, "User 3", "USER3@EXAMPLE.COM", "USER3", "AQAAAAIAAYagAAAAEI453gv+nmSV/Ki7+8UUcwUClOJUJef4DltGvvrO1JiHDrkCjmLdz+dokFA+DCqHDQ==", null, false, "", new DateTime(2024, 6, 20, 11, 28, 48, 113, DateTimeKind.Local).AddTicks(7790), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user3" },
                    { "d4749bfa-dad3-4700-9fc5-25c046529295", 0, "9b030d55-34b8-4938-a0d9-343f28e5b152", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user12@example.com", true, null, false, null, "User 12", "USER12@EXAMPLE.COM", "USER12", "AQAAAAIAAYagAAAAEGDVPlLpkQ1KOxbhltixChKnLwtazp1BFzwlInprqFBa3pk4kSnaJ2/a/5uyeES7wg==", null, false, "", new DateTime(2024, 6, 20, 11, 28, 48, 702, DateTimeKind.Local).AddTicks(295), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user12" },
                    { "d747ba12-5c2a-4c1e-bd49-2a898f4e3e6e", 0, "6c5551ef-5d4d-4295-a9ad-e6339e494982", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", true, null, false, null, "User 1", "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAEM+4NDBQmvyBo/wtOOZCBfhABVoWWJ8XaOSGLM0+5cTo9YBzCAT4RMlG/aKO0sQKmg==", null, false, "", new DateTime(2024, 6, 20, 11, 28, 47, 996, DateTimeKind.Local).AddTicks(63), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user1" },
                    { "e26de384-d6f2-4c3e-a9bc-edd58687a69e", 0, "96ff05d5-dcba-4d9d-b0df-0b43b7224eed", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user10@example.com", true, null, false, null, "User 10", "USER10@EXAMPLE.COM", "USER10", "AQAAAAIAAYagAAAAEG45r4rVgax3Y2vx5m2spRwX77DRdSrwNpZehhX1vuJKvUVXngjF/GaYBeIhvtMVrg==", null, false, "", new DateTime(2024, 6, 20, 11, 28, 48, 578, DateTimeKind.Local).AddTicks(4862), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user10" },
                    { "e45b3bb8-4d83-48b5-a583-c1a87e76c34a", 0, "a7b12ccd-4ba0-4cd9-81d5-ddac4139e096", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user11@example.com", true, null, false, null, "User 11", "USER11@EXAMPLE.COM", "USER11", "AQAAAAIAAYagAAAAEMSFpI2hiio7O4EsJz5BSmcdoteqPYJBlp9L4oRv1RcB9dUfpva0F79bR3xswT0Tsw==", null, false, "", new DateTime(2024, 6, 20, 11, 28, 48, 639, DateTimeKind.Local).AddTicks(5382), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user11" },
                    { "e7b5b4f0-ef6a-410a-ac05-e3ea0ba81e72", 0, "fd6a2d45-cb3b-48d5-a3fb-43d3eab0ae98", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user9@example.com", true, null, false, null, "User 9", "USER9@EXAMPLE.COM", "USER9", "AQAAAAIAAYagAAAAEBhDT3G29vMe7zeDhakg36FBzGMDBJ86l1A+4HOkkuChmp3c8wq5z8JO4OodVgOA0A==", null, false, "", new DateTime(2024, 6, 20, 11, 28, 48, 521, DateTimeKind.Local).AddTicks(5975), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user9" }
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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "2990af37-64f8-4c15-ba1d-47207887fa07" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "2a4350fd-0cb6-47c1-8adb-c90b3c719455" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "56fd83e3-72bf-4e16-803c-6fcc401e5a9f" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "639f3e9c-4b84-4947-ae02-d8a69411d757" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "854970b5-1f8d-4ded-9a9a-234b8c2b42f0" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "97c7edad-56a5-4f30-883d-1bb504a3fbbc" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "d04bb1c2-0e0a-425e-a14e-c47f6fa38eca" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "d4749bfa-dad3-4700-9fc5-25c046529295" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "d747ba12-5c2a-4c1e-bd49-2a898f4e3e6e" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "e26de384-d6f2-4c3e-a9bc-edd58687a69e" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "e45b3bb8-4d83-48b5-a583-c1a87e76c34a" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "e7b5b4f0-ef6a-410a-ac05-e3ea0ba81e72" }
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
