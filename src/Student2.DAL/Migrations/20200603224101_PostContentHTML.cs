using Microsoft.EntityFrameworkCore.Migrations;

namespace Student2.DAL.Migrations
{
    public partial class PostContentHTML : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "posts",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "content",
                table: "posts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "content_html",
                table: "posts",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "350de7c5-77c4-4908-9524-9fdd898ba3ec");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "bf391e95-7e7e-4fa7-b171-d5a6c0f390c8");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "6bbaf1b6-8bb9-4cb0-b4b8-6796903f0cbb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "content_html",
                table: "posts");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "posts",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "content",
                table: "posts",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "16c7e5ea-f8fc-489e-9c89-5b7f067dcc7e");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "e97839c3-cedd-4463-a2f9-fdb8b028ceea");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "86922c21-d811-4d1a-a48e-8df233600772");
        }
    }
}
