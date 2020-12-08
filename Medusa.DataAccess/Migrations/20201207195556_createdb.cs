using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medusa.DataAccess.Migrations
{
    public partial class createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "tAppUser",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Surname = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tAppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tCategory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tBlog",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    ShortDescription = table.Column<string>(type: "ntext", maxLength: 300, nullable: true),
                    LongDescription = table.Column<string>(type: "ntext", nullable: true),
                    PostedTime = table.Column<DateTime>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 300, nullable: true),
                    AppUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tBlog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tBlog_tAppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "dbo",
                        principalTable: "tAppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tCategoryBlog",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BlogId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tCategoryBlog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tCategoryBlog_tBlog_BlogId",
                        column: x => x.BlogId,
                        principalSchema: "dbo",
                        principalTable: "tBlog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tCategoryBlog_tCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "tCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tComment",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AuthorName = table.Column<string>(maxLength: 100, nullable: false),
                    AuthorEmail = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "ntext", maxLength: 400, nullable: false),
                    PostedTime = table.Column<DateTime>(nullable: false),
                    ParentCommentId = table.Column<int>(nullable: true),
                    BlogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tComment_tBlog_BlogId",
                        column: x => x.BlogId,
                        principalSchema: "dbo",
                        principalTable: "tBlog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tComment_tComment_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalSchema: "dbo",
                        principalTable: "tComment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tBlog_AppUserId",
                schema: "dbo",
                table: "tBlog",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tCategoryBlog_BlogId",
                schema: "dbo",
                table: "tCategoryBlog",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_tCategoryBlog_CategoryId_BlogId",
                schema: "dbo",
                table: "tCategoryBlog",
                columns: new[] { "CategoryId", "BlogId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tComment_BlogId",
                schema: "dbo",
                table: "tComment",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_tComment_ParentCommentId",
                schema: "dbo",
                table: "tComment",
                column: "ParentCommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tCategoryBlog",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tComment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tBlog",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tAppUser",
                schema: "dbo");
        }
    }
}
