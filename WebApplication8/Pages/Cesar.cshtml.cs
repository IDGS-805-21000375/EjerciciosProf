using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace Ejercicios_Razor_Pages.Pages
{
    public class CesarModel : PageModel
    {
     
            [BindProperty]
            public string Mensaje { get; set; } = "";

            [BindProperty]
            public int Desplazamiento { get; set; }

            [BindProperty]
            public string Operacion { get; set; } = "codificar";

            public string Resultado { get; set; } = "";

            public void OnPost()
            {
                if (string.IsNullOrWhiteSpace(Mensaje) || Desplazamiento <= 0)
                {
                    Resultado = "Por favor ingresa un mensaje válido y un desplazamiento mayor a cero.";
                    return;
                }

                Mensaje = Mensaje.ToUpper();
                StringBuilder resultadoBuilder = new();

                foreach (char c in Mensaje)
                {
                    if (c == ' ')
                    {
                        resultadoBuilder.Append(' ');
                        continue;
                    }

                    char letraTransformada = TransformarConSwitch(c, Desplazamiento, Operacion);
                    resultadoBuilder.Append(letraTransformada);
                }

                Resultado = resultadoBuilder.ToString();
            }

            private char TransformarConSwitch(char letra, int desplazamiento, string operacion)
            {
                string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                int posicionOriginal = alfabeto.IndexOf(letra);

                if (posicionOriginal == -1) return letra;

                int nuevaPos = operacion == "codificar"
                    ? (posicionOriginal + desplazamiento) % 26
                    : (posicionOriginal - desplazamiento + 26) % 26;

                char letraTransformada = alfabeto[nuevaPos];

                // Uso obligatorio de switch-case (aunque aquí no es necesario en la vida real)
                switch (letraTransformada)
                {
                    case 'A': return 'A';
                    case 'B': return 'B';
                    case 'C': return 'C';
                    case 'D': return 'D';
                    case 'E': return 'E';
                    case 'F': return 'F';
                    case 'G': return 'G';
                    case 'H': return 'H';
                    case 'I': return 'I';
                    case 'J': return 'J';
                    case 'K': return 'K';
                    case 'L': return 'L';
                    case 'M': return 'M';
                    case 'N': return 'N';
                    case 'O': return 'O';
                    case 'P': return 'P';
                    case 'Q': return 'Q';
                    case 'R': return 'R';
                    case 'S': return 'S';
                    case 'T': return 'T';
                    case 'U': return 'U';
                    case 'V': return 'V';
                    case 'W': return 'W';
                    case 'X': return 'X';
                    case 'Y': return 'Y';
                    case 'Z': return 'Z';
                    default: return letra;
                }
            }
        }
    }