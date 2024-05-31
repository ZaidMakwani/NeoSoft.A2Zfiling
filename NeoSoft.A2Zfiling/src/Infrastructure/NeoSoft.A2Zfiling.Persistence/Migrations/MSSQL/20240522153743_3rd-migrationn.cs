using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeoSoft.A2Zfiling.Persistence.Migrations.MSSQL
{
    public partial class _3rdmigrationn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Industry",
                table: "Industry");

            migrationBuilder.RenameTable(
                name: "Industry",
                newName: "Industries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Industries",
                table: "Industries",
                column: "IndustryId");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2025, 3, 22, 15, 37, 42, 703, DateTimeKind.Utc).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2025, 2, 22, 15, 37, 42, 703, DateTimeKind.Utc).AddTicks(5897));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2024, 9, 22, 15, 37, 42, 703, DateTimeKind.Utc).AddTicks(5919));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2025, 1, 22, 15, 37, 42, 703, DateTimeKind.Utc).AddTicks(6004));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2024, 9, 22, 15, 37, 42, 703, DateTimeKind.Utc).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2024, 11, 22, 15, 37, 42, 703, DateTimeKind.Utc).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 22, 15, 37, 42, 703, DateTimeKind.Utc).AddTicks(6056));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 22, 15, 37, 42, 703, DateTimeKind.Utc).AddTicks(6046));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 22, 15, 37, 42, 703, DateTimeKind.Utc).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 22, 15, 37, 42, 703, DateTimeKind.Utc).AddTicks(6035));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 22, 15, 37, 42, 703, DateTimeKind.Utc).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 22, 15, 37, 42, 703, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 22, 15, 37, 42, 703, DateTimeKind.Utc).AddTicks(6081));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Industries",
                table: "Industries");

            migrationBuilder.RenameTable(
                name: "Industries",
                newName: "Industry");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Industry",
                table: "Industry",
                column: "IndustryId");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2025, 3, 22, 15, 31, 31, 707, DateTimeKind.Utc).AddTicks(2977));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2025, 2, 22, 15, 31, 31, 707, DateTimeKind.Utc).AddTicks(2906));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2024, 9, 22, 15, 31, 31, 707, DateTimeKind.Utc).AddTicks(2957));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2025, 1, 22, 15, 31, 31, 707, DateTimeKind.Utc).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2024, 9, 22, 15, 31, 31, 707, DateTimeKind.Utc).AddTicks(2935));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2024, 11, 22, 15, 31, 31, 707, DateTimeKind.Utc).AddTicks(2733));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 22, 15, 31, 31, 707, DateTimeKind.Utc).AddTicks(3115));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 22, 15, 31, 31, 707, DateTimeKind.Utc).AddTicks(3092));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 22, 15, 31, 31, 707, DateTimeKind.Utc).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 22, 15, 31, 31, 707, DateTimeKind.Utc).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 22, 15, 31, 31, 707, DateTimeKind.Utc).AddTicks(3185));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 22, 15, 31, 31, 707, DateTimeKind.Utc).AddTicks(3137));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2024, 5, 22, 15, 31, 31, 707, DateTimeKind.Utc).AddTicks(3163));
        }
    }
}
