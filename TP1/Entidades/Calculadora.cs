using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Valida que el operador sea  / * - +
        /// </summary>
        /// <param name="operador">El char a validar</param>
        /// <returns> Retorna el operador validado, si no es valido + </returns>
        private static char ValidarOperador(char operador)
        {
            if (!(operador == '-' || operador == '+' || operador == '/' || operador == '*'))
            {
                operador = '+';
            }
            return operador;
        }

        /// <summary>
        /// Realiza la operacion pasada por parametro (suma resta multiplicacion division)
        /// </summary>
        /// <param name="num1"> Primer operando </param>
        /// <param name="num2"> Segundo operando </param>
        /// <param name="operador"> Operacion a realizar </param>
        /// <returns> Retorna el valor de la operacion </returns> 
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;
            if (num1 != null && num2 != null)
            {
                switch (Calculadora.ValidarOperador(operador))
                {
                    case '+':
                        resultado = num1 + num2;
                        break;
                    case '-':
                        resultado = num1 - num2;
                        break;
                    case '/':
                        resultado = num1 / num2;
                        break;
                    case '*':
                        resultado = num1 * num2;
                        break;
                }
            }
            return resultado;
        }
        #endregion
    }
}
