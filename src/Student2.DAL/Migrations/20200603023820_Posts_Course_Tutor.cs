using Microsoft.EntityFrameworkCore.Migrations;

namespace Student2.DAL.Migrations
{
    public partial class Posts_Course_Tutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_posts_course_class_id",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "ix_posts_class_id",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "class_id",
                table: "posts");

            migrationBuilder.AddColumn<int>(
                name: "course_id",
                table: "posts",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "1a09354b-c26d-4de6-9bbf-12a703743003");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "d1691c3d-10fe-4625-979c-4767d2e5585b");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "da1e689d-4e4f-418d-a7cc-54d69e4fe11a");

            migrationBuilder.CreateIndex(
                name: "ix_posts_course_id",
                table: "posts",
                column: "course_id");

            migrationBuilder.AddForeignKey(
                name: "fk_posts_course_course_id",
                table: "posts",
                column: "course_id",
                principalTable: "course",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_posts_course_course_id",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "ix_posts_course_id",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "course_id",
                table: "posts");

            migrationBuilder.AddColumn<int>(
                name: "class_id",
                table: "posts",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "36a22c1d-7d52-4ff9-a1d9-b51fee4f21f8");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "2ee37891-3ba5-4cb9-9378-b3a62abd84b3");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "9ff54eb2-60f3-4d7c-8ab5-eb97526f36f2");

            migrationBuilder.CreateIndex(
                name: "ix_posts_class_id",
                table: "posts",
                column: "class_id");

            migrationBuilder.AddForeignKey(
                name: "fk_posts_course_class_id",
                table: "posts",
                column: "class_id",
                principalTable: "course",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
