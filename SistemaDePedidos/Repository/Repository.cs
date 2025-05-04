// Importación de namespaces necesarios para manejo de archivos, listas y serialización JSON
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Declaración de una clase genérica estática, parametrizada por T
// Solo se permite T que sea clase y tenga un constructor sin parámetros (new())
// Esto asegura que la deserialización pueda instanciar objetos sin argumentos
namespace Repository
{
    public static class Repository<T> where T : class, new()
    {
        // Opciones de serialización JSON: WriteIndented = true permite una salida legible en el archivo
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        // Método público para agregar una nueva entidad al archivo JSON
        public static void Agregar(string archivo, T entidad)
        {
            // Carga la lista existente del archivo, o una lista vacía si no existe
            var datos = Cargar(archivo);

            // Agrega la nueva entidad a la colección
            datos.Add(entidad);

            // Guarda la colección actualizada de vuelta en el archivo JSON
            Guardar(archivo, datos);

            //EJEMPLO DE USO:::
            //    var orden = new Order();
            //    orden.client = cliente;
            //    orden.setProductList(productos);

            //    Repository<Order>.Agregar("ordenes", orden);
        }

        // Método público para obtener todos los elementos almacenados en el archivo JSON
        public static List<T> ObtenerTodos(string archivo)
        {
            // Carga y retorna la lista de elementos
            return Cargar(archivo);
        }

        // Método público para eliminar uno o más elementos según un predicado (condición)
        public static void Eliminar(string archivo, Predicate<T> predicado)
        {
            // Carga la lista actual desde el archivo
            var datos = Cargar(archivo);

            // Elimina todos los elementos que cumplan el predicado (true)
            datos.RemoveAll(predicado);

            // Guarda la lista modificada
            Guardar(archivo, datos);
        }

        // Método público para actualizar un elemento que cumpla una condición dada
        public static void Actualizar(string archivo, Predicate<T> predicado, T nuevaEntidad)
        {
            // Carga la lista actual de elementos
            var datos = Cargar(archivo);

            // Busca el índice del primer elemento que cumpla con el predicado
            int index = datos.FindIndex(predicado);

            // Si lo encontró, reemplaza el elemento por la nueva entidad
            if (index != -1)
            {
                datos[index] = nuevaEntidad;

                // Guarda la lista actualizada
                Guardar(archivo, datos);
            }
        }

        // Método privado que serializa la lista de objetos y la guarda en un archivo JSON
        private static void Guardar(string archivo, List<T> datos)
        {
            try
            {
                // Serializa la lista de objetos a formato JSON
                string json = JsonSerializer.Serialize(datos, options);

                // Escribe el contenido en el archivo, sobrescribiéndolo si ya existe
                File.WriteAllText($"{archivo}.json", json);
            }
            catch (IOException ex)
            {
                // En caso de error de E/S, lo informa por consola (mejorable con logging profesional)
                Console.Error.WriteLine($"[ERROR] No se pudo guardar el archivo {archivo}.json: {ex.Message}");
            }
        }

        // Método privado que carga una lista de objetos desde un archivo JSON
        private static List<T> Cargar(string archivo)
        {
            try
            {
                // Define la ruta al archivo, concatenando la extensión .json
                string path = $"{archivo}.json";

                // Si el archivo no existe, devuelve una lista vacía (nada que cargar)
                if (!File.Exists(path)) return new List<T>();

                // Lee el contenido completo del archivo JSON
                string json = File.ReadAllText(path);

                // Intenta deserializar la cadena JSON a una lista de objetos
                return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
            }
            catch (Exception ex)
            {
                // Si algo falla en la lectura o deserialización, lo reporta y retorna lista vacía
                Console.Error.WriteLine($"[ERROR] Error al cargar archivo {archivo}.json: {ex.Message}");
                return new List<T>();
            }

           
        }
    }
}
