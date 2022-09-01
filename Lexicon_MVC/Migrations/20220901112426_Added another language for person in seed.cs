using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lexicon_MVC.Migrations
{
    public partial class Addedanotherlanguageforpersoninseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LanguagePerson",
                columns: new[] { "LanguagesLanguageId", "PeoplePersonId" },
                values: new object[] { 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguagesLanguageId", "PeoplePersonId" },
                keyValues: new object[] { 1, 2 });
        }
    }
}
