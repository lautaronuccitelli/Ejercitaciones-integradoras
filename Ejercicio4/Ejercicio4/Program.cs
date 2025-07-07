using System;
using Controllers;

class Program
{
    static void Main()
    {
        var controller = new ProductoController();
        string opcion = "";

        while (opcion != "5")
        {
            Console.Clear();
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Eliminar producto");
            Console.WriteLine("3. Modificar producto");
            Console.WriteLine("4. Mostrar productos");
            Console.WriteLine("5. Salir");
            Console.Write("Opcion: ");
            opcion = Console.ReadLine();
            Console.Clear();

            switch (opcion)
            {
                case "1": controller.Agregar(); break;
                case "2": controller.Eliminar(); break;
                case "3": controller.Modificar(); break;
                case "4": controller.Mostrar(); break;
            }

            if (opcion != "5")
            {
                Console.WriteLine("Presionar una tecla para continuar...");
                Console.ReadKey();
            }
        }

        controller.Guardar();
    }
}