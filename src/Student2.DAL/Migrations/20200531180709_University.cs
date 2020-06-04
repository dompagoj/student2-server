using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Student2.DAL.Migrations
{
    public partial class University : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "university_id",
                table: "asp_net_users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "universities",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false),
                    domain = table.Column<string>(nullable: false),
                    full_name = table.Column<string>(nullable: false),
                    icon_url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_universities", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "686fb131-ca05-4a43-8df9-9a6eca134cbd");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "1c83a6f7-c712-4fb5-bafb-26887a8fd754");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "c627c216-aeb2-4573-979b-225f60852d87");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_university_id",
                table: "asp_net_users",
                column: "university_id");

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_users_universities_university_id",
                table: "asp_net_users",
                column: "university_id",
                principalTable: "universities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_users_universities_university_id",
                table: "asp_net_users");

            migrationBuilder.DropTable(
                name: "universities");

            migrationBuilder.DropIndex(
                name: "ix_asp_net_users_university_id",
                table: "asp_net_users");

            migrationBuilder.DropColumn(
                name: "university_id",
                table: "asp_net_users");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "cbc43880-44b4-4dd9-ae90-c95196ce61b1");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "0f4248ac-b4b2-445a-b57c-851a7ca00952");

            migrationBuilder.UpdateData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: 3,
                column: "concurrency_stamp",
                value: "da49a809-01b0-4ab7-b476-4a74a3baca8a");
        }
    }
}
