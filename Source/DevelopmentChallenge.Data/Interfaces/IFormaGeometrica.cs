using DevelopmentChallenge.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Interfaces
{
    public interface IFormaGeometrica
    {
        decimal CalcularArea();
        decimal CalcularPerimetro();
        string Imprimir(List<FormaGeometrica> formas, int idioma);
        string TraducirForma(int tipo, int cantidad, int idioma);
        string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma);
    }
}
