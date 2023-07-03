using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        public Cuadrado(int tipo, decimal ancho) : base(tipo, ancho)
        {
            Tipo = tipo;
        }

        public override decimal CalcularArea() 
        {
            return _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }

        public override string TraducirFormaEspaniol(int cantidad)
        {
            return cantidad == 1 ? "Cuadrado" : "Cuadrados";
        }

        public override string TraducirFormaIngles(int cantidad)
        {
            return cantidad == 1 ? "Square" : "Squares";
        }
    }
}
