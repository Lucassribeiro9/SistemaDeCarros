using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarrosMvc.Migrations
{
    /// <inheritdoc />
    public partial class Incial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroChassi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroMotor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustoProducao = table.Column<double>(type: "float", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadeCarga = table.Column<double>(type: "float", nullable: true),
                    VolumeCacamba = table.Column<double>(type: "float", nullable: true),
                    Potencia = table.Column<double>(type: "float", nullable: true),
                    DuracaoBateria = table.Column<double>(type: "float", nullable: true),
                    NumeroPortas = table.Column<int>(type: "int", nullable: true),
                    Cilindrada = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");
        }
    }
}
