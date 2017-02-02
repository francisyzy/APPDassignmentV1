using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APPDassignmentV1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "region",
                columns: table => new
                {
                    regionId = table.Column<int>(nullable: false),
                    regionName = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_region", x => x.regionId);
                });

            migrationBuilder.CreateTable(
                name: "resourceType",
                columns: table => new
                {
                    resourceTypeId = table.Column<int>(nullable: false),
                    resourceTypeName = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resourceType", x => x.resourceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "resource",
                columns: table => new
                {
                    resourceId = table.Column<string>(type: "varchar(4)", nullable: false),
                    aircon = table.Column<byte>(nullable: false),
                    fulladdress = table.Column<string>(type: "varchar(200)", nullable: false),
                    picture = table.Column<byte[]>(nullable: true),
                    postalCode = table.Column<int>(nullable: false),
                    price = table.Column<short>(nullable: false),
                    regionId = table.Column<int>(nullable: false),
                    resourceSize = table.Column<short>(nullable: false),
                    resourceTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resource", x => x.resourceId);
                    table.ForeignKey(
                        name: "FK__resource__region__0E6E26BF",
                        column: x => x.regionId,
                        principalTable: "region",
                        principalColumn: "regionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__resource__resour__0F624AF8",
                        column: x => x.resourceTypeId,
                        principalTable: "resourceType",
                        principalColumn: "resourceTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "booking",
                columns: table => new
                {
                    bookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bookingDate = table.Column<DateTime>(type: "date", nullable: false),
                    bookingEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    bookingStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    resourceId = table.Column<string>(type: "varchar(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking", x => x.bookingId);
                    table.ForeignKey(
                        name: "FK__booking__resourc__0C85DE4D",
                        column: x => x.resourceId,
                        principalTable: "resource",
                        principalColumn: "resourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_booking_resourceId",
                table: "booking",
                column: "resourceId");

            migrationBuilder.CreateIndex(
                name: "IX_resource_regionId",
                table: "resource",
                column: "regionId");

            migrationBuilder.CreateIndex(
                name: "IX_resource_resourceTypeId",
                table: "resource",
                column: "resourceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "booking");

            migrationBuilder.DropTable(
                name: "resource");

            migrationBuilder.DropTable(
                name: "region");

            migrationBuilder.DropTable(
                name: "resourceType");
        }
    }
}
