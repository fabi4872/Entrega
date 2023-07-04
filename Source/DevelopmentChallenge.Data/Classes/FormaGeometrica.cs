﻿/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * OPCIONAL: Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;

        #endregion

        public readonly decimal _lado;

        public int Tipo { get; set; }

        public FormaGeometrica()
        {
        
        }

        public FormaGeometrica(int tipo, decimal ancho)
        {
            Tipo = tipo;
            _lado = ancho;
        }

        public abstract decimal CalcularArea();

        public abstract decimal CalcularPerimetro();

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                if (idioma == Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else
                    sb.Append("<h1>Empty list of shapes!</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                if (idioma == Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>");
                else
                    // default es inglés
                    sb.Append("<h1>Shapes report</h1>");

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;

                for (var i = 0; i < formas.Count; i++)
                {
                    if (formas[i].Tipo == Cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += formas[i].CalcularArea();
                        perimetroCuadrados += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == Circulo)
                    {
                        numeroCirculos++;
                        areaCirculos += formas[i].CalcularArea();
                        perimetroCirculos += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == TrianguloEquilatero)
                    {
                        numeroTriangulos++;
                        areaTriangulos += formas[i].CalcularArea();
                        perimetroTriangulos += formas[i].CalcularPerimetro();
                    }
                }

                sb.Append(new Cuadrado().ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, 1, idioma));
                sb.Append(new Circulo().ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, 3, idioma));
                sb.Append(new TrianguloEquilatero().ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, 2, idioma));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + (idioma == Castellano ? "formas" : "shapes") + " ");
                sb.Append((idioma == Castellano ? "Perimetro " : "Perimeter ") + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
            }

            return sb.ToString();
        }

        public virtual string TraducirForma(int tipo, int cantidad, int idioma)
        {
            if (idioma == Castellano)
                return TraducirFormaEspaniol(cantidad);
            
            return TraducirFormaIngles(cantidad);
        }

        public virtual string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad == 0)
                return string.Empty;

            if (idioma == Castellano)
                return ObtenerLineaEspaniol(cantidad, area, perimetro);

            return ObtenerLineaIngles(cantidad, area, perimetro);
        }

        public abstract string TraducirFormaEspaniol(int cantidad);

        public abstract string TraducirFormaIngles(int cantidad);

        public virtual string ObtenerLineaEspaniol(int cantidad, decimal area, decimal perimetro)
        {
            return $"{cantidad} {TraducirFormaEspaniol(cantidad)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";
        }

        public virtual string ObtenerLineaIngles(int cantidad, decimal area, decimal perimetro)
        {
            return $"{cantidad} {TraducirFormaIngles(cantidad)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
        }
    }
}
