using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

namespace Repository
{
    public class ProductoRepository
    {
        private List<Producto> productos = new List<Producto>();
        private string archivo = "productos.json";
        private JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        public ProductoRepository()
        {
            Cargar();
        }

        public List<Producto> ObtenerTodos() => productos;

        public void Agregar(Producto p) => productos.Add(p);

        public void Eliminar(string id)
        {
            var prod = productos.Find(x => x.Id == id);
            if (prod != null) productos.Remove(prod);
        }

        public void Modificar(string id, Producto nuevo)
        {
            var prod = productos.Find(x => x.Id == id);
            if (prod != null)
            {
                prod.Nombre = nuevo.Nombre;
                prod.Precio = nuevo.Precio;
                prod.Stock = nuevo.Stock;
            }
        }

        public void Guardar()
        {
            var json = JsonSerializer.Serialize(productos, options);
            File.WriteAllText(archivo, json);
        }

        public void Cargar()
        {
            if (File.Exists(archivo))
            {
                var json = File.ReadAllText(archivo);
                productos = JsonSerializer.Deserialize<List<Producto>>(json) ?? new List<Producto>();
            }
        }
        
        public Producto ObtenerPorId(string id)
        {
            return productos.Find(x => x.Id == id);
        }

    }
}