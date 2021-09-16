using Logic;
using System;
using System.Globalization;
using System.Linq;

namespace User_Interface
{
    class Menu
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("-------Cine GBA-------".PadLeft(39).PadRight(122) + "\n\n\n");
                Console.WriteLine("Bienvenido al programa. Por favor, ingrese un número para realizar una operación: \n\n\n");
                Console.WriteLine("1) Ver información de una película\n" +
                                  "2) Ver funciones de una película\n" +
                                  "3) Registrar una función\n" +
                                  "4) Obtener ticker para función\n" +
                                  "5) Ver tickets disponibles de una función \n" +
                                  "6) Salir del programa.");

                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        ViewPeliculaMenu();
                        break;

                    case "2":
                        Console.Clear();
                        VerFuncionesPorPelicula();
                        break;

                    case "3":
                        Console.Clear();
                        NuevaFuncion();
                        break;

                    case "4":
                        Console.Clear();
                        ObtenerTicker();
                        break;

                    case "5":
                        Console.Clear();
                        TicketsDisponibles();
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine("Saliendo del programa");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("La opción ingresada es incorrecta, por favor inténtelo nuevamente.");
                        Console.WriteLine("Presione enter para continuar.");
                        Console.ReadLine();
                        break;
                }
            } while (input != "6");
        }

        static void ViewPeliculaMenu()
        {
            PeliculasInfo peliculas = new PeliculasInfo();

            Console.WriteLine("-------Cine GBA-------".PadLeft(39).PadRight(122) + "\n\n\n");
            Console.WriteLine("Películas en el catálogo: \n");
            foreach (var pelicula in peliculas.GetPeliculas())
            {
                Console.WriteLine("Título: {0}", pelicula.Titulo);
            }
            Console.WriteLine("\nIngrese el título de la película cuya información desea conocer, al hacerlo, tenga en cuenta respetar mayúsculas y tildes: \n");

            string titulo = Console.ReadLine();

            var movie = peliculas.GetPeliculaByTitle(titulo);
            if (movie != null)
            {
                Console.Clear();

                Console.WriteLine("Título: " + movie.Titulo + "\n" +
                                  "Poster: " + movie.Poster + "\n" +
                                  "Sinopsis: " + movie.Sinopsis + "\n" +
                                  "Trailer: " + movie.Trailer + "\n"
                                 );

                Console.WriteLine("Presione enter para continuar y volver al menú principal.");
                Console.ReadLine();              
            }
            else
            {
                Console.Clear();
                Console.WriteLine("El título ingresado no corresponde a una película en la base de datos. Por favor, inténtelo nuevamente\n");
                Console.WriteLine("Presione Enter para continuar");
                Console.ReadLine();
                Console.Clear();   
            }
        }

        static void VerFuncionesPorPelicula()
        {
            PeliculasInfo peliculas = new PeliculasInfo();

            FuncionesPorPelicula funciones = new FuncionesPorPelicula();

            Console.WriteLine("-------Cine GBA-------".PadLeft(39).PadRight(122) + "\n\n\n");
            Console.WriteLine("Funciones Disponibles: \n");

            foreach (var pelicula in peliculas.GetPeliculas())
            {
                Console.WriteLine("Título: {0}", pelicula.Titulo);
            }
            Console.WriteLine("\nIngrese el título de la película para ver funciones disponibles, al hacerlo, tenga en cuenta respetar mayúsculas y tildes: \n");

            string titulo = Console.ReadLine();

            var movie = peliculas.GetPeliculaByTitle(titulo);

            if (movie != null)
            {

                Console.Clear();

                foreach (var funcion in funciones.GetFunciones(movie.PeliculaId))
                {
                    Console.WriteLine("Funcion: " + funcion.FuncionId + "\n" +
                                  "Película: " + movie.Titulo + "\n" +
                                  "Sala: " + funcion.SalaId + "\n" +
                                  "Fecha: " + funcion.Fecha.Date.ToString("dd/M/yyyy") + "\n" +
                                  "Horario: " + funcion.Horario + "\n"
                                 );
                }

                Console.WriteLine("Presione enter para continuar y volver al menú principal.");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("El título ingresado no corresponde a una película en la base de datos. Por favor, inténtelo nuevamente\n");
                Console.WriteLine("Presione Enter para continuar");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void NuevaFuncion()
        {
            RegistrarFunciones funcion = new RegistrarFunciones();
            PeliculasInfo peliculas = new PeliculasInfo();
            QueriesSalas salas = new QueriesSalas();
            bool validarFuncion = false;

            try
            {
                do
                {
                    Console.WriteLine("-------Cine GBA-------".PadLeft(39).PadRight(122) + "\n\n\n");
                    Console.WriteLine("Registrar una nueva función: \n");

                    Console.WriteLine("Películas en el catálogo: \n");

                    foreach (var pelicula in peliculas.GetPeliculas())
                    {
                        Console.WriteLine("Título: {0}", pelicula.Titulo);
                    }
                    Console.WriteLine("\n\nIngrese el título de la película a registrar, recuerde que debe ser una película existente en el sistema y debe respetar mayúsculas y tildes: ");

                    string titulo = Console.ReadLine();

                    Console.Clear();

                    foreach (var sala in salas.GetAllSalas())
                    {
                        Console.WriteLine("Sala: {0}\nCapacidad: {1}", sala.SalaId, sala.Capacidad);
                    }
                    
                    Console.WriteLine("Ingrese el número de sala en la cual desea registrar la función");

                    int salaInput = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese la fecha de la función: (DD/MM/YYYY)");
                    
                    string fechaInput = Console.ReadLine();

                    DateTime fechaParseada = DateTime.ParseExact(fechaInput, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    Console.WriteLine("Ingrese el horario de la función: (HH:MM)");

                    string horarioInput = Console.ReadLine();

                    DateTime horarioAParsear = Convert.ToDateTime(horarioInput);

                    TimeSpan horarioParseado = new TimeSpan(horarioAParsear.Hour, horarioAParsear.Minute, horarioAParsear.Second);



                    if (peliculas.GetPeliculas().Any(Pelicula => Pelicula.Titulo == titulo) && salas.GetAllSalas().Any(Sala => Sala.SalaId == salaInput))
                    {
                        validarFuncion = true;
                        Console.Clear();
                        Console.WriteLine(funcion.RegistrarFuncion(peliculas.GetPeliculaByTitle(titulo).PeliculaId,
                                          salaInput, 
                                          fechaParseada, 
                                          horarioParseado));
                        Console.WriteLine("Presione Enter para Continuar");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        validarFuncion = false;
                        Console.Clear();
                        Console.WriteLine("El título o sala ingresados no corresponden a una película o sala en el sistema. Por favor, inténtelo nuevamente\n");
                        Console.WriteLine("Presione Enter para continuar");
                        Console.ReadLine();
                        Console.Clear();
                    }
                } while (!validarFuncion);
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("El título o sala ingresados no corresponden a una película o sala en el sistema. Por favor, inténtelo nuevamente\n");
                Console.WriteLine("Presione Enter para continuar");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void ObtenerTicker()
        {
            try
            {
                QueriesFunciones funciones = new QueriesFunciones();
                PeliculasInfo peliculas = new PeliculasInfo();
                TicketsVentas tickets = new TicketsVentas();

                Console.WriteLine("-------Cine GBA-------".PadLeft(39).PadRight(122) + "\n\n\n");
                Console.WriteLine("Obtener un ticket: \n");
                Console.WriteLine("Funciones Disponibles :\n");

                foreach (var funcion in funciones.GetAllFunciones())
                {
                    Console.WriteLine("Funcion: " + funcion.FuncionId + "\n" +
                                      "Película: " + peliculas.GetPeliculaById(funcion.PeliculaId).Titulo + "\n" +
                                      "Sala: " + funcion.SalaId + "\n" +
                                      "Fecha: " + funcion.Fecha.Date.ToString("dd/M/yyyy") + "\n" +
                                      "Horario: " + funcion.Horario + "\n"
                                     );
                }
                Console.WriteLine("\nIngrese el número de función por la cual desea adquirir tickets: ");
                int funcionInput = int.Parse(Console.ReadLine());

                if (funciones.GetAllFunciones().Any(Funcion => Funcion.FuncionId == funcionInput))
                {
                    Console.WriteLine("Ingrese el nombre del usuario a quien corresponde el ticket: ");
                    string usuario = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine(tickets.Vender(funcionInput, usuario));
                    Console.WriteLine("Presione Enter para continuar");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El número ingresado no corresponden a una función en el sistema. Por favor, inténtelo nuevamente\n");
                    Console.WriteLine("Presione Enter para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("El dato ingresado no corresponden a una función en el sistema. Por favor, inténtelo nuevamente\n");
                Console.WriteLine("Presione Enter para continuar");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void TicketsDisponibles()
        {
            try
            {
                QueriesFunciones funciones = new QueriesFunciones();
                TicketsDisponibilidad tickets = new TicketsDisponibilidad();
                PeliculasInfo peliculas = new PeliculasInfo();

                Console.WriteLine("-------Cine GBA-------".PadLeft(39).PadRight(122) + "\n\n\n");
                Console.WriteLine("Ver disponibilidad de tickets: \n");

                foreach (var funcion in funciones.GetAllFunciones())
                {
                    Console.WriteLine("Funcion: " + funcion.FuncionId + "\n" +
                                      "Película: " + peliculas.GetPeliculaById(funcion.PeliculaId).Titulo + "\n" +
                                      "Sala: " + funcion.SalaId + "\n" +
                                      "Fecha: " + funcion.Fecha.Date.ToString("dd/M/yyyy") + "\n" +
                                      "Horario: " + funcion.Horario + "\n"
                                     );
                }
                Console.WriteLine("\nIngrese el número de función por la cual desea consultar tickets disponibles: ");
                int funcionInput = int.Parse(Console.ReadLine());

                if (funciones.GetAllFunciones().Any(Funcion => Funcion.FuncionId == funcionInput))
                {
                    Console.Clear();
                    Console.WriteLine("Cantidad de tickets disponibles para esta función: {0}", tickets.TicketsDisponibles(funcionInput));
                    Console.WriteLine("Presione Enter para continuar");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El número ingresado no corresponden a una función en el sistema. Por favor, inténtelo nuevamente\n");
                    Console.WriteLine("Presione Enter para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("El dato ingresado no corresponden a una función en el sistema. Por favor, inténtelo nuevamente\n");
                Console.WriteLine("Presione Enter para continuar");
                Console.ReadLine();
                Console.Clear();
            }
        }

    }
}
