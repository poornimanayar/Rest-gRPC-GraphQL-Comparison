using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQL.Demo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Headline = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StoryOwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stories_Users_StoryOwnerId",
                        column: x => x.StoryOwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    StoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommenterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_CommenterId",
                        column: x => x.CommenterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Headline", "Name" },
                values: new object[] { 1, "The boy who lived", "Harry Potter" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Headline", "Name" },
                values: new object[] { 2, "Super Auror", "Ronald Weasley" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Headline", "Name" },
                values: new object[] { 3, "Books", "Hermione Granger" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Headline", "Name" },
                values: new object[] { 4, "Headmaster, Hogwarts", "Albus Dumbledore" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Headline", "Name" },
                values: new object[] { 5, "The boy who lived", "Neville Longbottom" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Headline", "Name" },
                values: new object[] { 6, "Gryffindor", "Professor Minerva McGonagall" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Headline", "Name" },
                values: new object[] { 7, "Proud Centaur", "Firenze" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Headline", "Name" },
                values: new object[] { 8, "Hogwarts Gamekeeper", "Hagrid" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Headline", "Name" },
                values: new object[] { 9, "The Half-Blood Prince", "Severus Snape" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Headline", "Name" },
                values: new object[] { 10, "Darkness", "Lord Voldemort" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Description", "StoryOwnerId", "Title" },
                values: new object[] { 1, "Life at Privet Drive is not that great!", 1, "Life at Privet Drive" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Description", "StoryOwnerId", "Title" },
                values: new object[] { 2, "I get a letter from Hogwarts, I am surprised!", 1, "I get a letter from Hogwarts" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Description", "StoryOwnerId", "Title" },
                values: new object[] { 3, "Uncle Vernon tore the letter which came from Hogwarts", 1, "Uncle Vernon tore the letter" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Description", "StoryOwnerId", "Title" },
                values: new object[] { 4, "The house is flooded with letters from Hogwarts", 1, "Many more letters arrive" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Description", "StoryOwnerId", "Title" },
                values: new object[] { 5, "We go to an island to escape from the letters", 1, "We go to an island" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Description", "StoryOwnerId", "Title" },
                values: new object[] { 6, "Hagrid, the gamekeeper of Hogwarts, turns up with my birthday cake and a letter from Hogwarts", 1, "Hagrid turns up" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Description", "StoryOwnerId", "Title" },
                values: new object[] { 7, "I just got to know from Hagrid that I am a wizard!", 1, "I am a WIZARD!" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Description", "StoryOwnerId", "Title" },
                values: new object[] { 8, "I visit DiagonAlley to purchase essentials for my school", 1, "I visit DiagonAlley" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Description", "StoryOwnerId", "Title" },
                values: new object[] { 9, "Lord Voldemort is back", 10, "I am back" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommenterId", "Description", "StoryId" },
                values: new object[] { 1, 4, "Welcome to Hogwarts, Harry!", 7 });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommenterId",
                table: "Comments",
                column: "CommenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StoryId",
                table: "Comments",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_StoryOwnerId",
                table: "Stories",
                column: "StoryOwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Stories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
