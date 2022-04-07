using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        private string Numero 
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

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

        private double ValidarOperando(string strNumero)
        {
            double retorno = 0;

            double.TryParse(strNumero, out retorno);

            return retorno;
        }

        private static bool EsBinario(string binario)
        {
            foreach (char i in binario)
            {
                if (i != '1' && i != '0')
                {
                    return false;
                }
            }
            return true;
        }

        public static string DecimalBinario(double numero)
        {
            string retorno = string.Empty;
            string binario = string.Empty;
            int resultado = (int)numero;
            int resto;

            while (resultado > 0)
            {
                resto = resultado % 2;

                binario = binario + resto.ToString();
                resultado /= 2;
            }

            for (int i = binario.Length - 1; i >= 0; i--)
            {
                retorno += binario[i];
            }
            return retorno;
        }

        public static string DecimalBinario(string numero)
        {
            string retorno = "Valor inválido";
            double nDecimal;
            if(double.TryParse(numero, out nDecimal))
            {
                retorno = DecimalBinario(nDecimal);

            }

            return retorno;
        }

        public static string BinarioDecimal(string binario)
        {
            if (!EsBinario(binario))
            {
                return "Valor inválido";
            }
            else
            {
                int nDecimal = 0;
                int pos = binario.Length;
                foreach (char i in binario)
                {
                    pos--;
                    if (i == '1')
                    {
                        nDecimal += (int)Math.Pow(2, pos);
                    }
                }
                return nDecimal.ToString();
            }

        }

        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero+n2.numero;
        }

        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Operando n1, Operando n2)
        {
            return (n1.numero * n2.numero);
        }

        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            return double.MinValue;  
        }

    }
}
