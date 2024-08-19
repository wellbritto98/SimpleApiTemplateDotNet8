using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleApiTemplate.Migrations
{
    /// <inheritdoc />
    public partial class correctmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "2990af37-64f8-4c15-ba1d-47207887fa07" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "2a4350fd-0cb6-47c1-8adb-c90b3c719455" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "56fd83e3-72bf-4e16-803c-6fcc401e5a9f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "639f3e9c-4b84-4947-ae02-d8a69411d757" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "854970b5-1f8d-4ded-9a9a-234b8c2b42f0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "97c7edad-56a5-4f30-883d-1bb504a3fbbc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "d04bb1c2-0e0a-425e-a14e-c47f6fa38eca" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "d4749bfa-dad3-4700-9fc5-25c046529295" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "d747ba12-5c2a-4c1e-bd49-2a898f4e3e6e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "e26de384-d6f2-4c3e-a9bc-edd58687a69e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "e45b3bb8-4d83-48b5-a583-c1a87e76c34a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "e7b5b4f0-ef6a-410a-ac05-e3ea0ba81e72" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2990af37-64f8-4c15-ba1d-47207887fa07");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a4350fd-0cb6-47c1-8adb-c90b3c719455");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "56fd83e3-72bf-4e16-803c-6fcc401e5a9f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "639f3e9c-4b84-4947-ae02-d8a69411d757");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "854970b5-1f8d-4ded-9a9a-234b8c2b42f0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97c7edad-56a5-4f30-883d-1bb504a3fbbc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d04bb1c2-0e0a-425e-a14e-c47f6fa38eca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d4749bfa-dad3-4700-9fc5-25c046529295");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d747ba12-5c2a-4c1e-bd49-2a898f4e3e6e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e26de384-d6f2-4c3e-a9bc-edd58687a69e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e45b3bb8-4d83-48b5-a583-c1a87e76c34a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7b5b4f0-ef6a-410a-ac05-e3ea0ba81e72");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Examples",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 0)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "LastLoginAt", "LockoutEnabled", "LockoutEnd", "Nickname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RegisteredAt", "SecurityStamp", "TokenCreatedAt", "TokenExpiredAt", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1ef27972-0ad8-4d09-82ee-a8c52c804a15", 0, "0c46c467-875a-445f-9d7d-9c278d242d1d", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user10@example.com", true, null, false, null, "User 10", "USER10@EXAMPLE.COM", "USER10", "AQAAAAIAAYagAAAAEBK/nijuRoISlQQDW5aeLNg8a1SrudJ15NctE+eEqduCLHBuM3MHuj5TnvHu71Sr5A==", null, false, "", new DateTime(2024, 6, 20, 12, 1, 4, 342, DateTimeKind.Local).AddTicks(7651), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user10" },
                    { "2c2bf9b6-d100-419d-b8fe-5d2b2717ad09", 0, "a722ef07-18b0-4754-9a44-c7606133a199", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", true, null, false, null, "User 2", "USER2@EXAMPLE.COM", "USER2", "AQAAAAIAAYagAAAAEEhAIUR14n/3rhw3M1np4cyuy72DqcPIrPCGRjit6jIuLFxt/d6mfJHc+nE6yuc0Pw==", null, false, "", new DateTime(2024, 6, 20, 12, 1, 3, 827, DateTimeKind.Local).AddTicks(556), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user2" },
                    { "4c574cc6-74fe-430a-93f0-f8b0e12b5d04", 0, "94b1efac-6807-4080-999d-f8a3679a8bec", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@example.com", true, null, false, null, "User 4", "USER4@EXAMPLE.COM", "USER4", "AQAAAAIAAYagAAAAEIDN0ZQ7uwfIpoG3LY1qXNEFnD2WvQK3/d5teluk43kyVGJvPCJk0Sk9PfSr8isI8g==", null, false, "", new DateTime(2024, 6, 20, 12, 1, 3, 956, DateTimeKind.Local).AddTicks(3231), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user4" },
                    { "4f8069c3-440c-4c20-ac8c-4773f5d138cb", 0, "998eb1b1-e574-4e2a-96c4-5c5971ab9ae9", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user7@example.com", true, null, false, null, "User 7", "USER7@EXAMPLE.COM", "USER7", "AQAAAAIAAYagAAAAEK1A02l1KUIQqmt36zs3pJS8qBP2h/LS37OLQQnJXr0xxxwgVvENkj+btzoLUxmilg==", null, false, "", new DateTime(2024, 6, 20, 12, 1, 4, 158, DateTimeKind.Local).AddTicks(8428), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user7" },
                    { "5879e8c1-62ec-41bc-b899-a384072faca8", 0, "f80b61f3-555d-4a50-9ef9-298fbcfaacf2", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5@example.com", true, null, false, null, "User 5", "USER5@EXAMPLE.COM", "USER5", "AQAAAAIAAYagAAAAEJeuHRb35C746TbNgwLaOAk2xDESuMAXKjNGwyImkUS3mA/x2jGsXgHmUw+kGm7KQA==", null, false, "", new DateTime(2024, 6, 20, 12, 1, 4, 36, DateTimeKind.Local).AddTicks(8941), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user5" },
                    { "85c5db47-a339-4613-a75a-8d58485b92cc", 0, "451cf08c-048c-48a9-87c4-26bbea1da167", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user9@example.com", true, null, false, null, "User 9", "USER9@EXAMPLE.COM", "USER9", "AQAAAAIAAYagAAAAECEGMiQhUAvqzAxDbEyBOuEgFP2pgxp0zuIOwfxnmBl3ezhxD7gMvmpL9WqKogpGsg==", null, false, "", new DateTime(2024, 6, 20, 12, 1, 4, 283, DateTimeKind.Local).AddTicks(2292), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user9" },
                    { "9c7072e8-9fc4-4197-8caf-be802c9303a8", 0, "d398c68d-bcee-4760-a9ff-4571abc79675", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user8@example.com", true, null, false, null, "User 8", "USER8@EXAMPLE.COM", "USER8", "AQAAAAIAAYagAAAAEJyrbjzQx+t998FinPV8G59fjaLej1/mxbpHdRF3nvHdrJrah9sa5Q0MN/X+R847/g==", null, false, "", new DateTime(2024, 6, 20, 12, 1, 4, 225, DateTimeKind.Local).AddTicks(4871), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user8" },
                    { "ac12f639-da1f-4ffe-9044-688658492d1b", 0, "02b74c6d-cb7e-42eb-9c8d-d495ab539967", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@example.com", true, null, false, null, "User 3", "USER3@EXAMPLE.COM", "USER3", "AQAAAAIAAYagAAAAEGxus1Vcw+3KmGiEAnasG2e3Tg2P0V9ZCaKp0Kk6ZsvjCnEC2Y2CCnwIYIodkD6lvw==", null, false, "", new DateTime(2024, 6, 20, 12, 1, 3, 893, DateTimeKind.Local).AddTicks(1534), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user3" },
                    { "ca670b04-b3a3-47df-b32d-0c7ee354cd7d", 0, "84368ecf-a7a5-45e7-bcb0-d25c57364fe8", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user12@example.com", true, null, false, null, "User 12", "USER12@EXAMPLE.COM", "USER12", "AQAAAAIAAYagAAAAECcnsgHEIrExl/UWL8xV1DJZEUN+o9+QFKf7c+oXv1YBZleC5h+/QUC792fPqMuj6w==", null, false, "", new DateTime(2024, 6, 20, 12, 1, 4, 458, DateTimeKind.Local).AddTicks(375), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user12" },
                    { "cbc7296c-c85a-444e-a8ac-d2fbaf2eefe3", 0, "2aaa7299-f313-4e09-b267-a059b4ef334a", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user11@example.com", true, null, false, null, "User 11", "USER11@EXAMPLE.COM", "USER11", "AQAAAAIAAYagAAAAEMJFD2ibcNxiV/0p+xLRZVgVRAKao+8ITdQrqvI2Cw8GBhc+XO+OZXxQRrdvgQ5SnA==", null, false, "", new DateTime(2024, 6, 20, 12, 1, 4, 400, DateTimeKind.Local).AddTicks(2744), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user11" },
                    { "d468ce11-8cdc-4551-a39a-59ec7d8c3ba8", 0, "e8136026-7ef2-4c17-aff9-234ac63eebb8", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", true, null, false, null, "User 1", "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAENQdSffPkWiM8s1DO3+KwWrpwQgFd4Hov54SUesmV7UoSeZho+3/M/ewWKXYxEn4SA==", null, false, "", new DateTime(2024, 6, 20, 12, 1, 3, 752, DateTimeKind.Local).AddTicks(741), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user1" },
                    { "dbe97d3d-f92a-4de3-bcde-0fbfefa1b7c0", 0, "620cfbcf-4c5d-42cf-8239-bd3d85a167e7", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user6@example.com", true, null, false, null, "User 6", "USER6@EXAMPLE.COM", "USER6", "AQAAAAIAAYagAAAAEDv65lbwrR1xiqcqbQykj6dpnLTVJwFWO+TThcyuHCM3QeuLtAUQ8utzwb2ePlFGhA==", null, false, "", new DateTime(2024, 6, 20, 12, 1, 4, 99, DateTimeKind.Local).AddTicks(3184), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user6" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "1ef27972-0ad8-4d09-82ee-a8c52c804a15" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "2c2bf9b6-d100-419d-b8fe-5d2b2717ad09" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "4c574cc6-74fe-430a-93f0-f8b0e12b5d04" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "4f8069c3-440c-4c20-ac8c-4773f5d138cb" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "5879e8c1-62ec-41bc-b899-a384072faca8" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "85c5db47-a339-4613-a75a-8d58485b92cc" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "9c7072e8-9fc4-4197-8caf-be802c9303a8" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "ac12f639-da1f-4ffe-9044-688658492d1b" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "ca670b04-b3a3-47df-b32d-0c7ee354cd7d" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "cbc7296c-c85a-444e-a8ac-d2fbaf2eefe3" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "d468ce11-8cdc-4551-a39a-59ec7d8c3ba8" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "dbe97d3d-f92a-4de3-bcde-0fbfefa1b7c0" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "1ef27972-0ad8-4d09-82ee-a8c52c804a15" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "2c2bf9b6-d100-419d-b8fe-5d2b2717ad09" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "4c574cc6-74fe-430a-93f0-f8b0e12b5d04" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "4f8069c3-440c-4c20-ac8c-4773f5d138cb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "5879e8c1-62ec-41bc-b899-a384072faca8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "85c5db47-a339-4613-a75a-8d58485b92cc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "9c7072e8-9fc4-4197-8caf-be802c9303a8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "ac12f639-da1f-4ffe-9044-688658492d1b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "ca670b04-b3a3-47df-b32d-0c7ee354cd7d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "cbc7296c-c85a-444e-a8ac-d2fbaf2eefe3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "d468ce11-8cdc-4551-a39a-59ec7d8c3ba8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7211", "dbe97d3d-f92a-4de3-bcde-0fbfefa1b7c0" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ef27972-0ad8-4d09-82ee-a8c52c804a15");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c2bf9b6-d100-419d-b8fe-5d2b2717ad09");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4c574cc6-74fe-430a-93f0-f8b0e12b5d04");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f8069c3-440c-4c20-ac8c-4773f5d138cb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5879e8c1-62ec-41bc-b899-a384072faca8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85c5db47-a339-4613-a75a-8d58485b92cc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c7072e8-9fc4-4197-8caf-be802c9303a8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac12f639-da1f-4ffe-9044-688658492d1b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca670b04-b3a3-47df-b32d-0c7ee354cd7d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cbc7296c-c85a-444e-a8ac-d2fbaf2eefe3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d468ce11-8cdc-4551-a39a-59ec7d8c3ba8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbe97d3d-f92a-4de3-bcde-0fbfefa1b7c0");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Examples",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 0);

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
        }
    }
}
