using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometrica
    {
        public TrianguloEquilatero(int tipo, decimal ancho) : base(tipo, ancho)
        {
            Tipo = tipo;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 3;
        }

        public override string TraducirFormaEspaniol(int cantidad)
        {
            return cantidad == 1 ? "Triángulo" : "Triángulos";
        }

        public override string TraducirFormaIngles(int cantidad)
        {
            return cantidad == 1 ? "Triangle" : "Triangles";
        }
    }
}
