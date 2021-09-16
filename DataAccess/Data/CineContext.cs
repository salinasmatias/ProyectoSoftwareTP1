using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class CineContext : DbContext
    {
        public CineContext() { }

        public CineContext(DbContextOptions<CineContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=SalinasMatias;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Peliculas>(entity =>
            {
                entity.HasKey(e => e.PeliculaId);

                entity.Property(e => e.Poster)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Trailer)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Salas>(entity =>
            {
                entity.HasKey(e => e.SalaId);

                entity.Property(e => e.Capacidad)
                    .IsRequired();
            });

            modelBuilder.Entity<Funciones>(entity =>
            {
                entity.HasKey(e => e.FuncionId);

                entity.Property(e => e.Fecha)
                    .IsRequired();

                entity.Property(e => e.Horario)
                    .IsRequired();

                entity.HasOne(d => d.Pelicula)
                    .WithMany(p => p.Funciones)
                    .HasForeignKey(d => d.PeliculaId);

                entity.HasOne(d => d.Sala)
                    .WithMany(p => p.Funciones)
                    .HasForeignKey(d => d.SalaId);
            });

            modelBuilder.Entity<Tickets>(entity =>
            {
                entity.HasKey(e => new { e.TicketId, e.FuncionId })
                    .HasName("Ticket");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.HasOne(d => d.Funcion)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.FuncionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FuncionId");
            });


            //INSERTS

            modelBuilder.Entity<Salas>().HasData(
                new Salas
                {
                    SalaId = 1,
                    Capacidad = 5
                },
                new Salas
                {
                    SalaId = 2,
                    Capacidad = 15
                },
                new Salas
                {
                    SalaId = 3,
                    Capacidad = 35
                }
            );

            modelBuilder.Entity<Peliculas>().HasData(
                new Peliculas
                {
                    PeliculaId = 1,
                    Titulo = "Batman & Robin",
                    Poster = "https://i.blogs.es/ec18b1/batman-robin-poster/450_1000.jpg",
                    Sinopsis = "Batman and Robin try to prevent the evil pair of Mr Freeze and Poison Ivy from freezing the town. While doing so, they also try hard to continue their partnership.",
                    Trailer = "https://www.youtube.com/watch?v=0-GIJSZ2GAk"
                },
                new Peliculas
                {
                    PeliculaId = 2,
                    Titulo = "Sonic The Hedgehog",
                    Poster = "https://m.media-amazon.com/images/I/71kgvHY5G1L._AC_SY679_.jpg",
                    Sinopsis = "An extraterrestrial hedgehog is discovered by a scientist with evil intentions and plans to use his superpowers for his selfish needs.",
                    Trailer = "https://www.youtube.com/watch?v=szby7ZHLnkA"
                },
                new Peliculas
                {
                    PeliculaId = 3,
                    Titulo = "The Lord of the Rings",
                    Poster = "https://cdn.europosters.eu/image/750/posters/lord-of-the-rings-fellowship-i11723.jpg",
                    Sinopsis = "A young hobbit, Frodo, who has found the One Ring that belongs to the Dark Lord Sauron, begins his journey with eight companions to Mount Doom, the only place where it can be destroyed.",
                    Trailer = "https://www.youtube.com/watch?v=V75dMMIW2B4"
                },
                new Peliculas
                {
                    PeliculaId = 4,
                    Titulo = "Home Alone",
                    Poster = "https://m.media-amazon.com/images/I/A1T+lZ6iUZL._SL1500_.jpg",
                    Sinopsis = "Eight-year-old Kevin is accidentally left behind when his family leaves for France. At first, he is happy to be in charge, but when thieves try to break into his home, he tries to put up a fight.",
                    Trailer = "https://www.youtube.com/watch?v=jEDaVHmw7r4"
                },
                new Peliculas
                {
                    PeliculaId = 5,
                    Titulo = "Mortal Kombat",
                    Poster = "https://oldies-cdn.freetls.fastly.net/i/boxart/w340/a-z/x/xwb4310d.jpg?v=3",
                    Sinopsis = "Three martial arts warriors journey to a faraway island to engage in battle to save the Earth. Their aim is to make sure that truth triumphs in the fight against evil.",
                    Trailer = "https://www.youtube.com/watch?v=JHIfHL5UgFs"
                },
                new Peliculas
                {
                    PeliculaId = 6,
                    Titulo = "Space Jam",
                    Poster = "https://m.media-amazon.com/images/I/61VX0X7EGDL._SY445_.jpg",
                    Sinopsis = "Superstar LeBron James and his young son, Dom, get trapped in digital space by a rogue AI. To get home safely, LeBron teams up with Bugs Bunny, Daffy Duck and the rest of the Looney Tunes gang",
                    Trailer = "https://www.youtube.com/watch?v=oKNy-MWjkcU"
                },
                new Peliculas
                {
                    PeliculaId = 7,
                    Titulo = "Harry Potter",
                    Poster = "https://m.media-amazon.com/images/I/713KEd-8jyL._AC_SL1500_.jpg",
                    Sinopsis = "Harry Potter, an eleven-year-old orphan, discovers that he is a wizard and is invited to study at Hogwarts. Even as he escapes a dreary life and enters a world of magic, he finds trouble awaiting him.",
                    Trailer = "https://www.youtube.com/watch?v=mNgwNXKBEW0"
                },
                new Peliculas
                {
                    PeliculaId = 8,
                    Titulo = "Fantasia",
                    Poster = "https://m.media-amazon.com/images/I/41i1SGdPdML._AC_.jpg",
                    Sinopsis = "Released in 1940, represented Disney's boldest experiment to date. Bringing to life his vision of blending animated imagery with classical music. ",
                    Trailer = "https://www.youtube.com/watch?v=sHUtZuSTSvA"
                },
                new Peliculas
                {
                    PeliculaId = 9,
                    Titulo = "Joker",
                    Poster = "https://m.media-amazon.com/images/I/61fcSo4JxiL._AC_SY500_.jpg",
                    Sinopsis = "Forever alone in a crowd, failed comedian Arthur Fleck seeks connection as he walks the streets of Gotham City. Arthur wears two masks",
                    Trailer = "https://www.youtube.com/watch?v=zAGVQLHvwOY"
                },
                new Peliculas
                {
                    PeliculaId = 10,
                    Titulo = "Beauty and the Beast",
                    Poster = "https://images-na.ssl-images-amazon.com/images/I/91n9OKbLDSL.jpg",
                    Sinopsis = "Belle, a village girl, embarks on a journey to save her father from a creature that has locked him in his dungeon. Eventually, she learns that the creature is an enchanted prince who has been cursed.",
                    Trailer = "https://www.youtube.com/watch?v=e3Nl_TCQXuw"
                }
            );
        }
        
        public virtual DbSet<Funciones> Funciones { get; set; }
        public virtual DbSet<Peliculas> Peliculas { get; set; }
        public virtual DbSet<Salas> Salas { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
    }
}
