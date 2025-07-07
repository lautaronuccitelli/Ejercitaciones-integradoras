using System;
using Controllers;

class Program
{
    static void Main()
    {
        var lController = new LibroController();
        var uController = new UsuarioController();
        var pController = new PrestamoController(lController, uController);

        string opcion = "";

        while (opcion != "0")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== MENU PRINCIPAL ===");
            Console.WriteLine("1. Agregar libro");
            Console.WriteLine("2. Mostrar todos los libros");
            Console.WriteLine("3. Mostrar libros disponibles");
            Console.WriteLine("4. Registrar prestamo");
            Console.WriteLine("5. Mostrar prestamos");
            Console.WriteLine("6. Devolver libro");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccionar opcion: ");
            Console.ResetColor();

            opcion = Console.ReadLine();
            Console.Clear();

            switch (opcion)
            {
                case "1":
                    lController.AgregarLibro();
                    break;
                case "2":
                    lController.MostrarTodosLosLibros();
                    break;
                case "3":
                    lController.MostrarLibrosDisponibles();
                    break;
                case "4":
                    pController.CrearPrestamo();
                    break;
                case "5":
                    pController.MostrarPrestamos();
                    break;
                case "6":
                    pController.DevolverLibro();
                    break;
                case "0":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saliendo del sistema...");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: opcion no valida.");
                    Console.ResetColor();
                    break;
            }

            if (opcion != "0")
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Presionar una tecla para continuar...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}
