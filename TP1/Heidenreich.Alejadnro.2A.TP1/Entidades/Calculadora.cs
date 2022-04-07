using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public static class Calculadora
    {

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

        private static char ValidadOperador(char operador)
        {
            if (operador == '-' || operador == '*' || operador == '/')
            {
                return operador;
            }
            return '+';
        }
    }
}
