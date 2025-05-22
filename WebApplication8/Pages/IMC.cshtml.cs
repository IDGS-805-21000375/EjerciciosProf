using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejercicios_Razor_Pages.Pages
{
    public class IMCAppModel : PageModel
    {
        [BindProperty]
        public double Peso { get; set; }

        [BindProperty]
        public double Altura { get; set; }

        public double IMC { get; set; }
        public string Clasificacion { get; set; } = "";
        public string ImagenRuta { get; set; } = "";

        public void OnPost()
        {
            if (Altura > 0)
            {
                IMC = Peso / (Altura * Altura);

                if (IMC < 18)
                {
                    Clasificacion = "Peso Bajo";
                    ImagenRuta = "/img/bajo.png";
                }
                else if (IMC < 25)
                {
                    Clasificacion = "Peso Normal";
                    ImagenRuta = "/img/normal.png";
                }
                else if (IMC < 27)
                {
                    Clasificacion = "Sobrepeso";
                    ImagenRuta = "/img/sobrepeso.png";
                }
                else if (IMC < 30)
                {
                    Clasificacion = "Obesidad grado I";
                    ImagenRuta = "/img/obesidad1.png";
                }
                else if (IMC < 40)
                {
                    Clasificacion = "Obesidad grado II";
                    ImagenRuta = "/img/obesidad2.png";
                }
                else
                {
                    Clasificacion = "Obesidad grado III";
                    ImagenRuta = "/img/obesidad3.png";
                }
            }
        }
    }
}