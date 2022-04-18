using System;

namespace Entidades
{
    public class Operando
    {
        #region Atributos
        private double numero;
        #endregion

        #region Propiedades
        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }
        #endregion

        #region Constructores
        public Operando()
        {
            this.numero = 0;
        }
        public Operando(double numero)
        {
            this.numero = numero;
        }
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        #endregion

        #region Metodos
        private double ValidarOperando(string strNumero)
        {
            _ = double.TryParse(strNumero, out double valor);

            return valor;
        }

        public bool EsBinario(string binario)
        {
            bool todoOk = true;
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    todoOk = false;
                    break;
                }
            }
            return todoOk;
        }

        /// <summary> Convierte el numero binario a un numero decimal </summary>
        /// <param name="binario">Numero binario a ser convertido a decimal</param>
        /// <returns> Retorna un numero decimal, al no poder retorna "valor invalido"</returns>
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";
            int x = 1;
            double numeroDecimal = 0;
            if (this.EsBinario(binario))
            {
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    if (binario[i] == '1')
                    {
                        numeroDecimal += x;
                    }
                    x *= 2;
                }

                retorno = numeroDecimal.ToString();
            }
            return retorno;
        }

        /// <summary> Convierte un decimal en binario </summary>
        /// <param name="numero"> valor a ser convertido en binario</param>
        /// <returns>Retorna un numero binario, al no poder retorna "valor invalido"</returns>
        public string DecimalBinario(double numero)
        {
            string numBinario = "";
            long resto;
            long numCociente = (long)numero;

            while (numCociente > 0)
            {
                resto = numCociente % 2;
                numCociente = numCociente / 2;

                if (resto != 0)
                {
                    numBinario = "1" + numBinario;
                }
                else
                {
                    numBinario = "0" + numBinario;
                }
            }
            return numBinario;
        }
        #endregion

        #region Sobrecarga operadores
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;

        }

        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;

        }
        public static double operator /(Operando n1, Operando n2)
        {
            double resultado;
            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            else
            {
                resultado = double.MinValue;
            }
            return resultado;
        }
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;

        }
        #endregion
    }
}
