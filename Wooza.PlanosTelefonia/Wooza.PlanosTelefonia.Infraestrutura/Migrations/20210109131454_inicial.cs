using Microsoft.EntityFrameworkCore.Migrations;

namespace Wooza.PlanosTelefonia.Infraestrutura.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DDDs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(maxLength: 255, nullable: false),
                    Cidade = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDDs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operadoras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operadoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanosTelefonia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 255, nullable: false),
                    Minutos = table.Column<int>(nullable: false),
                    FranquiaInternet = table.Column<string>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DDDId = table.Column<int>(nullable: false),
                    OperadoraId = table.Column<int>(nullable: false),
                    TipoPlano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanosTelefonia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanosTelefonia_DDDs_DDDId",
                        column: x => x.DDDId,
                        principalTable: "DDDs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanosTelefonia_Operadoras_OperadoraId",
                        column: x => x.OperadoraId,
                        principalTable: "Operadoras",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DDDs",
                columns: new[] { "Id", "Cidade", "Codigo", "Estado" },
                values: new object[,]
                {
                    { 1, "Vitória", 27, "ES" },
                    { 2, "Serra", 27, "ES" },
                    { 3, "Vila Velha", 27, "ES" },
                    { 4, "Mantena", 33, "MG" },
                    { 5, "Governador Valadares", 33, "MG" },
                    { 6, "Araçuaí", 33, "MG" },
                    { 7, "Rio de Janeiro", 21, "RJ" },
                    { 8, "Juíz de Fora", 32, "MG" },
                    { 9, "Natal", 84, "RN" },
                    { 10, "Volta Redonda", 24, "RJ" }
                });

            migrationBuilder.InsertData(
                table: "Operadoras",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Vivo" },
                    { 2, "Oi" },
                    { 3, "Tim" },
                    { 4, "Claro" }
                });

            migrationBuilder.InsertData(
                table: "PlanosTelefonia",
                columns: new[] { "Id", "Codigo", "DDDId", "FranquiaInternet", "Minutos", "OperadoraId", "TipoPlano", "Valor" },
                values: new object[,]
                {
                    { 1, "Controle Vivo", 1, "4GB", 500, 1, 3, 39.90m },
                    { 16, "Controle Claro", 7, "4GB", 500, 4, 3, 39.90m },
                    { 20, "Controle Claro", 7, "4GB", 500, 3, 3, 39.90m },
                    { 19, "Pré Claro", 7, "2GB", 300, 3, 1, 22.90m },
                    { 15, "Controle TIM", 4, "4GB", 500, 3, 3, 39.90m },
                    { 14, "Pré TIM", 4, "2GB", 300, 3, 1, 22.90m },
                    { 13, "Pré TIM", 1, "2GB", 300, 3, 1, 30.00m },
                    { 12, "Pós TIM", 1, "10GB", 1000, 3, 2, 79.90m },
                    { 11, "Controle TIM", 7, "4GB", 500, 3, 3, 39.90m },
                    { 10, "Controle Oi", 7, "4GB", 500, 2, 3, 39.90m },
                    { 9, "Pré Oi", 1, "2GB", 300, 2, 1, 22.90m },
                    { 8, "Pré Oi", 7, "2GB", 300, 2, 1, 30.00m },
                    { 7, "Pós Oi", 7, "10GB", 1000, 2, 2, 79.90m },
                    { 6, "Controle Oi", 7, "4GB", 500, 2, 3, 39.90m },
                    { 5, "Controle Vivo", 4, "4GB", 500, 1, 3, 39.90m },
                    { 4, "Pré Vivo", 4, "2GB", 300, 1, 1, 21.90m },
                    { 3, "Pré Vivo", 1, "2GB", 300, 1, 1, 19.90m },
                    { 2, "Pós Vivo", 1, "10GB", 1000, 1, 2, 79.90m },
                    { 17, "Pós Claro", 1, "10GB", 1000, 4, 2, 79.90m },
                    { 18, "Pré Claro", 1, "2GB", 300, 4, 1, 30.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanosTelefonia_DDDId",
                table: "PlanosTelefonia",
                column: "DDDId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanosTelefonia_OperadoraId",
                table: "PlanosTelefonia",
                column: "OperadoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanosTelefonia");

            migrationBuilder.DropTable(
                name: "DDDs");

            migrationBuilder.DropTable(
                name: "Operadoras");
        }
    }
}
