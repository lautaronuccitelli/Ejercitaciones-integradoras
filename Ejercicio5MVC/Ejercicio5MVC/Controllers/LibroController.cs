using System;
using System.Collections.Generic;
using Models;
using Views;
using Repository;

namespace Controllers
{
    public class LibroController
    {
        private List<Libro> listaLibros = new List<Libro>();
        private const string archivo = "libros";

        public LibroController()
        {
            CargarLibros();
        }
        
        public void CargarLibros()
        {
            listaLibros = Repository<Libro>.ObtenerTodos(archivo);
        }

        public void GuardarLibros()
        {
            Repository<Libro>.GuardarLista(archivo, listaLibros);
        }
        
        public void AgregarLibro()
        {
            var libro = LibroView.CargarLibro();
            listaLibros.Add(libro);
            GuardarLibros();
            Console.ForegroundColor = ConsoleColor.Green;
            LibroView.MostrarMensaje("Libro agregado con exito.");
            Console.ResetColor();
        }

        public void MostrarTodosLosLibros()
        {
            Validacion();
            Console.ForegroundColor = ConsoleColor.Blue;
            LibroView.MostrarListaDeLibros(listaLibros);
            Console.ResetColor();
        }

        public void MostrarLibrosDisponibles()
        {
            Validacion();
            Console.ForegroundColor = ConsoleColor.Blue;
            LibroView.MostrarListaDeLibros(listaLibros.FindAll(l => l.Disponible));
            Console.ResetColor();
        }

        public Libro SeleccionarLibroDisponible()
        {
            var disponibles = listaLibros.FindAll(l => l.Disponible);
            if (disponibles.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                LibroView.MostrarMensaje("ERROR: no hay libros disponibles.");
                Console.ResetColor();
                return null;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            LibroView.MostrarListaDeLibros(disponibles);
            Console.Write("Seleccione un libro por ISBN: ");
            string isbn = Console.ReadLine();
            Console.ResetColor();

            return disponibles.Find(l => l.ISBN == isbn);
        }

        public void MarcarComoPrestado(Libro libro)
        {
            libro.Disponible = false;
            GuardarLibros();
        }

        public void MarcarComoDevuelto(Libro libro)
        {
            libro.Disponible = true;
            GuardarLibros();
        }

        public void Validacion()
        {
            if (listaLibros.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                LibroView.MostrarMensaje("ERROR: no hay libros cargados.");
                Console.ResetColor();
            }
        }

        public List<Libro> ObtenerLibrosDisponibles()
        {
            return listaLibros.FindAll(l => l.Disponible);
        }
    }
}
