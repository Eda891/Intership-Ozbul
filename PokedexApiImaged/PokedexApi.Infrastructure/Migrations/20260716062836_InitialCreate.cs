using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokedexApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Height = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Abilities = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Weaknesses = table.Column<string>(type: "TEXT", nullable: false),
                    FlavorText = table.Column<string>(type: "TEXT", nullable: false),
                    Stats_Hp = table.Column<int>(type: "INTEGER", nullable: false),
                    Stats_Attack = table.Column<int>(type: "INTEGER", nullable: false),
                    Stats_Defense = table.Column<int>(type: "INTEGER", nullable: false),
                    Stats_SpecialAttack = table.Column<int>(type: "INTEGER", nullable: false),
                    Stats_SpecialDefense = table.Column<int>(type: "INTEGER", nullable: false),
                    Stats_Speed = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemons");
        }
    }
}
