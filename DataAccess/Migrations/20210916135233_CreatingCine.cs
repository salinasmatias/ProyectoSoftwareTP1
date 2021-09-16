using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class CreatingCine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionId);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Ticket", x => new { x.TicketId, x.FuncionId });
                    table.ForeignKey(
                        name: "FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 1, "https://i.blogs.es/ec18b1/batman-robin-poster/450_1000.jpg", "Batman and Robin try to prevent the evil pair of Mr Freeze and Poison Ivy from freezing the town. While doing so, they also try hard to continue their partnership.", "Batman & Robin", "https://www.youtube.com/watch?v=0-GIJSZ2GAk" },
                    { 2, "https://m.media-amazon.com/images/I/71kgvHY5G1L._AC_SY679_.jpg", "An extraterrestrial hedgehog is discovered by a scientist with evil intentions and plans to use his superpowers for his selfish needs.", "Sonic The Hedgehog", "https://www.youtube.com/watch?v=szby7ZHLnkA" },
                    { 3, "https://cdn.europosters.eu/image/750/posters/lord-of-the-rings-fellowship-i11723.jpg", "A young hobbit, Frodo, who has found the One Ring that belongs to the Dark Lord Sauron, begins his journey with eight companions to Mount Doom, the only place where it can be destroyed.", "The Lord of the Rings", "https://www.youtube.com/watch?v=V75dMMIW2B4" },
                    { 4, "https://m.media-amazon.com/images/I/A1T+lZ6iUZL._SL1500_.jpg", "Eight-year-old Kevin is accidentally left behind when his family leaves for France. At first, he is happy to be in charge, but when thieves try to break into his home, he tries to put up a fight.", "Home Alone", "https://www.youtube.com/watch?v=jEDaVHmw7r4" },
                    { 5, "https://oldies-cdn.freetls.fastly.net/i/boxart/w340/a-z/x/xwb4310d.jpg?v=3", "Three martial arts warriors journey to a faraway island to engage in battle to save the Earth. Their aim is to make sure that truth triumphs in the fight against evil.", "Mortal Kombat", "https://www.youtube.com/watch?v=JHIfHL5UgFs" },
                    { 6, "https://m.media-amazon.com/images/I/61VX0X7EGDL._SY445_.jpg", "Superstar LeBron James and his young son, Dom, get trapped in digital space by a rogue AI. To get home safely, LeBron teams up with Bugs Bunny, Daffy Duck and the rest of the Looney Tunes gang", "Space Jam", "https://www.youtube.com/watch?v=oKNy-MWjkcU" },
                    { 7, "https://m.media-amazon.com/images/I/713KEd-8jyL._AC_SL1500_.jpg", "Harry Potter, an eleven-year-old orphan, discovers that he is a wizard and is invited to study at Hogwarts. Even as he escapes a dreary life and enters a world of magic, he finds trouble awaiting him.", "Harry Potter", "https://www.youtube.com/watch?v=mNgwNXKBEW0" },
                    { 8, "https://m.media-amazon.com/images/I/41i1SGdPdML._AC_.jpg", "Released in 1940, represented Disney's boldest experiment to date. Bringing to life his vision of blending animated imagery with classical music. ", "Fantasia", "https://www.youtube.com/watch?v=sHUtZuSTSvA" },
                    { 9, "https://m.media-amazon.com/images/I/61fcSo4JxiL._AC_SY500_.jpg", "Forever alone in a crowd, failed comedian Arthur Fleck seeks connection as he walks the streets of Gotham City. Arthur wears two masks", "Joker", "https://www.youtube.com/watch?v=zAGVQLHvwOY" },
                    { 10, "https://images-na.ssl-images-amazon.com/images/I/91n9OKbLDSL.jpg", "Belle, a village girl, embarks on a journey to save her father from a creature that has locked him in his dungeon. Eventually, she learns that the creature is an enchanted prince who has been cursed.", "Beauty and the Beast", "https://www.youtube.com/watch?v=e3Nl_TCQXuw" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaId", "Capacidad" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 2, 15 },
                    { 3, 35 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculaId",
                table: "Funciones",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaId",
                table: "Funciones",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FuncionId",
                table: "Tickets",
                column: "FuncionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
