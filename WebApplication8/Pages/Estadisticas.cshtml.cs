using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejercicios_Razor_Pages.Pages
{
    public class EstadisticasModel : PageModel
    {
        public List<int> Numeros { get; set; } = new();
        public List<int> NumerosOrdenados { get; set; } = new();
        public int Suma { get; set; }
        public double Promedio { get; set; }
        public List<int> Moda { get; set; } = new();
        public double Mediana { get; set; }

        public void OnPost()
        {
            Random rand = new();
            Numeros = new List<int>();

            // Generar 20 números aleatorios entre 0 y 100
            for (int i = 0; i < 20; i++)
            {
                Numeros.Add(rand.Next(0, 101));
            }

            // Ordenar copia del arreglo
            NumerosOrdenados = Numeros.OrderBy(n => n).ToList();

            // Suma
            Suma = Numeros.Sum();

            // Promedio
            Promedio = Numeros.Average();

            // Moda
            Moda = Numeros
                .GroupBy(n => n)
                .OrderByDescending(g => g.Count())
                .Where(g => g.Count() == Numeros.GroupBy(x => x).Max(g2 => g2.Count()))
                .Select(g => g.Key)
                .ToList();

            // Mediana
            int medio = NumerosOrdenados.Count / 2;
            if (NumerosOrdenados.Count % 2 == 0)
            {
                Mediana = (NumerosOrdenados[medio - 1] + NumerosOrdenados[medio]) / 2.0;
            }
            else
            {
                Mediana = NumerosOrdenados[medio];
            }
        }
    }
}
