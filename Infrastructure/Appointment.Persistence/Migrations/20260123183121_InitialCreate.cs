using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Appointment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Departments_DepartmentId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Cities_CityId1",
                table: "Hospitals");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_CityId1",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "11");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "12");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "13");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "14");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "15");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "16");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "17");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "18");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "19");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "20");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "21");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "22");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "23");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "24");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "25");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "26");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "27");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "28");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "29");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "30");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "31");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "32");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "33");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "34");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "35");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "36");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "37");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "38");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "39");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "40");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "41");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "42");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "43");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "44");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "45");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "46");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "47");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "48");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "49");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "50");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "51");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "52");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "53");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "54");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "55");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "56");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "57");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "58");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "59");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "60");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "61");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "62");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "63");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "64");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "65");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "66");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "67");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "68");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "69");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "70");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "71");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "72");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "73");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "74");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "75");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "76");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "77");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "78");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "79");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "80");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "81");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Appointments",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                newName: "IX_Appointments_PatientId");

            migrationBuilder.AlterColumn<string>(
                name: "CityId",
                table: "Hospitals",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Cities",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Cities",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TCKimlikNo",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adana", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adıyaman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afyonkarahisar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ağrı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aksaray", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000006", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amasya", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000007", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ankara", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000008", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antalya", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000009", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ardahan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000010", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Artvin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000011", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aydın", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000012", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Balıkesir", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000013", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bartın", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000014", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000015", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bayburt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000016", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bilecik", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000017", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bingöl", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000018", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bitlis", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000019", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bolu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000020", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burdur", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000021", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bursa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000022", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çanakkale", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000023", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çankırı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000024", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çorum", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000025", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denizli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000026", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diyarbakır", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000027", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Düzce", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000028", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edirne", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000029", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elazığ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000030", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Erzincan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000031", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Erzurum", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000032", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eskişehir", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000033", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaziantep", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000034", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giresun", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000035", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gümüşhane", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000036", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hakkari", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000037", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hatay", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000038", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iğdır", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000039", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isparta", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000040", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İstanbul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000041", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İzmir", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000042", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kahramanmaraş", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000043", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karabük", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000044", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karaman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000045", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kars", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000046", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kastamonu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000047", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kayseri", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000048", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kilis", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000049", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kırıkkale", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000050", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kırklareli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000051", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kırşehir", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000052", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kocaeli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000053", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Konya", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000054", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kütahya", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000055", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malatya", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000056", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manisa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000057", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mardin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000058", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mersin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000059", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Muğla", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000060", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Muş", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000061", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nevşehir", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000062", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niğde", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000063", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ordu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000064", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Osmaniye", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000065", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rize", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000066", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sakarya", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000067", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samsun", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000068", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şanlıurfa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000069", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Siirt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000070", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinop", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000071", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sivas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000072", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şırnak", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000073", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tekirdağ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000074", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tokat", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000075", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trabzon", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000076", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tunceli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000077", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uşak", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000078", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Van", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000079", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yalova", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000080", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yozgat", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "00000000-0000-0000-0000-000000000081", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zonguldak", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_CityId",
                table: "Hospitals",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Cities_CityId",
                table: "Hospitals",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Cities_CityId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_CityId",
                table: "Hospitals");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000005");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000006");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000007");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000008");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000009");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000011");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000012");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000013");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000014");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000015");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000016");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000017");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000018");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000019");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000022");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000023");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000024");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000025");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000026");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000027");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000028");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000029");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000030");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000031");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000032");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000033");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000034");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000035");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000036");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000037");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000038");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000039");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000040");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000041");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000042");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000043");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000044");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000045");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000046");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000047");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000048");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000049");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000050");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000051");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000052");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000053");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000054");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000055");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000056");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000057");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000058");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000059");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000060");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000061");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000062");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000063");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000064");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000065");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000066");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000067");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000068");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000069");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000070");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000071");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000072");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000073");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000074");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000075");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000076");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000077");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000078");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000079");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000080");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000081");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "TCKimlikNo",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Appointments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                newName: "IX_Appointments_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Hospitals",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "CityId1",
                table: "Hospitals",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentId",
                table: "Doctors",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "Adana" },
                    { "10", "Artvin" },
                    { "11", "Aydın" },
                    { "12", "Balıkesir" },
                    { "13", "Bartın" },
                    { "14", "Batman" },
                    { "15", "Bayburt" },
                    { "16", "Bilecik" },
                    { "17", "Bingöl" },
                    { "18", "Bitlis" },
                    { "19", "Bolu" },
                    { "2", "Adıyaman" },
                    { "20", "Burdur" },
                    { "21", "Bursa" },
                    { "22", "Çanakkale" },
                    { "23", "Çankırı" },
                    { "24", "Çorum" },
                    { "25", "Denizli" },
                    { "26", "Diyarbakır" },
                    { "27", "Düzce" },
                    { "28", "Edirne" },
                    { "29", "Elazığ" },
                    { "3", "Afyonkarahisar" },
                    { "30", "Erzincan" },
                    { "31", "Erzurum" },
                    { "32", "Eskişehir" },
                    { "33", "Gaziantep" },
                    { "34", "Giresun" },
                    { "35", "Gümüşhane" },
                    { "36", "Hakkari" },
                    { "37", "Hatay" },
                    { "38", "Iğdır" },
                    { "39", "Isparta" },
                    { "4", "Ağrı" },
                    { "40", "İstanbul" },
                    { "41", "İzmir" },
                    { "42", "Kahramanmaraş" },
                    { "43", "Karabük" },
                    { "44", "Karaman" },
                    { "45", "Kars" },
                    { "46", "Kastamonu" },
                    { "47", "Kayseri" },
                    { "48", "Kilis" },
                    { "49", "Kırıkkale" },
                    { "5", "Aksaray" },
                    { "50", "Kırklareli" },
                    { "51", "Kırşehir" },
                    { "52", "Kocaeli" },
                    { "53", "Konya" },
                    { "54", "Kütahya" },
                    { "55", "Malatya" },
                    { "56", "Manisa" },
                    { "57", "Mardin" },
                    { "58", "Mersin" },
                    { "59", "Muğla" },
                    { "6", "Amasya" },
                    { "60", "Muş" },
                    { "61", "Nevşehir" },
                    { "62", "Niğde" },
                    { "63", "Ordu" },
                    { "64", "Osmaniye" },
                    { "65", "Rize" },
                    { "66", "Sakarya" },
                    { "67", "Samsun" },
                    { "68", "Şanlıurfa" },
                    { "69", "Siirt" },
                    { "7", "Ankara" },
                    { "70", "Sinop" },
                    { "71", "Sivas" },
                    { "72", "Şırnak" },
                    { "73", "Tekirdağ" },
                    { "74", "Tokat" },
                    { "75", "Trabzon" },
                    { "76", "Tunceli" },
                    { "77", "Uşak" },
                    { "78", "Van" },
                    { "79", "Yalova" },
                    { "8", "Antalya" },
                    { "80", "Yozgat" },
                    { "81", "Zonguldak" },
                    { "9", "Ardahan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_CityId1",
                table: "Hospitals",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Departments_DepartmentId",
                table: "Doctors",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Cities_CityId1",
                table: "Hospitals",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
