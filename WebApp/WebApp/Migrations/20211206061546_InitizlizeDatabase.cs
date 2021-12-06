using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class InitizlizeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bodies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNumber = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaceTypeId = table.Column<int>(type: "int", nullable: false),
                    BodyId = table.Column<int>(type: "int", nullable: true),
                    Lod = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faces_Bodies_BodyId",
                        column: x => x.BodyId,
                        principalTable: "Bodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Faces_FaceTypes_FaceTypeId",
                        column: x => x.FaceTypeId,
                        principalTable: "FaceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineTypeId = table.Column<int>(type: "int", nullable: false),
                    BodyId = table.Column<int>(type: "int", nullable: true),
                    Lod = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lines_Bodies_BodyId",
                        column: x => x.BodyId,
                        principalTable: "Bodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Lines_LineTypes_LineTypeId",
                        column: x => x.LineTypeId,
                        principalTable: "LineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaceTypeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaceTypeId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceTypeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaceTypeOptions_FaceTypes_FaceTypeId",
                        column: x => x.FaceTypeId,
                        principalTable: "FaceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaceTypeOptions_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineTypeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineTypeId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineTypeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineTypeOptions_LineTypes_LineTypeId",
                        column: x => x.LineTypeId,
                        principalTable: "LineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineTypeOptions_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointTypeId = table.Column<int>(type: "int", nullable: false),
                    BodyId = table.Column<int>(type: "int", nullable: true),
                    Lod = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Points_Bodies_BodyId",
                        column: x => x.BodyId,
                        principalTable: "Bodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Points_PointTypes_PointTypeId",
                        column: x => x.PointTypeId,
                        principalTable: "PointTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointTypeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointTypeId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointTypeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointTypeOptions_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PointTypeOptions_PointTypes_PointTypeId",
                        column: x => x.PointTypeId,
                        principalTable: "PointTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaceTypeOptionValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaceTypeOptionId = table.Column<int>(type: "int", nullable: false),
                    FaceId = table.Column<int>(type: "int", nullable: false),
                    ValueN = table.Column<double>(type: "float", nullable: false),
                    ValueS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceTypeOptionValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaceTypeOptionValues_Faces_FaceId",
                        column: x => x.FaceId,
                        principalTable: "Faces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineTypeOptionValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineTypeOptionId = table.Column<int>(type: "int", nullable: false),
                    LineId = table.Column<int>(type: "int", nullable: false),
                    ValueN = table.Column<double>(type: "float", nullable: false),
                    ValueS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineTypeOptionValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineTypeOptionValues_Lines_LineId",
                        column: x => x.LineId,
                        principalTable: "Lines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaceId = table.Column<int>(type: "int", nullable: true),
                    LineId = table.Column<int>(type: "int", nullable: true),
                    PointId = table.Column<int>(type: "int", nullable: true),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false),
                    Z = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nodes_Faces_FaceId",
                        column: x => x.FaceId,
                        principalTable: "Faces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nodes_Lines_LineId",
                        column: x => x.LineId,
                        principalTable: "Lines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nodes_Points_PointId",
                        column: x => x.PointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointTypeOptionValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointTypeOptionId = table.Column<int>(type: "int", nullable: false),
                    PointId = table.Column<int>(type: "int", nullable: false),
                    ValueN = table.Column<double>(type: "float", nullable: false),
                    ValueS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointTypeOptionValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointTypeOptionValues_Points_PointId",
                        column: x => x.PointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "color" });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsNumber", "Name" },
                values: new object[,]
                {
                    { 2, true, "sizeWidth" },
                    { 3, true, "sizeHeight" },
                    { 4, true, "sizeDepth" },
                    { 5, true, "rotateX" },
                    { 6, true, "rotateY" },
                    { 7, true, "rotateZ" },
                    { 8, true, "minHeight" },
                    { 9, true, "maxHeight" },
                    { 10, true, "n" },
                    { 11, true, "width" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "outlineColor" });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsNumber", "Name" },
                values: new object[,]
                {
                    { 13, true, "outlineWidth" },
                    { 14, true, "m" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faces_BodyId",
                table: "Faces",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Faces_FaceTypeId",
                table: "Faces",
                column: "FaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceTypeOptions_FaceTypeId",
                table: "FaceTypeOptions",
                column: "FaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceTypeOptions_OptionId",
                table: "FaceTypeOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceTypeOptionValues_FaceId",
                table: "FaceTypeOptionValues",
                column: "FaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Lines_BodyId",
                table: "Lines",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Lines_LineTypeId",
                table: "Lines",
                column: "LineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LineTypeOptions_LineTypeId",
                table: "LineTypeOptions",
                column: "LineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LineTypeOptions_OptionId",
                table: "LineTypeOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_LineTypeOptionValues_LineId",
                table: "LineTypeOptionValues",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_FaceId",
                table: "Nodes",
                column: "FaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_LineId",
                table: "Nodes",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_PointId",
                table: "Nodes",
                column: "PointId",
                unique: true,
                filter: "[PointId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Points_BodyId",
                table: "Points",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_PointTypeId",
                table: "Points",
                column: "PointTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PointTypeOptions_OptionId",
                table: "PointTypeOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PointTypeOptions_PointTypeId",
                table: "PointTypeOptions",
                column: "PointTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PointTypeOptionValues_PointId",
                table: "PointTypeOptionValues",
                column: "PointId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaceTypeOptions");

            migrationBuilder.DropTable(
                name: "FaceTypeOptionValues");

            migrationBuilder.DropTable(
                name: "LineTypeOptions");

            migrationBuilder.DropTable(
                name: "LineTypeOptionValues");

            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "PointTypeOptions");

            migrationBuilder.DropTable(
                name: "PointTypeOptionValues");

            migrationBuilder.DropTable(
                name: "Faces");

            migrationBuilder.DropTable(
                name: "Lines");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "FaceTypes");

            migrationBuilder.DropTable(
                name: "LineTypes");

            migrationBuilder.DropTable(
                name: "Bodies");

            migrationBuilder.DropTable(
                name: "PointTypes");
        }
    }
}
