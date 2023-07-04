using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        public Circulo()
        {
            
        }

        public Circulo(int tipo, decimal ancho) : base(tipo, ancho)
        {
            Tipo = tipo;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _lado;
        }

        public override string TraducirFormaEspaniol(int cantidad)
        {
            return cantidad == 1 ? "Círculo" : "Círculos";
        }

        public override string TraducirFormaIngles(int cantidad)
        {
            return cantidad == 1 ? "Circle" : "Circles";
        }
    }
}
