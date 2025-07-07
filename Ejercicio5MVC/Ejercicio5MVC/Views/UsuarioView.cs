using Models;
using System;

namespace Views
{
    public static class UsuarioView
    {
        public static Usuario CargarUsuario()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("=== Cargar Usuario ===");

                Console.Write("Nombre: ");
                string nombre = getValidation();

                Console.Write("Email: ");
                string email = getValidation(false, true);

                Console.ResetColor();

                return new Usuario(nombre, email);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {ex.Message}");
                Console.ResetColor();
                return null;
            }
        }

        public static void MostrarUsuario(Usuario usuario)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Nombre: {usuario.Nombre}, Email: {usuario.Email}");
            Console.ResetColor();
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
