using Models;
using System;
using System.Collections.Generic;

namespace Views
{
    public static class LibroView
    {
        public static Libro CargarLibro()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("=== Cargar Libro ===");

                Console.Write("Titulo: ");
                string titulo = getValidation();

                Console.Write("Autor: ");
                string autor = getValidation();

                Console.Write("ISBN: ");
                string isbn = getValidation();

                Console.ResetColor();

                return new Libro(titulo, autor, isbn);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {ex.Message}");
                Console.ResetColor();
                return null;
            }
        }

        public static void MostrarListaDeLibros(List<Libro> libros)
        {
            Console.WriteLine("------ LISTA DE LIBROS ------");
            foreach (var l in libros)
            {
                Console.WriteLine($"Titulo: {l.Titulo}, Autor: {l.Autor}, ISBN: {l.ISBN}, Disponible: {l.Disponible}");
            }
        }

        public static void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public static string getValidation(bool isNumeric = false, bool isEmail = false)
        {
            bool good = false;
            string rta;
            do
            {
                rta = Console.ReadLine();
                if (isNumeric && double.TryParse(rta, out double rtaParsed) && !string.IsNullOrEmpty(rta))
                {
                    good = true;
                }
                else if (!isNumeric && !string.IsNullOrEmpty(rta) && !isEmail)
                {
                    good = true;
                }
                else if (!isNumeric && !string.IsNullOrEmpty(rta) && isEmail && rta.Contains("@"))
                {
                    good = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: not valid input.");
                    Console.ResetColor();
                }
            } while (!good);
            return rta;
        }
    }
}
