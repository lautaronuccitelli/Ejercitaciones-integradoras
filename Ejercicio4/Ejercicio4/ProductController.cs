using System;
using Models;
using Repository;
using System.Collections.Generic;

namespace Controllers
{
    public class ProductoController
    {
        private ProductoRepository repo = new ProductoRepository();

        public void Agregar()
        {
            Console.Write("Id: ");
            string id = Console.ReadLine();
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Precio: ");
            double precio = double.Parse(Console.ReadLine());
            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine());

            var p = new Producto(id, nombre, precio, stock);
            repo.Agregar(p);
        }

        public void Eliminar()
        {
            Mostrar();

            Console.Write("Id del producto a eliminar: ");
            string id = Console.ReadLine();

            var p = repo.ObtenerPorId(id);
            if (p == null)
            {
                Console.WriteLine("No se encontro un producto con ese id.");
                return;
            }

            repo.Eliminar(id);
        }

        public void Modificar()
        {
            Mostrar();

            Console.Write("Id del producto a modificar: ");
            string id = Console.ReadLine();

            var existente = repo.ObtenerPorId(id);
            if (existente == null)
            {
                Console.WriteLine("No se encontro un producto con ese id.");
                return;
            }

            Console.Write("Nuevo nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Nuevo precio: ");
            double precio = double.Parse(Console.ReadLine());
            Console.Write("Nuevo stock: ");
            int stock = int.Parse(Console.ReadLine());

            var nuevo = new Producto(id, nombre, precio, stock);
            repo.Modificar(id, nuevo);
        }

        public void Mostrar()
        {
            List<Producto> lista = repo.ObtenerTodos();
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay productos cargados.");
                return;
            }

            foreach (var p in lista)
            {
                Console.WriteLine($"Id: {p.Id}, Nombre: {p.Nombre}, Precio: {p.Precio}, Stock: {p.Stock}");
            }
        }

        public void Guardar()
        {
            repo.Guardar();
        }
    }
}
