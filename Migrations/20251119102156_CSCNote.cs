using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSCNotes.Migrations
{
    /// <inheritdoc />
    public partial class CSCNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notes_Models",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes_Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Notes_Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes_Create_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    _Importance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notes_Models", x => x.UID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notes_Models");
        }
    }
}
