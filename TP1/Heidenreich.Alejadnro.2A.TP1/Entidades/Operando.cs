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

        /// <summary>
        /// <set>
        /// Asignará un valor al atributo número, previa validación.
        /// </set>
        /// <get>
        /// NULL
        /// </get>
        /// </summary>
        private string Numero 
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// El constructor por defecto (sin parámetros) asignará valor 0 al atributo numero
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// comprueba que el valor recibido sea numérico, y lo retornará en formato double. Caso contrario, retornará 0.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarOperando(string strNumero)
        {
            if (!double.TryParse(strNumero, out double retorno))
            {
                retorno = 0;
            }

            return retorno;
        }

        /// <summary>
        /// valida que la cadena de caracteres esté compuesta SOLAMENTE por caracteres '0' o '1'
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
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

        /// <summary>
        /// convierte un número decimal a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            string binario = string.Empty;
            int resultado = (int)numero;
            int resto;

            while (resultado > 0)
            {
                resto = resultado % 2;

                binario = resto.ToString() + binario;
                resultado /= 2;
            }

            return binario;
        }

        /// <summary>
        /// valida que se trate de un binario y luego llama a su sobrecarga :double, en caso de ser posible. Caso contrario retornará "Valor inválido"
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            string retorno = "Valor inválido";
            if(double.TryParse(numero, out double nDecimal))
            {
                retorno = DecimalBinario(nDecimal);

            }

            return retorno;
        }

        /// <summary>
        /// valida que se trate de un binario y luego convierte ese número binario a decimal, en caso de ser posible. Caso contrario retornará "Valor inválido".
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {
            string strRetorno = "Valor inválido";
            if (EsBinario(binario))
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
                strRetorno = nDecimal.ToString();
            }
             return strRetorno; 

        }

        /// <summary>
        /// sobrecarga del operador +, recibe 2 objetos tipo operando, toma el atributo numero de cada uno y los suma
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// sobrecarga del operador -, recibe 2 objetos tipo operando, toma el atributo numero de cada uno y los resta
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// sobrecarga del operador *, recibe 2 objetos tipo operando, toma el atributo numero de cada uno y los multiplica
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// sobrecarga del operador /, recibe 2 objetos tipo operando, toma el atributo numero de cada uno y los divide. Si se tratara de una división por 0, retornará double.MinValue
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
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
