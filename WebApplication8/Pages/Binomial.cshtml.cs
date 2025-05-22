using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejercicios_Razor_Pages.Pages
{
    public class BinomialModel : PageModel
    {
      
    [BindProperty] public double A { get; set; }
    [BindProperty] public double B { get; set; }
    [BindProperty] public double X { get; set; }
    [BindProperty] public double Y { get; set; }
    [BindProperty] public int N { get; set; }

        public double? Resultado { get; set; }

public void OnPost()
{
    Resultado = 0;

    // Versión con for
    for (int k = 0; k <= N; k++)
    {
        double coef = Combinatoria(N, k);
        double termino1 = Math.Pow(A * X, N - k);
        double termino2 = Math.Pow(B * Y, k);
        Resultado += coef * termino1 * termino2;
    }

    // Puedes descomentar una de estas para probar las otras versiones:

    //Resultado = EvaluarConWhile();
    //Resultado = EvaluarConDoWhile();
}

private double Combinatoria(int n, int k)
{
    return Factorial(n) / (Factorial(k) * Factorial(n - k));
}

private double Factorial(int num)
{
    double result = 1;
    for (int i = 2; i <= num; i++)
    {
        result *= i;
    }
    return result;
}

private double EvaluarConWhile()
{
    double resultado = 0;
    int k = 0;
    while (k <= N)
    {
        double coef = Combinatoria(N, k);
        double t1 = Math.Pow(A * X, N - k);
        double t2 = Math.Pow(B * Y, k);
        resultado += coef * t1 * t2;
        k++;
    }
    return resultado;
}

private double EvaluarConDoWhile()
{
    double resultado = 0;
    int k = 0;
    do
    {
        double coef = Combinatoria(N, k);
        double t1 = Math.Pow(A * X, N - k);
        double t2 = Math.Pow(B * Y, k);
        resultado += coef * t1 * t2;
        k++;
    } while (k <= N);
    return resultado;
}
    }
}
