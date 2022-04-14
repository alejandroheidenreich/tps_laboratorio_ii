using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// mediante el operador, realiza la operacion deseada entre 2 tipos "Operando"
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double rsp = double.NaN;
            switch (ValidadOperador(operador))
            {
                case '+':
                    rsp = num1 + num2;
                    break;
                case '-':
                    rsp = num1 - num2;
                    break;
                case '*':
                    rsp = num1 * num2;
                    break;
                case '/':
                    rsp = num1 / num2;
                    break; 
            }

            return rsp;
        }

        /// <summary>
        /// valida si el operando es distinto de (+), (-), (*) o (/) devuelve (+)
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static char ValidadOperador(char operador)
        {
            if (operador != '+' && operador != '-' && operador != '*' && operador != '/')
            {
                operador = '+';
            }
            return operador;
        }
    }
}
