using Microsoft.EntityFrameworkCore.Migrations;

namespace Student2.DAL.Migrations
{
    public partial class TutorUniversityRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "university_id",
                table: "tutor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "31918a87-696d-4b41-9051-63db9811b93b");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "7d18c31e-349c-44c2-a7bd-1638831620d6");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "21d1e213-82fe-4069-b4d7-b0114c1518a8");

            migrationBuilder.CreateIndex(
                name: "ix_tutor_university_id",
                table: "tutor",
                column: "university_id");

            migrationBuilder.AddForeignKey(
                name: "fk_tutor_universities_university_id",
                table: "tutor",
                column: "university_id",
                principalTable: "universities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tutor_universities_university_id",
                table: "tutor");

            migrationBuilder.DropIndex(
                name: "ix_tutor_university_id",
                table: "tutor");

            migrationBuilder.DropColumn(
                name: "university_id",
                table: "tutor");

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
    }
}
