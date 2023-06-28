using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zhipster.Internal.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BEZipCodes",
                columns: table => new
                {
                    BEZipCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    County = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LatitudeY = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LongitudeX = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RoutingCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TerminalID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsTypeBox = table.Column<bool>(type: "bit", nullable: false),
                    IsManuallyAddedZipCode = table.Column<bool>(type: "bit", nullable: false),
                    ZipCodeSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BEZipCodes", x => x.BEZipCodeId);
                });

            migrationBuilder.CreateTable(
                name: "DEZipCodes",
                columns: table => new
                {
                    DEZipCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    County = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LatitudeY = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LongitudeX = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RoutingCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TerminalID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsTypeBox = table.Column<bool>(type: "bit", nullable: false),
                    IsManuallyAddedZipCode = table.Column<bool>(type: "bit", nullable: false),
                    ZipCodeSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEZipCodes", x => x.DEZipCodeId);
                });

            migrationBuilder.CreateTable(
                name: "DKZipCodes",
                columns: table => new
                {
                    DKZipCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    County = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LatitudeY = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LongitudeX = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RoutingCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TerminalID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsTypeBox = table.Column<bool>(type: "bit", nullable: false),
                    IsManuallyAddedZipCode = table.Column<bool>(type: "bit", nullable: false),
                    ZipCodeSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DKZipCodes", x => x.DKZipCodeId);
                });

            migrationBuilder.CreateTable(
                name: "FIZipCodes",
                columns: table => new
                {
                    FIZipCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    County = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LatitudeY = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LongitudeX = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RoutingCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TerminalID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsTypeBox = table.Column<bool>(type: "bit", nullable: false),
                    IsManuallyAddedZipCode = table.Column<bool>(type: "bit", nullable: false),
                    ZipCodeSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FIZipCodes", x => x.FIZipCodeId);
                });

            migrationBuilder.CreateTable(
                name: "ForwarderZipCodeSources",
                columns: table => new
                {
                    ForwarderZipCodeSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ForwarderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZipCodeSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ForwarderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForwarderZipCodeSources", x => x.ForwarderZipCodeSourceId);
                });

            migrationBuilder.CreateTable(
                name: "FOZipCodes",
                columns: table => new
                {
                    FOZipCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    County = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LatitudeY = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LongitudeX = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RoutingCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TerminalID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsTypeBox = table.Column<bool>(type: "bit", nullable: false),
                    IsManuallyAddedZipCode = table.Column<bool>(type: "bit", nullable: false),
                    ZipCodeSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FOZipCodes", x => x.FOZipCodeId);
                });

            migrationBuilder.CreateTable(
                name: "GLZipCodes",
                columns: table => new
                {
                    GLZipCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    County = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LatitudeY = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LongitudeX = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RoutingCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TerminalID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsTypeBox = table.Column<bool>(type: "bit", nullable: false),
                    IsManuallyAddedZipCode = table.Column<bool>(type: "bit", nullable: false),
                    ZipCodeSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLZipCodes", x => x.GLZipCodeId);
                });

            migrationBuilder.CreateTable(
                name: "ISZipCodes",
                columns: table => new
                {
                    ISZipCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    County = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LatitudeY = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LongitudeX = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RoutingCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TerminalID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsTypeBox = table.Column<bool>(type: "bit", nullable: false),
                    IsManuallyAddedZipCode = table.Column<bool>(type: "bit", nullable: false),
                    ZipCodeSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISZipCodes", x => x.ISZipCodeId);
                });

            migrationBuilder.CreateTable(
                name: "NLZipCodes",
                columns: table => new
                {
                    NLZipCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    County = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LatitudeY = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LongitudeX = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RoutingCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TerminalID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsTypeBox = table.Column<bool>(type: "bit", nullable: false),
                    IsManuallyAddedZipCode = table.Column<bool>(type: "bit", nullable: false),
                    ZipCodeSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NLZipCodes", x => x.NLZipCodeId);
                });

            migrationBuilder.CreateTable(
                name: "NOZipCodes",
                columns: table => new
                {
                    NOZipCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    County = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LatitudeY = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LongitudeX = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RoutingCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TerminalID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsTypeBox = table.Column<bool>(type: "bit", nullable: false),
                    IsManuallyAddedZipCode = table.Column<bool>(type: "bit", nullable: false),
                    ZipCodeSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOZipCodes", x => x.NOZipCodeId);
                });

            migrationBuilder.CreateTable(
                name: "SEZipCodes",
                columns: table => new
                {
                    SEZipCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    County = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LatitudeY = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LongitudeX = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RoutingCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TerminalID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsTypeBox = table.Column<bool>(type: "bit", nullable: false),
                    IsManuallyAddedZipCode = table.Column<bool>(type: "bit", nullable: false),
                    ZipCodeSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEZipCodes", x => x.SEZipCodeId);
                });

            migrationBuilder.CreateTable(
                name: "SJZipCodes",
                columns: table => new
                {
                    SJZipCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    County = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LatitudeY = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LongitudeX = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RoutingCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TerminalID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsTypeBox = table.Column<bool>(type: "bit", nullable: false),
                    IsManuallyAddedZipCode = table.Column<bool>(type: "bit", nullable: false),
                    ZipCodeSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SJZipCodes", x => x.SJZipCodeId);
                });

            migrationBuilder.CreateTable(
                name: "USZipCodes",
                columns: table => new
                {
                    USZipCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    County = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StateCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    LatitudeY = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LongitudeX = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RoutingCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TerminalID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsTypeBox = table.Column<bool>(type: "bit", nullable: false),
                    IsManuallyAddedZipCode = table.Column<bool>(type: "bit", nullable: false),
                    ZipCodeSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USZipCodes", x => x.USZipCodeId);
                });

            migrationBuilder.CreateTable(
                name: "ZipCodeSources",
                columns: table => new
                {
                    ZipCodeSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SourceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    APILink = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SourceRecordCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCodeSources", x => x.ZipCodeSourceId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BEZipCodes");

            migrationBuilder.DropTable(
                name: "DEZipCodes");

            migrationBuilder.DropTable(
                name: "DKZipCodes");

            migrationBuilder.DropTable(
                name: "FIZipCodes");

            migrationBuilder.DropTable(
                name: "ForwarderZipCodeSources");

            migrationBuilder.DropTable(
                name: "FOZipCodes");

            migrationBuilder.DropTable(
                name: "GLZipCodes");

            migrationBuilder.DropTable(
                name: "ISZipCodes");

            migrationBuilder.DropTable(
                name: "NLZipCodes");

            migrationBuilder.DropTable(
                name: "NOZipCodes");

            migrationBuilder.DropTable(
                name: "SEZipCodes");

            migrationBuilder.DropTable(
                name: "SJZipCodes");

            migrationBuilder.DropTable(
                name: "USZipCodes");

            migrationBuilder.DropTable(
                name: "ZipCodeSources");
        }
    }
}
