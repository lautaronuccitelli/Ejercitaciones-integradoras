using System.Text.Json;

namespace Repository;

public static class Repository<T>
{
    static JsonSerializerOptions options = new() { WriteIndented = true };

    private static string GetProjectRelativePath(string archivo)
    {
        string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data");
        Directory.CreateDirectory(folder);
        return Path.Combine(folder, $"{archivo}.json");
    }

    private static List<T> Cargar(string archivo)
    {
        string path = GetProjectRelativePath(archivo);
        if (!File.Exists(path)) return new List<T>();
        return JsonSerializer.Deserialize<List<T>>(File.ReadAllText(path), options) ?? new List<T>();
    }

    public static void GuardarLista(string archivo, List<T> lista)
    {
        string path = GetProjectRelativePath(archivo);
        File.WriteAllText(path, JsonSerializer.Serialize(lista, options));
    }

    public static List<T> ObtenerTodos(string archivo)
    {
        return Cargar(archivo);
    }
}