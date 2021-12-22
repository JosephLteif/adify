using Microsoft.EntityFrameworkCore.Migrations;

namespace AdifyCMS.Migrations
{
    public partial class addedUserIdToCampaignModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clicks_Analytics_AnalyticsId",
                table: "Clicks");

            migrationBuilder.DropForeignKey(
                name: "FK_Views_Analytics_AnalyticsId",
                table: "Views");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Views",
                table: "Views");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clicks",
                table: "Clicks");

            migrationBuilder.RenameTable(
                name: "Views",
                newName: "View");

            migrationBuilder.RenameTable(
                name: "Clicks",
                newName: "Click");

            migrationBuilder.RenameIndex(
                name: "IX_Views_AnalyticsId",
                table: "View",
                newName: "IX_View_AnalyticsId");

            migrationBuilder.RenameIndex(
                name: "IX_Clicks_AnalyticsId",
                table: "Click",
                newName: "IX_Click_AnalyticsId");

            migrationBuilder.AddColumn<string>(
                name: "userid",
                table: "Campaign",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_View",
                table: "View",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Click",
                table: "Click",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Click_Analytics_AnalyticsId",
                table: "Click",
                column: "AnalyticsId",
                principalTable: "Analytics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_View_Analytics_AnalyticsId",
                table: "View",
                column: "AnalyticsId",
                principalTable: "Analytics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Click_Analytics_AnalyticsId",
                table: "Click");

            migrationBuilder.DropForeignKey(
                name: "FK_View_Analytics_AnalyticsId",
                table: "View");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_View",
                table: "View");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Click",
                table: "Click");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Campaign");

            migrationBuilder.RenameTable(
                name: "View",
                newName: "Views");

            migrationBuilder.RenameTable(
                name: "Click",
                newName: "Clicks");

            migrationBuilder.RenameIndex(
                name: "IX_View_AnalyticsId",
                table: "Views",
                newName: "IX_Views_AnalyticsId");

            migrationBuilder.RenameIndex(
                name: "IX_Click_AnalyticsId",
                table: "Clicks",
                newName: "IX_Clicks_AnalyticsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Views",
                table: "Views",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clicks",
                table: "Clicks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clicks_Analytics_AnalyticsId",
                table: "Clicks",
                column: "AnalyticsId",
                principalTable: "Analytics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Views_Analytics_AnalyticsId",
                table: "Views",
                column: "AnalyticsId",
                principalTable: "Analytics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
