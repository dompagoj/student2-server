using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Student2.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "asp_net_roles",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("pk_asp_net_roles", x => x.id); });

            migrationBuilder.CreateTable(
                "asp_net_users",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(maxLength: 256, nullable: true),
                    email = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(nullable: false),
                    password_hash = table.Column<string>(nullable: true),
                    security_stamp = table.Column<string>(nullable: true),
                    concurrency_stamp = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    phone_number_confirmed = table.Column<bool>(nullable: false),
                    two_factor_enabled = table.Column<bool>(nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(nullable: true),
                    lockout_enabled = table.Column<bool>(nullable: false),
                    access_failed_count = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("pk_asp_net_users", x => x.id); });

            migrationBuilder.CreateTable(
                "asp_net_role_claims",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<int>(nullable: false),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        "fk_asp_net_role_claims_asp_net_roles_role_id",
                        x => x.role_id,
                        "asp_net_roles",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "asp_net_user_claims",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(nullable: false),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        "fk_asp_net_user_claims_asp_net_users_user_id",
                        x => x.user_id,
                        "asp_net_users",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "asp_net_user_logins",
                table => new
                {
                    login_provider = table.Column<string>(nullable: false),
                    provider_key = table.Column<string>(nullable: false),
                    provider_display_name = table.Column<string>(nullable: true),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new {x.login_provider, x.provider_key});
                    table.ForeignKey(
                        "fk_asp_net_user_logins_asp_net_users_user_id",
                        x => x.user_id,
                        "asp_net_users",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "asp_net_user_roles",
                table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new {x.user_id, x.role_id});
                    table.ForeignKey(
                        "fk_asp_net_user_roles_asp_net_roles_role_id",
                        x => x.role_id,
                        "asp_net_roles",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "fk_asp_net_user_roles_asp_net_users_user_id",
                        x => x.user_id,
                        "asp_net_users",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "asp_net_user_tokens",
                table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    login_provider = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new {x.user_id, x.login_provider, x.name});
                    table.ForeignKey(
                        "fk_asp_net_user_tokens_asp_net_users_user_id",
                        x => x.user_id,
                        "asp_net_users",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                "asp_net_roles",
                new[] {"id", "concurrency_stamp", "name", "normalized_name"},
                new object[,]
                {
                    {1, "cbc43880-44b4-4dd9-ae90-c95196ce61b1", "Admin", "ADMIN"},
                    {2, "0f4248ac-b4b2-445a-b57c-851a7ca00952", "Editor", "EDITOR"},
                    {3, "da49a809-01b0-4ab7-b476-4a74a3baca8a", "Regular", "REGULAR"}
                });

            migrationBuilder.CreateIndex(
                "ix_asp_net_role_claims_role_id",
                "asp_net_role_claims",
                "role_id");

            migrationBuilder.CreateIndex(
                "role_name_index",
                "asp_net_roles",
                "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                "ix_asp_net_user_claims_user_id",
                "asp_net_user_claims",
                "user_id");

            migrationBuilder.CreateIndex(
                "ix_asp_net_user_logins_user_id",
                "asp_net_user_logins",
                "user_id");

            migrationBuilder.CreateIndex(
                "ix_asp_net_user_roles_role_id",
                "asp_net_user_roles",
                "role_id");

            migrationBuilder.CreateIndex(
                "email_index",
                "asp_net_users",
                "normalized_email",
                unique: true);

            migrationBuilder.CreateIndex(
                "user_name_index",
                "asp_net_users",
                "normalized_user_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "asp_net_role_claims");

            migrationBuilder.DropTable(
                "asp_net_user_claims");

            migrationBuilder.DropTable(
                "asp_net_user_logins");

            migrationBuilder.DropTable(
                "asp_net_user_roles");

            migrationBuilder.DropTable(
                "asp_net_user_tokens");

            migrationBuilder.DropTable(
                "asp_net_roles");

            migrationBuilder.DropTable(
                "asp_net_users");
        }
    }
}