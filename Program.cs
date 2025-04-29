using System;
using System.Collections.Generic;
using System.Linq;

namespace AdivinaEtiqueta
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lista de productos con etiquetas
            List<Producto> productos = new List<Producto>
            {
                new Producto { Nombre = "Smartphone", Etiquetas = new List<string> { "Tecnología", "Comunicación", "Pantalla Táctil" } },
                new Producto { Nombre = "Zapatillas Deportivas", Etiquetas = new List<string> { "Ropa", "Ejercicio", "Comodidad" } },
                new Producto { Nombre = "Libro de Fantasía", Etiquetas = new List<string> { "Lectura", "Aventura", "Ficción" } },
                new Producto { Nombre = "Auriculares Inalámbricos", Etiquetas = new List<string> { "Audio", "Bluetooth", "Portátil" } },
                new Producto { Nombre = "Cámara Fotográfica", Etiquetas = new List<string> { "Fotografía", "Profesional", "Imagen" } }
            };

            // Aplanar todas las etiquetas con SelectMany y eliminar duplicados
            var todasLasEtiquetas = productos.SelectMany(p => p.Etiquetas).Distinct().ToList();

            // Elegir una etiqueta aleatoriamente
            var random = new Random();
            string etiquetaOculta = todasLasEtiquetas[random.Next(todasLasEtiquetas.Count)];

            Console.WriteLine("Adivina la etiqueta oculta. ¡Tienes 3 intentos!");

            int intentos = 3;
            while (intentos > 0)
            {
                Console.Write("Etiqueta: ");
                string intento = Console.ReadLine() ?? "";

                if (string.Equals(intento, etiquetaOculta, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("¡Correcto! Has adivinado la etiqueta.");
                    break;
                }
                else
                {
                    intentos--;
                    if (intentos > 0)
                        Console.WriteLine($"Incorrecto. Te quedan {intentos} intentos.");
                    else
                        Console.WriteLine($"¡Agotaste tus intentos! La etiqueta oculta era: {etiquetaOculta}");
                }
            }

            Console.WriteLine("Gracias por jugar.");
        }
    }
}

